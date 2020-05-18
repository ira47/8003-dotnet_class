using System;
using System.Threading;

namespace task
{
    class task 
    {
        public object object;
        public Thread thread;
        public task(ParameterizedThreadStart starter, object _object)
        {
            thread = new Thread(starter);
            object = _object;
        }
        public void wait()   
        {
            thread.Join();
        }
        public void start() 
        {
            thread.Start(object);
        }
    }
    class test
    {
        static void output(object object)
        {
            Console.WriteLine("{0}", object);
        }
        static void Main(string[] args)
        {
            task my_thread = new task(output, 200); 
            my_thread.start();
            my_thread.wait();
        }
    }
}
