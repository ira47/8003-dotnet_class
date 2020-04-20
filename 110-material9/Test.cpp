// Test.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"

struct IUnknown
{
	virtual int AddRef()  = 0;
	virtual int Release() = 0;
	virtual int QueryInterface(const char* interfacename,void** ppv) = 0;
};


class CTest : public IUnknown
{
	int m_nRef;
public:
	CTest()
	{
		m_nRef = 1;
	}
	virtual ~CTest()
	{
		printf("~CTest\r\n");
	}

	virtual int AddRef()
	{
		++m_nRef;
		return m_nRef;
	}
	virtual int Release()
	{
		int nRest = --m_nRef;
		if (nRest == 0)
		{
			delete this;
		}
		return nRest;
	}
	
	virtual int QueryInterface(const char* interfacename,void** ppv)
	{
		/*
		if (strcmp(interfacename,"somefunction") == 0)
		{
			*ppv = (somefunction)this;
			return 0;
		}
		*/
		return -1;
	}
};

IUnknown* CreateTest()
{
	return new CTest();
}

int _tmain(int argc, _TCHAR* argv[])
{
	IUnknown* oTest = CreateTest();
	oTest->AddRef();

	oTest->Release();
	oTest->Release();
	return 0;
}

