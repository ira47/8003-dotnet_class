// dllmain.h: 模块类的声明。

class Clog4csATLModule : public ATL::CAtlDllModuleT< Clog4csATLModule >
{
public :
	DECLARE_LIBID(LIBID_log4csATLLib)
	DECLARE_REGISTRY_APPID_RESOURCEID(IDR_LOG4CSATL, "{06C09572-11B2-4F94-8E8C-5F9A441F9926}")
};

extern class Clog4csATLModule _AtlModule;
