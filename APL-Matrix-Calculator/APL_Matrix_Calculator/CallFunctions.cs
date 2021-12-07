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
        /// 2 - C++
        /// 3 - C#
        /// </summary>
        public int type;

        /// <summary>
        /// Variable to store result from Asm
        /// </summary>
        public float[,] Casm;

        /// <summary>
        /// Variable to store result from cpp
        /// </summary>
        public float[,] Ccpp;

        /// <summary>
        /// Variable to store result from Cs
        /// </summary>
        public float[,] Ccs;

        /// <summary>
        /// A matrix
        /// </summary>
        public float[,] A;

        /// <summary>
        /// B matrix
        /// </summary>
        public float[,] B;

        /// <summary>
        /// C matrix
        /// </summary>
        public float[,] C;

        /// <summary>
        /// Instance of class with cpp functions
        /// </summary>
        Cpp cpp = new Cpp();

        /// <summary>
        /// Instance of class with Cs functions
        /// </summary>
        Cs cs = new Cs();

        /// <summary>
        /// Instance of class with Asm functions
        /// </summary>
        Asm asm = new Asm();

        /// <summary>
        /// Time in ms for each language
        /// </summary>
        public long timeasm, timecpp, timecs;


        /// <summary>
        /// Function to perform addition in all languages, then assign to the answer
        /// the given language by user
        /// </summary>
        /// <returns>alwaysz 0</returns>
        public int callAdd()
        {
                     Casm = new float[C.GetLength(0), C.GetLength(1)];
            Ccpp = new float[C.GetLength(0), C.GetLength(1)];
            Ccs = new float[C.GetLength(0), C.GetLength(1)];
            Array.Copy(C, Casm, C.Length);
            Array.Copy(C, Ccpp, C.Length);
            Array.Copy(C, Ccs, C.Length);
                //Asm                
                Casm = asm.executeAsmAdd(A, B, Casm);
                timeasm = asm.time;

                //C++
                Ccpp = cpp.executeCppAdd(A,B,Ccpp);
                timecpp = cpp.time;

                //C#
                Ccs = cs.executeAdd(A,B,Ccs);
                timecs = cs.time;

            if (type == 1)
            {
                Array.Copy(Casm, C, C.Length);

            }
            else if (type == 2)
            {
                Array.Copy(Ccpp, C, C.Length);
            }
            else if (type == 3)
            {
                Array.Copy(Ccs, C, C.Length);
            }


            return 0; 
        }

        /// <summary>
        /// Function to perform substraction in all languages, then assign to the answer
        /// the given language by user
        /// </summary>
        /// <returns>always 0</returns>
        public int callSub()
        {
            Casm = new float[C.GetLength(0), C.GetLength(1)];
            Ccpp = new float[C.GetLength(0), C.GetLength(1)];
            Ccs = new float[C.GetLength(0), C.GetLength(1)];
            Array.Copy(C, Casm, C.Length);
            Array.Copy(C, Ccpp, C.Length);
            Array.Copy(C, Ccs, C.Length);

            //Asm     
            Casm = asm.executeAsmSub(A, B, Casm);
                timeasm = asm.time;

                //C++
                Ccpp = cpp.executeCppSub(A,B,Ccpp);
                timecpp = cpp.time;

                //C#
                Ccs = cs.executeSub(A,B,Ccs);
                timecs = cs.time;

            if (type == 1)
            {
                Array.Copy(Casm, C, C.Length);

            }
            else if (type == 2)
            {
                Array.Copy(Ccpp, C, C.Length);
            }
            else if (type == 3)
            {
                Array.Copy(Ccs, C, C.Length);
            }
            return 0;
        }

        /// <summary>
        /// Function to perform addition in all languages, then assign to the answer
        /// given language by the user
        /// </summary>
        /// <returns>always 0</returns>
        public int callMul()
        {
            Casm = new float[C.GetLength(0), C.GetLength(1)];
            Ccpp = new float[C.GetLength(0), C.GetLength(1)];
            Ccs = new float[C.GetLength(0), C.GetLength(1)];
            Array.Copy(C, Casm, C.Length);
            Array.Copy(C, Ccpp, C.Length);
            Array.Copy(C, Ccs, C.Length);
            //Asm
            Casm = asm.executeAsmMul(A, B, Casm);
            timeasm = asm.time;

            //C++
            Ccpp = cpp.executeCppMul(A,B,Ccpp);
            timecpp = cpp.time;

                //C#
              Ccs = cs.executeMul(A,B,Ccs);
                timecs = cs.time;

            if (type == 1)
            {
                Array.Copy(Casm, C, C.Length);

            }
            else if (type == 2)
            {
                Array.Copy(Ccpp, C, C.Length);
            }
            else if (type == 3)
            {
                Array.Copy(Ccs, C, C.Length);
            }
            return 0;
        }
    }
}
