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
        public static extern void asmAdd(int[,] A, int[,] B, int[,] C);


        [DllImport("Asm.dll")]
        public static extern void asmSub(int[,] A, int[,] B, int[,] C);


        [DllImport("Asm.dll")]
        public static extern void asmMul(int[,] A, int[,] B, int[,] C);


        public int[,] executeAsmAdd(int[,] A, int[,] B, int[,] C)
        {
            asmAdd(A, B, C);
            return C;
        }

        public int[,] executeAsmSub(int[,] A, int[,] B, int[,] C)
        {
            asmSub(A, B, C);
            return C;
        }

        public int[,] executeAsmMul(int[,] A, int[,] B, int[,] C)
        {
            asmMul(A, B, C);
            return C;
        }
    }
}
