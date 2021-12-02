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
        public static extern void cppAdd(float[,] A, float[,] B, float[,] C, int rows, int columns);

        [DllImport("CppLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void cppSub(float[,] A, float[,] B, float[,] C, int rows, int columns);

        [DllImport("CppLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void cppMul(float[,] A, float[,] B, float[,] C, int rows, int columns, int colsA, int colsB);

        public long time;
        public long ticks;

        public float[,] executeCppAdd(float[,] A, float[,] B, float[,] C)
        {
            int rows = C.GetLength(0);
            int columns = C.GetLength(1);

            var watch = System.Diagnostics.Stopwatch.StartNew();
            cppAdd(A, B, C, rows, columns);

            watch.Stop();
            time = watch.ElapsedMilliseconds;
            ticks = watch.ElapsedTicks;

            return C;
        }

        public float[,] executeCppSub(float[,] A, float[,] B, float[,] C)
        {
            int rows = C.GetLength(0);
            int columns = C.GetLength(1);

            var watch = System.Diagnostics.Stopwatch.StartNew();
            cppSub(A,B,C,rows,columns);


            watch.Stop();
            time = watch.ElapsedMilliseconds;
            ticks = watch.ElapsedTicks;

            return C;
        }

        public float[,] executeCppMul(float[,] A, float[,] B, float[,] C)
        {
            int rows = C.GetLength(0);
            int columns = C.GetLength(1);
            int colsA = A.GetLength(1);
            int colsB = B.GetLength(1);

            var watch = System.Diagnostics.Stopwatch.StartNew();
            cppMul(A,B,C,rows,columns,colsA,colsB);

            watch.Stop();
            time = watch.ElapsedMilliseconds;
            ticks = watch.ElapsedTicks;

            return C;
        }


    }
}
