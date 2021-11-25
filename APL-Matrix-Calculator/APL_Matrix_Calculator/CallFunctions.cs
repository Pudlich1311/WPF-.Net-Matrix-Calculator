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

        public int[,] A;

        public int[,] B;

        public int[,] C;

        Cpp cpp = new Cpp();
        Cs cs = new Cs();
        Asm asm = new Asm();

        public long tim;
        public long ticks;

        public int callAdd()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            if (type ==1)
            {
                //Asm                
                C = asm.executeAsmAdd(A, B, C);
            }
            else if(type==2)
            {
                //C++
                C = cpp.executeCppAdd(A,B,C);
            }
            else if(type==3)
            {
                //C#
                C = cs.executeAdd(A,B,C);
            }

            watch.Stop();
            tim = watch.ElapsedMilliseconds;
            ticks = watch.ElapsedTicks;
            return 0; 
        }

        public int callSub()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            if (type == 1)
            {
                //Asm     
                C = asm.executeAsmSub(A, B, C);
            }
            else if (type == 2)
            {
                //C++
                C = cpp.executeCppSub(A,B,C);

            }
            else if (type == 3)
            {
                //C#
                C = cs.executeSub(A,B,C);
            }
            watch.Stop();
            tim = watch.ElapsedMilliseconds;
            ticks = watch.ElapsedTicks;
            return 0;
        }

        public int callMul()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            if (type == 1)
            {
                //Asm
                C = asm.executeAsmSub(A, B, C);
            }
            else if (type == 2)
            {
                //C++
                C = cpp.executeCppMul(A,B,C);
            }
            else if (type == 3)
            {
                //C#
                C = cs.executeMul(A,B,C);
            }
            watch.Stop();
            tim = watch.ElapsedMilliseconds;
            ticks = watch.ElapsedTicks;
            return 0;
        }
    }
}
