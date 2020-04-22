using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace 有用的特性
{
    public class Machine
    {
        private string _name;
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        //(1)使用自动实现的属性
        public decimal price { get; set; }
    }

    public static class MyExtensionMethods
    {
        public static void Dump(this Machine m)
        {
            Console.WriteLine("Extension Method Dump: {0}, {1}", m.name, m.price);
        }
        public static decimal TotalPrices(this IEnumerable<Machine> mm)
        {
            decimal total_price = 0;
            foreach (Machine m in mm)
            {
                total_price += m.price;
            }
            return total_price;
        }
        public static IEnumerable<Machine> FilterByPrice(this IEnumerable<Machine> mm, decimal price)
        {
            foreach (Machine m in mm)
            {
                if (m.price >= price)
                {
                    yield return m;
                }
            }
        }
        public static IEnumerable<Machine> FilterByDelegate(this IEnumerable<Machine> mm, Func<Machine, bool>
        filterfn)
        {
            foreach (Machine m in mm)
            {
                if (filterfn(m))
                {
                    yield return m;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 创建一个台灯
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("创建一个台灯");
            Machine lamp = new Machine();
            lamp.name = "Lamp";
            lamp.price = 2.33M;
            Console.WriteLine("Name: {0} Price: {1}", lamp.name, lamp.price);



            // 使用初始化器，创建一个风扇
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("使用初始化器，创建一个风扇");
            Machine fan = new Machine { name = "Fan", price = 18.98M };
            Console.WriteLine("Name: {0} Price: {1}", fan.name, fan.price);



            // 创建一些List和Dictionary
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("创建一些List和Dictionary");
            List<int> intList = new List<int> { 10, 20, 30, 40, 50, 60 };

            Dictionary<string, int> myDict = new Dictionary<string, int> {
                { "lamp", 10 },
                { "fan", 20 }
            };

            List<Machine> Machines = new List<Machine> {
                new Machine { name = "Lamp", price = 2.33M },
                new Machine { name = "Fan",price = 18.98M },
                new Machine { name = "TV", price = 59.99M }
            };



            // 执行封装好的输出函数Dump
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("执行封装好的输出函数Dump");
            lamp.Dump();
            fan.Dump();

            // 执行TotalPrices函数计算总价
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("执行TotalPrices函数计算总价");
            decimal totalprice = Machines.TotalPrices();
            Console.WriteLine("totalprice: {0}", totalprice);


            // 用过滤器，取出价格大于10的机器，并输出
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("用过滤器，取出价格大于10的机器，并输出");
            IEnumerable<Machine> someMachines = Machines.FilterByPrice(10);
            foreach (Machine machine in someMachines)
            {
                machine.Dump();
            }

            // 用自己写的过滤器，取出价格在[10,20]的机器，并输出
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("用自己写的过滤器，取出价格在[10,20]的机器，并输出");
            Func<Machine, bool> testFiler = delegate (Machine machine)
            {
                return (machine.price >= 10 && machine.price <= 20);
            };

            IEnumerable<Machine> someMachines2 = Machines.FilterByDelegate(testFiler);
            foreach (Machine machine in someMachines2)
            {
                machine.Dump();
            }

            // 使用 lambda 表达式写过滤器，取出价格在<=20的机器，并输出
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("使用 lambda 表达式写过滤器，取出价格在<=20的机器，并输出");
            Func<Machine, bool> testFilter2 = machine => machine.price <= 20;
            IEnumerable<Machine> someMachines3 = Machines.FilterByDelegate(testFilter2);
            foreach (Machine machine in someMachines3)
            {
                machine.Dump();
            }


            // 使用匿名类型
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("使用匿名类型");
            var m_ = new { name = "Test", price = 3.0M };
            Console.WriteLine("{1} {0}", m_.name, m_.price);

        }
    }
}