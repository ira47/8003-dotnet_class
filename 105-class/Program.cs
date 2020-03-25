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
        public Int32 _public;
        // 类构造器
        static SomeType()
        {
            Console.WriteLine("Hello SomeType!");

        }
        // 实例构造器
        public SomeType()
        {
            Console.WriteLine("Hello New Object Sometype!");
        }
        public SomeType(Int32 v)
        {
            Console.WriteLine("Hello New With Value Sometype!");
            _public = v;
        }
        public Int32 SomeProp
        {
            get
            {
                return _public;
            }
            set
            {
                _public = value;
            }
        }
        public Int32 SomeProp2 { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            SomeType o = new SomeType();
            o.SomeProp = 2020;
            Console.WriteLine("SomeProp:{0}", o._public);

            o.SomeProp2 = 2021;
            Console.WriteLine("SomeProp2:{0}", o.SomeProp2);
        }
    }
}
