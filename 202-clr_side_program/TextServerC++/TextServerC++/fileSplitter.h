#pragma once

#ifdef FILESPLITTER_EXPORTS
#define FILESPLITTER_API __declspec(dllexport)
#else
#define FILESPLITTER_API __declspec(dllimport)
#endif

extern "C" FILESPLITTER_API int mySum(int a, int b);

extern "C" FILESPLITTER_API void divide
(char* inFileName, char* outFileName, int _ziPerLine);
