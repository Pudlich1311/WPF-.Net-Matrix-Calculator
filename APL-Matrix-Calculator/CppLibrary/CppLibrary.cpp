#include "pch.h" 
#include <utility>
#include <limits.h>
#include <type_traits>
#include "CppLibrary.h"


float temp;

void cppAdd(float* A, float* B, float*C, int rows, int columns)
{

	for (int i = 0; i < rows; i++)
	{
		for (int j = 0; j < columns; j++)
		{
			C[i * columns + j] = A[i * columns + j] + B[i * columns + j];
		}
	}
	return;
}

void cppSub(float* A, float* B, float* C, int rows, int columns)
{

	for (int i = 0; i < rows; i++)
	{
		for (int j = 0; j < columns; j++)
		{
			C[i*columns+j] = A[i*columns+j] - B[i*columns+j];
		}
	}
	return;
}

void cppMul(float* A, float* B, float* C, int rows, int columns, int colsA, int colsB)
{

	for (int i = 0; i < rows; ++i)
	{
		for (int j = 0; j < columns; ++j)
		{
			temp = 0;
			for (int k = 0; k < colsA; ++k)
			{
				temp += A[i*colsA+k] * B[k*colsB+j];
			}
			C[i*columns+j] = temp;
		}
	}
	return;
}
