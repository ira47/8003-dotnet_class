using System;
using System.Threading;

class Program
{
	static int counter = 0;

	static object synobject = new object();

	static void ThreadProc()
	{
		//Thread.Sleep(5000);
		// Console.WriteLine("In Thread.");
		for (int i=0; i< 10000000; i++){
			// 会出错的代码：一个线程没有执行完，被另一个线程打断。
			// counter++;
			
			// 解决冲突问题 方法一 使用Interlock
			// Interlocked.Increment(ref counter);
			
			// 方法二 定义一个锁，使用Monitor来加锁/解锁
			Monitor.Enter(synobject);
			counter++;
			Monitor.Exit(synobject);
		}
	}

	static void Main()
	{
		Thread t = new Thread(ThreadProc);
		t.Start();

		Thread t2 = new Thread(ThreadProc);
		t2.Start();

		//Thread.Sleep(2000);
		t.Join();
		t2.Join();

		Console.WriteLine("counter:{0}", counter);
	}
}