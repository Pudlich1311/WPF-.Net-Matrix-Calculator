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


        public static extern int[,] asmAddTwoMatrices(int[,] A, int[,] B);

        [DllImport("Asm.dll")]

        public static extern int[,] asmSubTwoMatrices(int[,] A, int[,] B);

        [DllImport("Asm.dll")]

        public static extern int[,] asmMulTwoMatrices(int[,] A, int[,] B);


        public int[,] executeAsmAddTwoMatrices(int[,] A, int[,] B)
        {
            return asmAddTwoMatrices(A, B);
        }

        public int[,] executeAsmSubTwoMatrices(int[,] A, int[,] B)
        {
            return asmSubTwoMatrices(A, B);
        }

        public int[,] executeAsmMulTwoMatrices(int[,] A, int[,] B)
        {
            return asmMulTwoMatrices(A, B);
        }
    }
}
