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

extern "C" CPPLIBRAR_API void dummy(float* A, float* B, float* C);

extern "C" CPPLIBRAR_API void callAdd(float* A, float* B, float* C, int rows, int columns);

extern "C" CPPLIBRAR_API void callSub(float* A, float* B, float* C, int rows, int columns);

extern "C" CPPLIBRAR_API void callMul(float* A, float* B, float* C, int rows, int columns,int colsA, int colsB);
