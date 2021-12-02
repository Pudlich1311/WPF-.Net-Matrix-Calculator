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

        public float[,] A;

        public float[,] B;

        public float[,] C;

        Cpp cpp = new Cpp();
        Cs cs = new Cs();
        Asm asm = new Asm();

        public long timeasm, timecpp, timecs;
        public long tickscpp, ticksasm, tickscs;

        public int callAdd()
        {
            if (type ==1)
            {
                //Asm                
                C = asm.executeAsmAdd(A, B, C);
                timeasm = asm.time;
                ticksasm = asm.ticks;
            }
            else if(type==2)
            {
                //C++
                var watch = System.Diagnostics.Stopwatch.StartNew();
                C = cpp.executeCppAdd(A,B,C);
                //timecpp = cpp.time;
                // tickscpp = cpp.ticks;
                watch.Stop();
                timecpp = watch.ElapsedMilliseconds;
                tickscpp = watch.ElapsedTicks;
            }
            else if(type==3)
            {
                //C#
                C = cs.executeAdd(A,B,C);
                timecs = cs.time;
                tickscs = cs.ticks;

            }

            return 0; 
        }

        public int callSub()
        {
            if (type == 1)
            {
                //Asm     
                C = asm.executeAsmSub(A, B, C);
                timeasm = asm.time;
                ticksasm = asm.ticks;
            }
            else if (type == 2)
            {
                //C++
                C = cpp.executeCppSub(A,B,C);
                timecpp = cpp.time;
                tickscpp = cpp.ticks;
            }
            else if (type == 3)
            {
                //C#
                C = cs.executeSub(A,B,C);
                timecs = cs.time;
                tickscs = cs.ticks;
            }
            return 0;
        }

        public int callMul()
        {
            //if (type == 1)
          //  {
                //Asm
               // C = asm.executeAsmSub(A, B, C);
                timeasm = asm.time;
                ticksasm = asm.ticks;
          //  }
          //  else if (type == 2)
          //  {
                //C++
                C = cpp.executeCppMul(A,B,C);
                timecpp = cpp.time;
                tickscpp = cpp.ticks;
          //  }
          //  else if (type == 3)
          //  {
                //C#
                C = cs.executeMul(A,B,C);
                timecs = cs.time;
                tickscs = cs.ticks;
          //  }
            return 0;
        }
    }
}
