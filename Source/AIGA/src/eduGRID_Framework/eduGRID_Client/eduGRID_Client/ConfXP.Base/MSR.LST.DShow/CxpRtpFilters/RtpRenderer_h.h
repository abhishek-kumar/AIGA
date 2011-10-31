

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 6.00.0366 */
/* at Mon Apr 23 19:27:41 2007
 */
/* Compiler settings for .\RtpRenderer.idl:
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

#ifndef __RtpRenderer_h_h__
#define __RtpRenderer_h_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __IRtpRenderer_FWD_DEFINED__
#define __IRtpRenderer_FWD_DEFINED__
typedef interface IRtpRenderer IRtpRenderer;
#endif 	/* __IRtpRenderer_FWD_DEFINED__ */


#ifndef __RtpRenderer_FWD_DEFINED__
#define __RtpRenderer_FWD_DEFINED__

#ifdef __cplusplus
typedef class RtpRenderer RtpRenderer;
#else
typedef struct RtpRenderer RtpRenderer;
#endif /* __cplusplus */

#endif 	/* __RtpRenderer_FWD_DEFINED__ */


/* header files for imported files */
#include "oaidl.h"
#include "ocidl.h"

#ifdef __cplusplus
extern "C"{
#endif 

void * __RPC_USER MIDL_user_allocate(size_t);
void __RPC_USER MIDL_user_free( void * ); 

#ifndef __IRtpRenderer_INTERFACE_DEFINED__
#define __IRtpRenderer_INTERFACE_DEFINED__

/* interface IRtpRenderer */
/* [unique][nonextensible][uuid][object] */ 


EXTERN_C const IID IID_IRtpRenderer;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("5A3DC0B8-63D5-440b-834D-075C4BC5E7B7")
    IRtpRenderer : public IUnknown
    {
    public:
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE Initialize( 
            /* [in] */ IUnknown *pRtpSender) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IRtpRendererVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IRtpRenderer * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IRtpRenderer * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IRtpRenderer * This);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *Initialize )( 
            IRtpRenderer * This,
            /* [in] */ IUnknown *pRtpSender);
        
        END_INTERFACE
    } IRtpRendererVtbl;

    interface IRtpRenderer
    {
        CONST_VTBL struct IRtpRendererVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IRtpRenderer_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IRtpRenderer_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IRtpRenderer_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IRtpRenderer_Initialize(This,pRtpSender)	\
    (This)->lpVtbl -> Initialize(This,pRtpSender)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpstring][id] */ HRESULT STDMETHODCALLTYPE IRtpRenderer_Initialize_Proxy( 
    IRtpRenderer * This,
    /* [in] */ IUnknown *pRtpSender);


void __RPC_STUB IRtpRenderer_Initialize_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IRtpRenderer_INTERFACE_DEFINED__ */


/* Additional Prototypes for ALL interfaces */

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


