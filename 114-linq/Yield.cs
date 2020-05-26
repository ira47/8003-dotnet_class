using System;
using System.Collections;

namespace YieldMethod
{
    public class MyYield : IEnumerable
    {
        public int n;
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i <= n; i += 2)
            {
                yield return i;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyYield y = new MyYield { n = 20 };

            IEnumerator NumberGenerator = y.GetEnumerator();
            while (NumberGenerator.MoveNext())
            {
                Console.WriteLine(NumberGenerator.Current);
            }

            foreach (var i in y)
            {
                Console.WriteLine(i);
            }
        }
    }
}