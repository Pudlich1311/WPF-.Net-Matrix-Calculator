using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLibrary
{
    public class CsLibraryClass
    {
            public static int[,] CsAdd(int[,] A, int[,] B, int[,] C)
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

            public static int[,] CsSub(int[,] A, int[,] B, int[,] C)
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

            public static int[,] CsMul(int[,] A, int[,] B, int[,] C)
            {
                for (int i = 0; i < A.GetLength(0); i++)
                {
                    for (int j = 0; j < B.GetLength(1); j++)
                    {
                        int temp = 0;
                        for (int k = 0; k < A.GetLength(1); k++)
                        {
                            temp += A[i, k] * B[k, j];
                        }
                        C[i, j] = temp;
                    }
                }
                return C;
            }

        }
    }

