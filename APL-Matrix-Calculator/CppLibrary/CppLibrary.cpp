#include "pch.h" 
#include <utility>
#include <limits.h>
#include <type_traits>
#include<chrono>
#include "CppLibrary.h"

using namespace std::chrono;

int** A;
int** B;
int** C;
int rows;
int cols;
int colsA;

int t;

void initializeA(int rows, int columns)
{
	colsA = columns;
	A = new int*[rows];
	for (int i = 0; i < rows; ++i)
	{
		A[i] = new int[columns];
	}
}

void initializeB(int rows, int columns)
{
	B = new int* [rows];
	for (int i = 0; i < rows; ++i)
	{
		B[i] = new int[columns];
	}
}

void initializeC(int rws, int cls)
{
	C = new int* [rows];
	rows = rws;
	cols = cls;
	for (int i = 0; i < rws; ++i)
	{
		C[i] = new int[cls];
	}
}

void addToA(int number, int rows, int columns)
{
	A[rows][columns] = number;
}

void addToB(int number, int rows, int columns)
{
	B[rows][columns] = number;
}

int returnC(int rows, int columns)
{
	int ret = C[rows][columns];
	return ret;
}

void cppAdd()
{
	auto start = high_resolution_clock::now();
	for (int i = 0; i < rows; i++)
	{
		for (int j = 0; j < cols; j++)
		{
			C[i][j] = A[i][j] + B[i][j];
		}
	}
	auto stop = high_resolution_clock::now();

	auto duration = duration_cast<microseconds>(stop - start);

	t = duration.count();
	return;
}

void cppSub()
{
	auto start = high_resolution_clock::now();
	for (int i = 0; i < rows; i++)
	{
		for (int j = 0; j < cols; j++)
		{
			C[i][j] = A[i][j] - B[i][j];
		}
	}
	auto stop = high_resolution_clock::now();

	auto duration = duration_cast<microseconds>(stop - start);
	t = duration.count();
	return;

}

void cppMul()
{
	auto start = high_resolution_clock::now();
	for (int i = 0; i < rows; ++i)
		for (int j = 0; j < cols; ++j)
		{
			C[i][j] = 0;
		}

	for (int i = 0; i < rows; ++i)
	{
		for (int j = 0; j < cols; ++j)
		{
			for (int k = 0; k < colsA; ++k)
			{
				C[i][j] += A[i][k] * B[k][j];
			}
		}
	}
	auto stop = high_resolution_clock::now();

	auto duration = duration_cast<microseconds>(stop - start);
	t = duration.count();
	return;
}


int getTime()
{
	return t;
}