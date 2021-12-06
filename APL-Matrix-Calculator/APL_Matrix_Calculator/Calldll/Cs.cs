using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CsLibrary;

namespace APL_Matrix_Calculator.Calldll
{
    public unsafe class Cs
    {

        /// <summary>
        /// Instance of C# dll library
        /// </summary>
       CsLibraryClass library = new CsLibraryClass();

        /// <summary>
        /// Time spent on function
        /// </summary>
        public long time;


        /// <summary>
        /// Function to call addition
        /// </summary>
        /// <param name="A">A matrix</param>
        /// <param name="B">B matrix</param>
        /// <param name="C">C matrix</param>
        /// <returns>Matrix with result</returns>
        public float[,] executeAdd(float[,] A, float[,] B, float[,] C)
        {
            float[,] Ctemp = C;
            var watch = System.Diagnostics.Stopwatch.StartNew();
            CsLibraryClass.callAdd(A, B, Ctemp);
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
        public float[,] executeSub(float[,] A, float[,] B, float[,] C)
        {
            float[,] Ctemp = C;
            var watch = System.Diagnostics.Stopwatch.StartNew();
            CsLibraryClass.callSub( A, B, Ctemp);

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
        public float[,] executeMul(float[,] A, float[,] B, float[,] C)
        {
            float[,] Ctemp = C;
            var watch = System.Diagnostics.Stopwatch.StartNew();
            CsLibraryClass.callMul(A,  B, Ctemp);

            watch.Stop();
            time = watch.ElapsedMilliseconds;

            return Ctemp;
        }

    }
}
