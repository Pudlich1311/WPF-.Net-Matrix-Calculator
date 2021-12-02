#pragma once

#ifdef CPPLIBRARY_EXPORTS
#define CPPLIBRAR_API __declspec(dllexport)
#else
#define CPPLIBRAR_API __declspec(dllimport)
#endif


/*
* Add two matrices
*/
extern "C" CPPLIBRAR_API void cppAdd(float* A, float* B, float* C, int rows, int columns);
   
extern "C" CPPLIBRAR_API void cppSub(float* A, float* B, float* C, int rows, int columns);

extern "C" CPPLIBRAR_API void cppMul(float* A, float* B, float* C, int rows, int columns, int colsA, int colsB);