using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace TextClientCSharp
{
    class Program
    {
        [DllImport("TextServerC++", EntryPoint = "mySum", CallingConvention = CallingConvention.Cdecl)]
        public static extern int Sum(int a, int b);

        [DllImport("TextServerC++", EntryPoint = "divide", CallingConvention = CallingConvention.Cdecl)]
        public static extern void divide(StringBuilder inFileName, StringBuilder outFileName, int _ziPerLine);
        static void Main(string[] args)
        {
            StringBuilder inFile = new StringBuilder();
            StringBuilder outFile = new StringBuilder();
            inFile.Append("C:\\Users\\beibe\\Desktop\\dotnet相关文件\\各种书\\bookbao.cc李凉武侠全集\\李凉 百败小赢家.txt");
            outFile.Append("C:\\Users\\beibe\\Desktop\\李凉 百败小赢家.txt");
            divide(inFile, outFile, 80);


        }
    }
}
