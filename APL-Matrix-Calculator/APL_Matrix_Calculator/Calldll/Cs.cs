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


       CsLibraryClass library = new CsLibraryClass();

        public long time;
        public long ticks;

        public float[,] executeAdd(float[,] A, float[,] B, float[,] C)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            CsLibraryClass.CsAdd(A, B, C);
            watch.Stop();
            time = watch.ElapsedMilliseconds;
            ticks = watch.ElapsedTicks;
            return C;
        }

        public float[,] executeSub(float[,] A, float[,] B, float[,] C)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            CsLibraryClass.CsSub( A, B, C);

            watch.Stop();
            time = watch.ElapsedMilliseconds;
            ticks = watch.ElapsedTicks;
            return C;
        }

        public float[,] executeMul(float[,] A, float[,] B, float[,] C)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            CsLibraryClass.CsMul(A,  B, C);

            watch.Stop();
            time = watch.ElapsedMilliseconds;
            ticks = watch.ElapsedTicks;
            return C;
        }

    }
}
