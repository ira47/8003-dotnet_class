using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program {
    static void Main()
    {
        string[] strArray = {
            "one","two","three","four","five",
            "six","seven","eight","nine","ten"
        };
        
        Console.WriteLine("(1)基本返回");
        //IEnumerable<string>相当于一个指针的list,不存储string的数据。
        IEnumerable<string> items = strArray.Where(p=>p.StartsWith("t"));
        foreach(string item in items){
            Console.WriteLine(item);
        }

        Console.WriteLine("==========================================");
        Console.WriteLine("(2)延迟执行");

        strArray[1] = "t_2";
        foreach(string item in items){
            Console.WriteLine(item);
        }

        Console.WriteLine("==========================================");
        Console.WriteLine("(3)非延迟执行");

        IEnumerable<string> static_items = strArray.Where(p=>p.StartsWith("t")).ToList();
        foreach(string item in static_items){
            Console.WriteLine(item);
        }
        strArray[2] = "t_3";
        foreach(string item in static_items){
            Console.WriteLine(item);
        }

        Console.WriteLine("==========================================");
        Console.WriteLine("(4)使用<index,value>pair来要求Where的输出。");
        Console.WriteLine("这里要求从第6个元素开始，判断其第二个字符是否是i");

        IEnumerable<string> i_items = strArray.Where((p,i)=>{
            if (i >= 5)
                return p[1] == 'i';
            else 
                return false;
        });
        foreach(string item in i_items){
            Console.WriteLine(item);
        }

        Console.WriteLine("==========================================");
        Console.WriteLine("(5)返回列表的元素长度");

        IEnumerable<int> items_length = strArray.Select(p=>p.Length);
        foreach(int item in items_length){
            Console.WriteLine(item);
        }

        Console.WriteLine("==========================================");
        Console.WriteLine("(6)返回列表的index和value");

        var items_index_value = strArray.Select((p,i)=>new{No=(i+1),Name=p});
        foreach(var item in items_index_value){
            Console.WriteLine(item);
        }

        Console.WriteLine("==========================================");
        Console.WriteLine("(7)Take函数：拿前n个");
        var take_items = strArray.Take(4);
        foreach(var item in take_items){
            Console.WriteLine(item);
        }

        Console.WriteLine("==========================================");
        Console.WriteLine("(8)TakeWhile函数：只要一不满足就停下来");
        var take_while_items = strArray.TakeWhile(p=>p.Length<4);
        foreach(var item in take_while_items){
            Console.WriteLine(item);
        }

        Console.WriteLine("==========================================");
        Console.WriteLine("(9)Skip函数：跳过前n个");
        var skip_items = strArray.Skip(5);
        foreach(var item in skip_items){
            Console.WriteLine(item);
        }

        Console.WriteLine("==========================================");
        Console.WriteLine("(10)SkipWhile函数：直到出现了第一个不符合要求的就不跳过了，剩下的都保留");
        var skip_while_items = strArray.SkipWhile(p=>p.Length<4);
        foreach(var item in skip_while_items){
            Console.WriteLine(item);
        }

        Console.WriteLine("==========================================");
        Console.WriteLine("(11)OrderBy+Take函数：排序后拿前n个");
        Console.WriteLine("这里加了负号，结果逆序。");
        var ordered_items = strArray.OrderBy(s=>-s.Length).Take(4);
        foreach(var item in ordered_items){
            Console.WriteLine(item);
        }
    }
}