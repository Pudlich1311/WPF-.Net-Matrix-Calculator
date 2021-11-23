using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace APL_Matrix_Calculator.Calldll
{
    public unsafe class Cpp
    {
        [DllImport("CppLibrary.dll", CallingConvention = CallingConvention.Cdecl)]

        public static extern void cppAdd();

        [DllImport("CppLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void cppSub();

        [DllImport("CppLibrary.dll", CallingConvention = CallingConvention.Cdecl)]

        public static extern void cppMul();

        [DllImport("CppLibrary.dll", CallingConvention = CallingConvention.Cdecl)]

        public static extern void initializeA(int rows, int columns);

        [DllImport("CppLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void initializeB(int rows, int columns);

        [DllImport("CppLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void initializeC(int rows, int columns);

        [DllImport("CppLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void addToA(int number, int rows, int columns);

        [DllImport("CppLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void addToB(int number, int rows, int columns);

        [DllImport("CppLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int returnC(int rows, int columns);

        [DllImport("CppLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getTime();

        public void executeCppAdd()
        {
            cppAdd();
        }

        public void executeCppSub()
        {

            cppSub();
        }

        public void executeCppMul()
        {
            cppMul();
        }

        public void executeinitializeA(int rows, int columns)
        {
            initializeA(rows, columns);
        }

        public void executeinitializeB(int rows, int columns)
        {
            initializeB(rows, columns);
        }

        public void executeinitializeC(int rows, int columns)
        {
            initializeC(rows, columns);
        }


        public void executeaddToA(int number, int rows, int columns)
        {
            addToA(number, rows, columns);
        }

        public void executeaddToB(int number, int rows, int columns)
        {
            addToB(number, rows, columns);
        }

        public int executereturnC(int rows, int columns)
        {
            return returnC(rows, columns);
        }

        public int executegetTime()
        {
            return getTime();
        }
    }
}
