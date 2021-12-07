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
        public static extern void asmAdd(float[] a, float[]b, float[]c);


        [DllImport("Asm.dll")]
        public static extern void asmSub(float[] A, float[] B, float[] C);


        [DllImport("Asm.dll")]
        public static extern void asmMul(float[] A, float[] B, float[] C, int moreVal);

        [DllImport("Asm.dll")]
        public static extern void asmDummy();

        /// <summary>
        /// time of the function
        /// </summary>
        public long time;

        /// <summary>
        /// Function to call addition
        /// </summary>
        /// <param name="A">A matrix</param>
        /// <param name="B">B matrix</param>
        /// <param name="C">C matrix</param>
        /// <returns>Matrix with result</returns>
        public float[,] executeAsmAdd(float[,] A, float[,] B, float[,] Ctemp)
        {
            asmDummy();
            var watch = System.Diagnostics.Stopwatch.StartNew();



            float[] a = new float[A.GetLength(1)];
            float[] b = new float[B.GetLength(1)];
            float[] c = new float[Ctemp.GetLength(1)];

            
            for (int i = 0; i < A.GetLength(0); i++)
            {
               for (int j = 0; j < A.GetLength(1); j++)
               {
                      a[j] = A[i, j];
                      b[j] = B[i, j];
                     c[j] = Ctemp[i, j];
               }

               asmAdd(a,b,c);

               for (int k = 0; k < Ctemp.GetLength(1); k++)
               {
                  Ctemp[i, k] = c[k];
               }
            }

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
        public float[,] executeAsmSub(float[,] A, float[,] B, float[,] Ctemp)
        {
            asmDummy();
            var watch = System.Diagnostics.Stopwatch.StartNew();

            float[] a = new float[A.GetLength(1)];
            float[] b = new float[B.GetLength(1)];
            float[] c = new float[Ctemp.GetLength(1)];

            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    a[j] = A[i, j];
                    b[j] = B[i, j];
                    c[j] = Ctemp[i, j];
                }

                asmSub(a, b, c);

                for (int k = 0; k < Ctemp.GetLength(1); k++)
                {
                    Ctemp[i, k] = c[k];
                }
            }

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
        public float[,] executeAsmMul(float[,] A, float[,] B, float[,] Ctemp)
        {
            asmDummy();
            var watch = System.Diagnostics.Stopwatch.StartNew();

           
            float[] a = new float[A.GetLength(1)];
            float[] b = new float[B.GetLength(0)];
            float[] c = new float[Ctemp.GetLength(0)];
            int rows = Ctemp.GetLength(0);
            int columns = Ctemp.GetLength(1);
            int k = 0;
            int moreVal = 0;

            if(A.GetLength(1) > 4)
            {
                moreVal = 1;
            }

            for (int i = 0; i < rows; ++i)
            {

                for (int x = 0; x < A.GetLength(1); x++)
                {
                    a[x] = A[i, x];
                   
                }
                for (int j = 0; j < columns; ++j)
                {

                    for (int y = 0; y < B.GetLength(0); y++)
                    {
                        b[y] = B[y, j];

                    }
                    asmMul(a, b, c, moreVal);
                        
                    //a lazy solution for 5x5 matrix
                  //  if(A.GetLength(1)==5)
                  //  {
                      //  c[0] += c[4];
                  //  }
                    Ctemp[i, k] = c[0];
                    k++;
                    if (k >= Ctemp.GetLength(1))
                    {
                        k = 0;
                    }

                }
            }
               

            watch.Stop();
            time = watch.ElapsedMilliseconds;

            return Ctemp;
        }


    }
    
}
