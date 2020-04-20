using System;

namespace NETTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int[] values = new int[10];
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine("{0}:{1}", i, values[i]);
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("异常种类：" + e.GetType().Name);
                Console.WriteLine("出错信息：" + e.Message);
                Console.WriteLine("调用堆栈：" + e.StackTrace);
                Console.WriteLine("引发错误的方法：" + e.TargetSite);
            }
        }
    }
}