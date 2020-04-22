using System;

class Test : IDisposable
{
	public Test()
	{
		Console.WriteLine("Test");
	}

	~Test()
	{
		Console.WriteLine("~Test");
	}

	public void Dispose()
	{
		Console.WriteLine("Dispose");
		GC.SuppressFinalize(this);
	}
}

class Program
{
	static void Main()
	{
		//using (Test o = new Test())
		//{

		//}
		Test o = null;
		try
		{
			o = new Test();
		}
		finally
		{
			if (o != null)
			{
				o.Dispose();
			}
		}

		//o.Dispose();
		
		//o = null;

		//release delete free
		//o = null;
		//GC.Collect();
		//GC.WaitForPendingFinalizers();
		Console.WriteLine("End.");
	}
}