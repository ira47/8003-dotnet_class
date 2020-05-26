using System;
using System.Collections;
using System.Text;

namespace CountDown
{
    class Program
    {
        public class MyEnumerable : IEnumerable
        {
            public int StartCountDown;
            public IEnumerator GetEnumerator()
            {
                return new MyEnumerator(this);
            }
        }
        public class MyEnumerator : IEnumerator
        {
            private int cur;
            private MyEnumerable owner;

            public MyEnumerator(MyEnumerable countdown)
            {
                owner = countdown;
                Reset();
            }
            public bool MoveNext()
            {
                if (cur > 0)
                {
                    cur--;
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                cur = owner.StartCountDown;
            }

            public object Current
            {
                get
                {
                    return cur;
                }
            }
        }
        static void Main(string[] args)
        {
            MyEnumerable countdownobj = new MyEnumerable { StartCountDown = 10 };

            IEnumerator enu = countdownobj.GetEnumerator();
            while (enu.MoveNext())
            {
                int n = (int)enu.Current;
                Console.WriteLine(n);
            }

            foreach (var i in countdownobj)
            {
                Console.WriteLine(i);
            }
        }
    }
}
