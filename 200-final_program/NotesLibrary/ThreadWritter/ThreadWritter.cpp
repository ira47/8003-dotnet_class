#include "pch.h"
using namespace System;
using namespace System::IO;
#include "ThreadWritter.h"

namespace ThreadWritter
{
	void Writer::write(array<String^>^ contents) {
		try {
			StreamWriter^ w = gcnew StreamWriter(fileName);
			w->Write(DateTime::Now + "\n");
			for each (String ^ content in contents)
				w->Write(content + "\n");
			w->Close();
		}
		catch (Exception^) {
		}
	}
}