// httpRequestLogger.h : ChttpRequestLogger ������

#pragma once
#include "resource.h"       // ������



#include "log4csATL_i.h"



#if defined(_WIN32_WCE) && !defined(_CE_DCOM) && !defined(_CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA)
#error "Windows CE ƽ̨(�粻�ṩ��ȫ DCOM ֧�ֵ� Windows Mobile ƽ̨)���޷���ȷ֧�ֵ��߳� COM ���󡣶��� _CE_ALLOW_SINGLE_THREADED_OBJECTS_IN_MTA ��ǿ�� ATL ֧�ִ������߳� COM ����ʵ�ֲ�����ʹ���䵥�߳� COM ����ʵ�֡�rgs �ļ��е��߳�ģ���ѱ�����Ϊ��Free����ԭ���Ǹ�ģ���Ƿ� DCOM Windows CE ƽ̨֧�ֵ�Ψһ�߳�ģ�͡�"
#endif

using namespace ATL;


// ChttpRequestLogger

class ATL_NO_VTABLE ChttpRequestLogger :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<ChttpRequestLogger, &CLSID_httpRequestLogger>,
	public IDispatchImpl<IhttpRequestLogger, &IID_IhttpRequestLogger, &LIBID_log4csATLLib, /*wMajor =*/ 1, /*wMinor =*/ 0>
{
public:
	ChttpRequestLogger()
	{
	}

DECLARE_REGISTRY_RESOURCEID(IDR_HTTPREQUESTLOGGER)


BEGIN_COM_MAP(ChttpRequestLogger)
	COM_INTERFACE_ENTRY(IhttpRequestLogger)
	COM_INTERFACE_ENTRY(IDispatch)
END_COM_MAP()



	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct()
	{
		return S_OK;
	}

	void FinalRelease()
	{
	}

public:



	STDMETHOD(serialize)(BSTR method, BSTR uri);
};

OBJECT_ENTRY_AUTO(__uuidof(httpRequestLogger), ChttpRequestLogger)
