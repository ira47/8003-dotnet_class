#pragma once

using namespace System;

namespace ThreadWritter {
	public ref class Writer
	{
	private:
		String^ fileName = "C:\\Users\\beibe\\Desktop\\Thread.log";
	public:
		void write(array<String^>^ contents);
	};
}
