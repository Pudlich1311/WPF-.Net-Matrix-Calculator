using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace APL_Matrix_Calculator
{

    public unsafe class Asm
    {
        [DllImport("Asm.dll")]
        public static extern void asmAdd(float[,] A, float[,] B, float[,] C);


        [DllImport("Asm.dll")]
        public static extern void asmSub(float[,] A, float[,] B, float[,] C);


        [DllImport("Asm.dll")]
        public static extern void asmMul(float[,] A, float[,] B, float[,] C);

        public long time;
        public long ticks;

        public float[,] executeAsmAdd(float[,] A, float[,] B, float[,] C)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            asmAdd(A, B, C);

            watch.Stop();
            time = watch.ElapsedMilliseconds;
            ticks = watch.ElapsedTicks;
            return C;
        }

        public float[,] executeAsmSub(float[,] A, float[,] B, float[,] C)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            asmSub(A, B, C);

            watch.Stop();
            time = watch.ElapsedMilliseconds;
            ticks = watch.ElapsedTicks;
            return C;
        }

        public float[,] executeAsmMul(float[,] A, float[,] B, float[,] C)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            asmMul(A, B, C);

            watch.Stop();
            time = watch.ElapsedMilliseconds;
            ticks = watch.ElapsedTicks;
            return C;
        }
    }
}
