using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace APL_Matrix_Calculator.Calldll
{
    public unsafe class Cpp
    {
        [DllImport("CppLibrary.dll", CallingConvention = CallingConvention.Cdecl)]

        public static extern void cppAdd(int[,]A, int[,] B, int[,] C, int rows, int columns);

        [DllImport("CppLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void cppSub(int[,] A, int[,] B, int[,] C, int rows, int columns);

        [DllImport("CppLibrary.dll", CallingConvention = CallingConvention.Cdecl)]

        public static extern void cppMul(int[,] A, int[,] B, int[,]C, int rows, int columns, int colsA, int colsB);



        public int[,] executeCppAdd(int[,] A, int[,] B, int[,] C)
        {
            int rows = C.GetLength(0);
            int columns = C.GetLength(1);
            cppAdd(A, B, C, rows, columns);
            return C;
        }

        public int[,] executeCppSub(int[,] A, int[,] B, int[,] C)
        {
            int rows = C.GetLength(0);
            int columns = C.GetLength(1);
           cppSub(A,B,C,rows,columns);
            return C;
        }

        public int[,] executeCppMul(int[,] A, int[,] B, int[,] C)
        {
            int rows = C.GetLength(0);
            int columns = C.GetLength(1);
            int colsA = A.GetLength(1);
            int colsB = B.GetLength(1);
            cppMul(A,B,C,rows,columns,colsA,colsB);
            return C;
        }


    }
}
