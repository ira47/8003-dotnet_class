using System;
using System.Threading;

class Program
{
	static int counter = 0;

    static Semaphore sem=null;

	static void ThreadProc()
	{
		for (int i=0; i< 100000; i++)
		{
            sem.WaitOne();
			counter++;
            sem.Release();
		}
        Console.WriteLine("In Thread {0}",counter);
	}

	static void Main()
	{
        // sem = new Semaphore(0,0x7FFFFFFF);
        // sem = new Semaphore(1,0x7FFFFFFF);
        sem = new Semaphore(2,0x7FFFFFFF);

		Thread t = new Thread(ThreadProc);
        t.IsBackground = true;
		t.Start();

		Thread t2 = new Thread(ThreadProc);
        t2.IsBackground = true;
		t2.Start();

		//Thread.Sleep(2000);
		t.Join();
		t2.Join();

		Console.WriteLine("counter:{0}", counter);
	}
}