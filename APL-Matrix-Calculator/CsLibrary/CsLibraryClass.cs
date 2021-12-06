using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLibrary
{
    public class CsLibraryClass
    {
            public static float[,] csAdd(float[,] A, float[,] B, float[,] C)
            {

                for (int i = 0; i < A.GetLength(0); ++i)
                {
                    for (int j = 0; j < A.GetLength(1); ++j)
                    {
                        C[i, j] = A[i, j] + B[i, j];
                    }
                }
                return C;
            }

            public static float[,] csSub(float[,] A, float[,] B, float[,] C)
            {
                for (int i = 0; i < A.GetLength(0); ++i)
                {
                    for (int j = 0; j < A.GetLength(1); ++j)
                    {
                        C[i, j] = A[i, j] - B[i, j];
                    }
                }
                return C;
            }

            public static float[,] csMul(float[,] A, float[,] B, float[,] C)
            {
                for (int i = 0; i < A.GetLength(0); i++)
                {
                    for (int j = 0; j < B.GetLength(1); j++)
                    {
                        float temp = 0;
                        for (int k = 0; k < A.GetLength(1); k++)
                        {
                            temp += A[i, k] * B[k, j];
                        }
                        C[i, j] = temp;
                    }
                }
                return C;
            }

            public static float[,] callAdd(float[,] A, float[,] B, float[,] C)
            {
                   for(int i =0; i<150000; i++)
                   {
                        C= csAdd(A, B, C);
                   }
                    return C;
            }
            public static float[,] callSub(float[,] A, float[,] B, float[,] C)
            {
                for (int i = 0; i < 150000; i++)
                {
                    C = csSub(A, B, C);
                }
                return C;
            }
            public static float[,] callMul(float[,] A, float[,] B, float[,] C)
            {
                for (int i = 0; i < 150000; i++)
                {
                    C = csMul(A, B, C);
                }
                return C;
            }

    }
}

