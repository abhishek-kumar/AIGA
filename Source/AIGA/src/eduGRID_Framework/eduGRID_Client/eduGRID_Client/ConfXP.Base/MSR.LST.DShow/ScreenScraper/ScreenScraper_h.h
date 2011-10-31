

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 6.00.0366 */
/* at Mon Apr 23 19:27:26 2007
 */
/* Compiler settings for .\ScreenScraper.idl:
    Oicf, W3, Zp8, env=Win32 (32b run)
    protocol : dce , ms_ext, c_ext, robust
    error checks: allocation ref bounds_check enum stub_data 
    VC __declspec() decoration level: 
         __declspec(uuid()), __declspec(selectany), __declspec(novtable)
         DECLSPEC_UUID(), MIDL_INTERFACE()
*/
//@@MIDL_FILE_HEADING(  )

#pragma warning( disable: 4049 )  /* more than 64k source lines */


/* verify that the <rpcndr.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCNDR_H_VERSION__
#define __REQUIRED_RPCNDR_H_VERSION__ 475
#endif

#include "rpc.h"
#include "rpcndr.h"

#ifndef __RPCNDR_H_VERSION__
#error this stub requires an updated version of <rpcndr.h>
#endif // __RPCNDR_H_VERSION__

#ifndef COM_NO_WINDOWS_H
#include "windows.h"
#include "ole2.h"
#endif /*COM_NO_WINDOWS_H*/

#ifndef __ScreenScraper_h_h__
#define __ScreenScraper_h_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __IScreenScraper_FWD_DEFINED__
#define __IScreenScraper_FWD_DEFINED__
typedef interface IScreenScraper IScreenScraper;
#endif 	/* __IScreenScraper_FWD_DEFINED__ */


#ifndef __ScreenScraper_FWD_DEFINED__
#define __ScreenScraper_FWD_DEFINED__

#ifdef __cplusplus
typedef class ScreenScraper ScreenScraper;
#else
typedef struct ScreenScraper ScreenScraper;
#endif /* __cplusplus */

#endif 	/* __ScreenScraper_FWD_DEFINED__ */


/* header files for imported files */
#include "oaidl.h"
#include "ocidl.h"

#ifdef __cplusplus
extern "C"{
#endif 

void * __RPC_USER MIDL_user_allocate(size_t);
void __RPC_USER MIDL_user_free( void * ); 

#ifndef __IScreenScraper_INTERFACE_DEFINED__
#define __IScreenScraper_INTERFACE_DEFINED__

/* interface IScreenScraper */
/* [unique][nonextensible][uuid][object] */ 


EXTERN_C const IID IID_IScreenScraper;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("ADBCF33F-70A3-4290-A801-7B4D43FF0BAC")
    IScreenScraper : public IUnknown
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE Handle( 
            /* [in] */ HWND hWnd) = 0;
        
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE FrameRate( 
            /* [in] */ int frameRate) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IScreenScraperVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IScreenScraper * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IScreenScraper * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IScreenScraper * This);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *Handle )( 
            IScreenScraper * This,
            /* [in] */ HWND hWnd);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *FrameRate )( 
            IScreenScraper * This,
            /* [in] */ int frameRate);
        
        END_INTERFACE
    } IScreenScraperVtbl;

    interface IScreenScraper
    {
        CONST_VTBL struct IScreenScraperVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IScreenScraper_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IScreenScraper_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IScreenScraper_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IScreenScraper_Handle(This,hWnd)	\
    (This)->lpVtbl -> Handle(This,hWnd)

#define IScreenScraper_FrameRate(This,frameRate)	\
    (This)->lpVtbl -> FrameRate(This,frameRate)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [id] */ HRESULT STDMETHODCALLTYPE IScreenScraper_Handle_Proxy( 
    IScreenScraper * This,
    /* [in] */ HWND hWnd);


void __RPC_STUB IScreenScraper_Handle_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [id] */ HRESULT STDMETHODCALLTYPE IScreenScraper_FrameRate_Proxy( 
    IScreenScraper * This,
    /* [in] */ int frameRate);


void __RPC_STUB IScreenScraper_FrameRate_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IScreenScraper_INTERFACE_DEFINED__ */


/* Additional Prototypes for ALL interfaces */

unsigned long             __RPC_USER  HWND_UserSize(     unsigned long *, unsigned long            , HWND * ); 
unsigned char * __RPC_USER  HWND_UserMarshal(  unsigned long *, unsigned char *, HWND * ); 
unsigned char * __RPC_USER  HWND_UserUnmarshal(unsigned long *, unsigned char *, HWND * ); 
void                      __RPC_USER  HWND_UserFree(     unsigned long *, HWND * ); 

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


