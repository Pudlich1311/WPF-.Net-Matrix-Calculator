using APL_Matrix_Calculator.Calldll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APL_Matrix_Calculator
{
    class CallFunctions
    {
        /// <summary>
        /// Stores what kind of language we want to use
        /// 1 - Asm
        /// 2 - C
        /// 3 - C++
        /// 4 - C#
        /// 5 - all
        /// </summary>
        public int type;

        public int[,] A;

        public int[,] B;

        public int[,] C;

        Cpp cpp = new Cpp();

        public int t;



        public int callAdd()
        {
            if(type ==1)
            {
                //Asm
                Asm asm = new Asm();
                asm.executeAsmAddTwoMatrices(A, B);
            }
            else if(type==2)
            {
                //C
            }
            else if(type==3)
            {
                //C++
                
                cpp.executeinitializeA(A.GetLength(0), A.GetLength(1));
                cpp.executeinitializeB(B.GetLength(0), B.GetLength(1));
                cpp.executeinitializeC(C.GetLength(0), C.GetLength(1));

                for(int i=0; i < A.GetLength(0); ++i)
                {
                    for (int j=0; j <A.GetLength(1); ++j)
                    {
                        cpp.executeaddToA(A[i,j], i, j);
                        cpp.executeaddToB(B[i, j], i, j);
                    }
                }
                cpp.executeCppAdd();

                for(int i=0; i < C.GetLength(0); ++i)
                {
                    for(int j=0; j< C.GetLength(1); ++j)
                    {
                        C[i, j] = cpp.executereturnC(i, j);
                    }
                }
                t = cpp.executegetTime();
            }
            else if(type==4)
            {
                //C#
            }

            return 0; 
        }

        public int callSub()
        {
            if (type == 1)
            {
                //Asm
            }
            else if (type == 2)
            {
                //C
            }
            else if (type == 3)
            {
                //C++
                cpp.executeinitializeA(A.GetLength(0), A.GetLength(1));
                cpp.executeinitializeB(B.GetLength(0), B.GetLength(1));
                cpp.executeinitializeC(C.GetLength(0), C.GetLength(1));

                for (int i = 0; i < A.GetLength(0); ++i)
                {
                    for (int j = 0; j < A.GetLength(1); ++j)
                    {
                        cpp.executeaddToA(A[i, j], i, j);
                        cpp.executeaddToB(B[i, j], i, j);
                    }
                }
                cpp.executeCppSub();

                for (int i = 0; i < C.GetLength(0); ++i)
                {
                    for (int j = 0; j < C.GetLength(1); ++j)
                    {
                        C[i, j] = cpp.executereturnC(i, j);
                    }
                }
                t = cpp.executegetTime();

            }
            else if (type == 4)
            {
                //C#
            }
            return 0;
        }

        public int callMul()
        {
            if (type == 1)
            {
                //Asm
            }
            else if (type == 2)
            {
                //C
            }
            else if (type == 3)
            {
                //C++
                cpp.executeinitializeA(A.GetLength(0), A.GetLength(1));
                cpp.executeinitializeB(B.GetLength(0), B.GetLength(1));
                cpp.executeinitializeC(C.GetLength(0), C.GetLength(1));

                for (int i = 0; i < A.GetLength(0); ++i)
                {
                    for (int j = 0; j < A.GetLength(1); ++j)
                    {
                        cpp.executeaddToA(A[i, j], i, j);
                    }
                }
                for (int i = 0; i < B.GetLength(0); ++i)
                {
                    for (int j = 0; j < B.GetLength(1); ++j)
                    {
                        cpp.executeaddToB(B[i, j], i, j);
                    }
                }
                cpp.executeCppMul();

                for (int i = 0; i < C.GetLength(0); ++i)
                {
                    for (int j = 0; j < C.GetLength(1); ++j)
                    {
                        C[i, j] = cpp.executereturnC(i, j);
                    }
                }

                t = cpp.executegetTime();
            }
            else if (type == 4)
            {
                //C#
            }
            return 0;
        }
    }
}
