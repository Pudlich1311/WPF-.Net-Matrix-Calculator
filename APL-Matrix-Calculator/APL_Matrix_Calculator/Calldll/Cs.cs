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


        public int[,] executeAdd(int[,] A, int[,] B, int[,] C)
        {
            return CsLibraryClass.CsAdd(A, B,C);
        }

        public int[,] executeSub(int[,] A, int[,] B, int[,] C)
        {
            return CsLibraryClass.CsSub( A, B, C);
        }

        public int[,] executeMul(int[,] A, int[,] B, int[,] C)
        {
            return CsLibraryClass.CsMul(A,  B, C);
        }

    }
}
