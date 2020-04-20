using System;

class Test
{
    public Test()
    {
        Console.WriteLine("create");
    }
    ~Test()
    {
        Console.WriteLine("delete");
    }
}
class Program
{
    static void test()
    {
        // part 1 创建test
        // Test o = new Test();
        // Test o2 = new Test();

        //part 2 计算generation
        Test o = new Test();
        Console.WriteLine(GC.GetGeneration(o));
        GC.Collect();
        Console.WriteLine(GC.GetGeneration(o));
        GC.Collect();
        Console.WriteLine(GC.GetGeneration(o));
        GC.Collect();
        Console.WriteLine(GC.GetGeneration(o));
        GC.Collect();
        Console.WriteLine(GC.GetGeneration(o));
        // o.Dispose();
    }
    static void Main()
    {
        test();

        GC.Collect();
        GC.WaitForPendingFinalizers();
        Console.WriteLine("here");
    }
}