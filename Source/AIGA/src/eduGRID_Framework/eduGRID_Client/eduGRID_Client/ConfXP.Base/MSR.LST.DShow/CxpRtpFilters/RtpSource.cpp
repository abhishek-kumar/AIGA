// Note: We do not support loading our filters in GraphEdt.exe
// In order to use the filter, you have to provide it with an appropriately initialized RtpStream

#include <streams.h>        // DShow base classes
#include "RtpSource.h"

// CRtpSource implementation
CRtpSource::CRtpSource(LPUNKNOWN punk, HRESULT *phr)
: CSource (NAME("RtpSource"), punk, CLSID_RtpSource) {

    CAutoLock cAutoLock(&m_cSharedState);

    eventLog = gcnew EventLog("Filters", ".", "RtpSource");

    // Create the output pin
    m_paStreams    = (CSourceStream **) new CRtpSourceStream*[1];
    if(m_paStreams == NULL) {
        *phr = E_OUTOFMEMORY;
        return;
    }

    m_paStreams[0] = new CRtpSourceStream(phr, this, L"Capture");
    if(m_paStreams[0] == NULL) {
        *phr = E_OUTOFMEMORY;
        return;
    }
}

CRtpSource::~CRtpSource() 
{
    delete m_paStreams[0];
    delete[] m_paStreams;
}

STDMETHODIMP CRtpSource::Initialize(IUnknown* pRtpStream)
{
    CAutoLock cAutoLock(&m_cSharedState);

    try
    {
        ((CRtpSourceStream*)m_paStreams[0])->rtpStream = 
            dynamic_cast<RtpStream^>(Marshal::GetObjectForIUnknown(IntPtr(pRtpStream)));
    }
    catch (Exception^ e)
    {
        eventLog->WriteEntry(e->ToString(), EventLogEntryType::Error);
        return E_FAIL;
    }

    return S_OK;
}


///////////////////////////////////////
//  COM hand-holding
///////////////////////////////////////

CUnknown * WINAPI CRtpSource::CreateInstance(LPUNKNOWN punk, HRESULT *phr) 
{
    CRtpSource* pNewObject = new CRtpSource(punk, phr);
    if(pNewObject == NULL) {
        *phr = E_OUTOFMEMORY;
    }
    return pNewObject;

}

STDMETHODIMP CRtpSource::NonDelegatingQueryInterface(REFIID riid, void **ppv)
{
    CheckPointer(ppv,E_POINTER);

    if(riid == IID_IRtpSource) {
        return GetInterface((IRtpSource *) this, ppv);
    } else {
        return CSource::NonDelegatingQueryInterface(riid, ppv);
    }

}

//
// CRtpSourceStream starts
//
CRtpSourceStream::CRtpSourceStream(HRESULT *phr, CRtpSource *pParent, LPCWSTR pPinName)
    : CSourceStream(NAME("RtpSourceStream"), phr, pParent, pPinName),
        rtpStream(0), m_bufferSizeMax(BUFFER_SIZE_DEFAULT)
{
    CAutoLock cAutoLock(&m_cSharedState);

    pCRtpSource = pParent;

    eventLog = gcnew EventLog("Filters", ".", "RtpSource");
}

HRESULT CRtpSourceStream::GetMediaType(CMediaType *pmt)
{
    CAutoLock cAutoLock(&m_cSharedState);

    if(!m_mt.IsValid())
    {
        HRESULT hr = SniffTheStream();
        if( FAILED(hr)) 
        {
            eventLog->WriteEntry("Sniffing the stream failed in GetMediatype", EventLogEntryType::Error);
            return hr;
        }
    }
    
    // If sniffing the stream produced no media types....
    if(!m_mt.IsValid())
    {
        eventLog->WriteEntry("Sniffing returned no media types in GetMediaType", EventLogEntryType::Error);
        return VFW_S_NO_MORE_ITEMS;
    }

    *pmt = m_mt;

    return NOERROR;
}

// Used to get a DShow header sample so we can fill out buffer size and MediaType before the stream starts playing.
HRESULT CRtpSourceStream::SniffTheStream(void)
{
    CAutoLock cAutoLock(&m_cSharedState);

    try
    {
        MSR::LST::BufferChunk^ frame = rtpStream->FirstFrame();

        ReadHeader(frame);

        // Save what we've learned
        return CSourceStream::SetMediaType(new CMediaType(m_RemoteMediaType));
    }
    catch (Exception^ e)
    {
        eventLog->WriteEntry(e->ToString(), EventLogEntryType::Error);
        return E_FAIL;
    }
}

HRESULT CRtpSourceStream::DecideBufferSize(IMemAllocator *pAlloc, ALLOCATOR_PROPERTIES *pProperties)
{
    CAutoLock cAutoLock(&m_cSharedState);

    ASSERT(pAlloc);
    ASSERT(pProperties);
    HRESULT hr = NOERROR;

    // With compressed video, sample size can vary
    // Hopefully, biSizeImage tells us the max, not the actual
    if(*(m_mt.Type()) == MEDIATYPE_Video)
    {
        // Get the format area of the media type
        VIDEOINFO *pvi = (VIDEOINFO *) m_mt.Format();

        if(pvi == NULL)
            return E_INVALIDARG;

        // Find out how large the sample is
        if(m_bufferSizeMax < pvi->bmiHeader.biSizeImage)
        {
            m_bufferSizeMax = pvi->bmiHeader.biSizeImage;
        }
    }

    
    pProperties->cBuffers = 1;
    pProperties->cbBuffer = m_bufferSizeMax;

    ASSERT(pProperties->cbBuffer);

    // Ask the allocator to reserve us some sample memory, NOTE the function
    // can succeed (that is return NOERROR) but still not have allocated the
    // memory that we requested, so we must check we got whatever we wanted

    ALLOCATOR_PROPERTIES Actual;
    hr = pAlloc->SetProperties(pProperties,&Actual);
    if( FAILED(hr)) 
    {
        eventLog->WriteEntry("Failed to SetProperties in decide buffer size", EventLogEntryType::Error);
        return hr;
    }

    if(Actual.cbBuffer < pProperties->cbBuffer) {
        eventLog->WriteEntry("Unsuitable allocator in decide buffer size", EventLogEntryType::Error);
        return E_FAIL;
    }
    return NOERROR;
}

HRESULT CRtpSourceStream::FillBuffer(IMediaSample *pMediaSample)
{
    CAutoLock cAutoLock(&m_cSharedState);
    HRESULT hr = S_OK;

    try
    {
        MSR::LST::BufferChunk^ frame = rtpStream->NextFrame();

        ReadHeader(frame);

        // Payload
        byte* payload = 0;
        hr = pMediaSample->GetPointer(&payload);
        if(FAILED(hr)) 
        {
            eventLog->WriteEntry("Failed to get Payload Pointer from IMediaSample", EventLogEntryType::Error);
            return hr;
        }
        
        // We don't allow the media type to change mid stream (yet)
        Debug::Assert(m_RemoteSampleProps.pMediaType == 0);

        // I have tried copying the remote sample properties using IMediaSample2 directly onto our
        // sample (being sure to not copy the last 2 values, 8 bytes), but it causes the video to 
        // run like molasses, probably because MediaTime isn't right.  Need to investigate more.
        // jasonv 3.24.2005
        if(m_RemoteSampleProps.dwSampleFlags & AM_SAMPLE_SPLICEPOINT)
        {
            hr = pMediaSample->SetSyncPoint(true);
            if(FAILED(hr))
            {
                eventLog->WriteEntry("Failed to SetSyncPoint", EventLogEntryType::Error);
                return hr;
            }
        }

        // The rest is sample data
        Debug::Assert(frame->Length == m_RemoteSampleProps.lActual);

        pMediaSample->SetActualDataLength(frame->Length);
        frame->CopyTo(IntPtr(payload), frame->Length);
    }

    // Trying to get data after the NextFrame call was manually unblocked or the stream was disposed
    catch(NextFrameUnblockedException^){hr = S_FALSE;}

    catch (Exception^ e)
    {
        eventLog->WriteEntry(e->ToString(), EventLogEntryType::Error);
        hr = E_FAIL;
    }

    return hr;
}

void CRtpSourceStream::ReadHeader(BufferChunk^ frame)
{
    // Not needed since all data is fixed size, but since we have it, we use it to figure out
    // how far ahead to skip the buffer, without actually reading the data in ReadMediaType
    UInt16 cbHeader = frame->NextUInt16();

    ReadSampleProps(frame, cbHeader);
    ReadMediaType(frame, cbHeader);
}

void CRtpSourceStream::ReadSampleProps(BufferChunk^ frame, UInt16& cbHeader)
{
    frame->CopyTo(IntPtr(&m_RemoteSampleProps), sizeof(m_RemoteSampleProps));
    cbHeader -= sizeof(m_RemoteSampleProps);
}

void CRtpSourceStream::ReadMediaType(BufferChunk^ frame, UInt16& cbHeader)
{
    // Currently, we only support reading the MediaType the first time, so skip the copy if we can
    // This will need to change when we actually support changing the media type mid-stream
    if(m_mt.IsValid())
    {
        frame->Reset(frame->Index + cbHeader, frame->Length - cbHeader);
    }
    else
    {
        frame->CopyTo(IntPtr(&m_RemoteMediaType), sizeof(m_RemoteMediaType));

        if(m_RemoteMediaType.cbFormat > 0)
        {
            Debug::Assert(m_RemoteMediaType.pbFormat != 0);
            
            m_RemoteMediaType.pbFormat = (BYTE*)CoTaskMemAlloc(m_RemoteMediaType.cbFormat);
            frame->CopyTo(IntPtr(m_RemoteMediaType.pbFormat), m_RemoteMediaType.cbFormat);
        }
    }
}