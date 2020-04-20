using System;
using System.Text;
class Program
{
    const int loopcount = 50000;

    static void test1()
    {
        string str = "";
        for (int i = 1; i <= loopcount; i++)
        {
            str += i;
            if (i < loopcount)
                str += "+";
        }
        // System.Console.WriteLine(str);
    }
    static void test2()
    {
        StringBuilder sb = new StringBuilder(4096);
        for (int i = 1; i <= loopcount; i++)
        {
            sb.Append(i);
            if (i < loopcount)
                sb.Append("+");
        }
    }
    public delegate int addDelegate(int x, int y);

    static void Main()
    {
        // part 1 基本字符处理
        // System.Console.WriteLine("A");

        // char c = unchecked((char)(65536 + 65));

        // System.Console.WriteLine(c);

        // c = System.Convert.ToChar(66);

        // System.Console.WriteLine(c);

        // try
        // {
        // 	c = System.Convert.ToChar(65536 + 65);
        // 	System.Console.WriteLine(c);
        // }
        // catch(OverflowException e)
        // {
        // 	System.Console.WriteLine(e.ToString());
        // }

        // c = ((IConvertible)65).ToChar(null);
        // System.Console.WriteLine(c);




        // part 2 字符串比较
        // string s1 = "aaaa";
        // string s2 = "aaaa";
        // string s3 = new String('a',4);

        // System.Console.WriteLine(s1 == s2);
        // System.Console.WriteLine(s1 == s3);

        // System.Console.WriteLine((Object)s1 == (Object)s2);
        // System.Console.WriteLine((Object)s1 == (Object)s3);




        // part 3 字符串连接速度测试
        // System.Console.WriteLine("One");
        // test1();
        // System.Console.WriteLine("Two");
        // test2();
        // System.Console.WriteLine("Three");


        // 下面是两个附属的程序。包括delegate和lambda

        addDelegate d = delegate (int i, int j)
        {
            System.Console.WriteLine("addDelegate: {0} {1}", i, j);
            return i + j;
        };

        System.Console.WriteLine(d(100, 200));

        addDelegate d2 = (i, j) =>
        {
            System.Console.WriteLine("lambda1: {0} {1}", i, j);
            return i + j;
        };

        d2 += (i, j) =>
        {
            System.Console.WriteLine("lambda2: {0} {1}", i, j);
            return i + j + 1;
        };

        System.Console.WriteLine(d2(100, 200));
    }
}