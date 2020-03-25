using System;

namespace _105_class
{
    class SomeType
    {
        class SomeNestedType
        { }

        const Int32 _const = -1;
        readonly Int32 _read_only = 2;
        static Int32 _static = 3;
        static Int32 _public;

        static SomeType()
        {
            Console.WriteLine("Hello SomeType!");

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            SomeType o = new SomeType();
            SomeType o2 = new SomeType();
        }
    }
}
