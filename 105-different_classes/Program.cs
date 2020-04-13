using System;

namespace _105_class
{
    class SomeType
    {
        class SomeNestedType { }

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
        // 属性构造器
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
        // 索引器属性
        public Int32 this[String key]
        {
            get
            {
                if (key == "aaa")
                    return _public;
                return 0;
            }
            set
            {
                if (key == "aaa")
                    _public = value;
            }
        }
        // 事件者属性
        public event EventHandler SomeEvent;
        public void TriggerEvent()
        {
            if (SomeEvent != null)
            {
                SomeEvent(this, null);
            }
        }
    }
    class Program
    {
        static void MyEventHandler(object sender, EventArgs args)
        {
            SomeType o = (SomeType)sender;
            o["aaa"] = 2022;
            Console.WriteLine("aaa:{0}", o._public);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            SomeType o = new SomeType();
            o.SomeProp = 2020;
            Console.WriteLine("SomeProp:{0}", o._public);

            o.SomeProp2 = 2021;
            Console.WriteLine("SomeProp2:{0}", o.SomeProp2);

            o.SomeEvent += MyEventHandler;
            o.TriggerEvent();

        }
    }
}
