#pragma once

#ifdef CPPLIBRARY_EXPORTS
#define CPPLIBRAR_API __declspec(dllexport)
#else
#define CPPLIBRAR_API __declspec(dllimport)
#endif



extern "C" CPPLIBRAR_API void initializeA(int rows, int columns);

extern "C" CPPLIBRAR_API void initializeB(int rows, int columns);

extern "C" CPPLIBRAR_API void initializeC(int rows, int columns);

extern "C" CPPLIBRAR_API void addToA(int number, int rows, int columns);

extern "C" CPPLIBRAR_API void addToB(int number, int rows, int columns);

extern "C" CPPLIBRAR_API int returnC(int rows, int columns);

extern "C" CPPLIBRAR_API int getTime();
/*
* Add two matrices
*/
extern "C" CPPLIBRAR_API void cppAdd();
   
extern "C" CPPLIBRAR_API void cppSub();

extern "C" CPPLIBRAR_API void cppMul();