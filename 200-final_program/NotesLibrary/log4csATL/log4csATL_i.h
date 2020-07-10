

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 8.01.0622 */
/* at Tue Jan 19 11:14:07 2038
 */
/* Compiler settings for log4csATL.idl:
    Oicf, W1, Zp8, env=Win32 (32b run), target_arch=X86 8.01.0622 
    protocol : dce , ms_ext, c_ext, robust
    error checks: allocation ref bounds_check enum stub_data 
    VC __declspec() decoration level: 
         __declspec(uuid()), __declspec(selectany), __declspec(novtable)
         DECLSPEC_UUID(), MIDL_INTERFACE()
*/
/* @@MIDL_FILE_HEADING(  ) */



/* verify that the <rpcndr.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCNDR_H_VERSION__
#define __REQUIRED_RPCNDR_H_VERSION__ 500
#endif

#include "rpc.h"
#include "rpcndr.h"

#ifndef __RPCNDR_H_VERSION__
#error this stub requires an updated version of <rpcndr.h>
#endif /* __RPCNDR_H_VERSION__ */

#ifndef COM_NO_WINDOWS_H
#include "windows.h"
#include "ole2.h"
#endif /*COM_NO_WINDOWS_H*/

#ifndef __log4csATL_i_h__
#define __log4csATL_i_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __IhttpRequestLogger_FWD_DEFINED__
#define __IhttpRequestLogger_FWD_DEFINED__
typedef interface IhttpRequestLogger IhttpRequestLogger;

#endif 	/* __IhttpRequestLogger_FWD_DEFINED__ */


#ifndef __httpRequestLogger_FWD_DEFINED__
#define __httpRequestLogger_FWD_DEFINED__

#ifdef __cplusplus
typedef class httpRequestLogger httpRequestLogger;
#else
typedef struct httpRequestLogger httpRequestLogger;
#endif /* __cplusplus */

#endif 	/* __httpRequestLogger_FWD_DEFINED__ */


/* header files for imported files */
#include "oaidl.h"
#include "ocidl.h"

#ifdef __cplusplus
extern "C"{
#endif 


#ifndef __IhttpRequestLogger_INTERFACE_DEFINED__
#define __IhttpRequestLogger_INTERFACE_DEFINED__

/* interface IhttpRequestLogger */
/* [unique][nonextensible][dual][uuid][object] */ 


EXTERN_C const IID IID_IhttpRequestLogger;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("11DA3A67-B60F-4784-A794-3D70BEE5D53E")
    IhttpRequestLogger : public IDispatch
    {
    public:
        virtual /* [id] */ HRESULT STDMETHODCALLTYPE serialize( 
            BSTR method,
            BSTR uri) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct IhttpRequestLoggerVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IhttpRequestLogger * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IhttpRequestLogger * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IhttpRequestLogger * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IhttpRequestLogger * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IhttpRequestLogger * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IhttpRequestLogger * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IhttpRequestLogger * This,
            /* [annotation][in] */ 
            _In_  DISPID dispIdMember,
            /* [annotation][in] */ 
            _In_  REFIID riid,
            /* [annotation][in] */ 
            _In_  LCID lcid,
            /* [annotation][in] */ 
            _In_  WORD wFlags,
            /* [annotation][out][in] */ 
            _In_  DISPPARAMS *pDispParams,
            /* [annotation][out] */ 
            _Out_opt_  VARIANT *pVarResult,
            /* [annotation][out] */ 
            _Out_opt_  EXCEPINFO *pExcepInfo,
            /* [annotation][out] */ 
            _Out_opt_  UINT *puArgErr);
        
        /* [id] */ HRESULT ( STDMETHODCALLTYPE *serialize )( 
            IhttpRequestLogger * This,
            BSTR method,
            BSTR uri);
        
        END_INTERFACE
    } IhttpRequestLoggerVtbl;

    interface IhttpRequestLogger
    {
        CONST_VTBL struct IhttpRequestLoggerVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IhttpRequestLogger_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IhttpRequestLogger_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IhttpRequestLogger_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IhttpRequestLogger_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define IhttpRequestLogger_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define IhttpRequestLogger_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define IhttpRequestLogger_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 


#define IhttpRequestLogger_serialize(This,method,uri)	\
    ( (This)->lpVtbl -> serialize(This,method,uri) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IhttpRequestLogger_INTERFACE_DEFINED__ */



#ifndef __log4csATLLib_LIBRARY_DEFINED__
#define __log4csATLLib_LIBRARY_DEFINED__

/* library log4csATLLib */
/* [version][uuid] */ 


EXTERN_C const IID LIBID_log4csATLLib;

EXTERN_C const CLSID CLSID_httpRequestLogger;

#ifdef __cplusplus

class DECLSPEC_UUID("2306D767-4B82-47E0-AFB9-30703892EA84")
httpRequestLogger;
#endif
#endif /* __log4csATLLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

unsigned long             __RPC_USER  BSTR_UserSize(     unsigned long *, unsigned long            , BSTR * ); 
unsigned char * __RPC_USER  BSTR_UserMarshal(  unsigned long *, unsigned char *, BSTR * ); 
unsigned char * __RPC_USER  BSTR_UserUnmarshal(unsigned long *, unsigned char *, BSTR * ); 
void                      __RPC_USER  BSTR_UserFree(     unsigned long *, BSTR * ); 

unsigned long             __RPC_USER  BSTR_UserSize64(     unsigned long *, unsigned long            , BSTR * ); 
unsigned char * __RPC_USER  BSTR_UserMarshal64(  unsigned long *, unsigned char *, BSTR * ); 
unsigned char * __RPC_USER  BSTR_UserUnmarshal64(unsigned long *, unsigned char *, BSTR * ); 
void                      __RPC_USER  BSTR_UserFree64(     unsigned long *, BSTR * ); 

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


