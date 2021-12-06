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
        public static extern void dummy(float[,] A, float[,] B, float[,] C); 

        [DllImport("CppLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void callAdd(float[,] A, float[,] B, float[,] C, int rows, int columns);

        [DllImport("CppLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void callSub(float[,] A, float[,] B, float[,] C, int rows, int columns);

        [DllImport("CppLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void callMul(float[,] A, float[,] B, float[,] C, int rows, int columns, int colsA, int colsB);




        /// <summary>
        /// Time spent on the function
        /// </summary>
        public long time;


        /// <summary>
        /// Function to call addition
        /// </summary>
        /// <param name="A">A matrix</param>
        /// <param name="B">B matrix</param>
        /// <param name="C">C matrix</param>
        /// <returns>Matrix with result</returns>
        public float[,] executeCppAdd(float[,] A, float[,] B, float[,] C)
        {
            dummy(A, B, C);
            float[,] Ctemp = C;
            int rows = C.GetLength(0);
            int columns = C.GetLength(1);

            var watch = System.Diagnostics.Stopwatch.StartNew();
            callAdd(A, B, C, rows, columns);


            watch.Stop();
            time = watch.ElapsedMilliseconds;
 

            return Ctemp;
        }

        /// <summary>
        /// Function to call substraction
        /// </summary>
        /// <param name="A">A matrix</param>
        /// <param name="B">B matrix</param>
        /// <param name="C">C matrix</param>
        /// <returns>Matrix with result</returns>
        public float[,] executeCppSub(float[,] A, float[,] B, float[,] C)
        {
            dummy(A, B, C);
            float[,] Ctemp = C;
            int rows = C.GetLength(0);
            int columns = C.GetLength(1);

            var watch = System.Diagnostics.Stopwatch.StartNew();
            callSub(A,B,Ctemp,rows,columns);


            watch.Stop();
            time = watch.ElapsedMilliseconds;


            return Ctemp;
        }

        /// <summary>
        /// Function to call multiplication
        /// </summary>
        /// <param name="A">A matrix</param>
        /// <param name="B">B matrix</param>
        /// <param name="C">C matrix</param>
        /// <returns>Matrix with result</returns>
        public float[,] executeCppMul(float[,] A, float[,] B, float[,] C)
        {
            dummy(A, B, C);
            float[,] Ctemp = C;
            int rows = C.GetLength(0);
            int columns = C.GetLength(1);
            int colsA = A.GetLength(1);
            int colsB = B.GetLength(1);

            var watch = System.Diagnostics.Stopwatch.StartNew();
            callMul(A,B,Ctemp,rows,columns,colsA,colsB);

            watch.Stop();
            time = watch.ElapsedMilliseconds;


            return Ctemp;
        }




    }
}
