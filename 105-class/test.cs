using System;

namespace NETTest
{
	class SomeType
	{
		class SomeNestedType
		{}

		//常数、只读字段、静态字段
		const    Int32 SomeConstant      = 1;
		readonly Int32 SomeReadOnlyField = 2;
		static   Int32 SomeReadWriteField = 3;
		
		static SomeType()
		{
			Console.WriteLine("In Class ctor");
		}

		public SomeType()
		{
			Console.WriteLine("In Object default ctor");
		}
		public SomeType(Int32 v)
		{
			Console.WriteLine("In Object ctor");
			m_nInstanceVal = v;
		}

		public void  TestVar()
		{}

////////////
		public   Int32 m_nInstanceVal;
		public Int32 SomeProp
		{
			get 
			{
				return m_nInstanceVal;
			}
			set
			{
				m_nInstanceVal = value;
			}
		}

		public Int32 SomeProp2 {get;set;}

		//o["fred"] = 2022;
		//Console.WriteLine("m_nInstanceVal : {0}",o.m_nInstanceVal);
		public Int32 this[String key]
		{
			get
			{
				if (key == "fred")
				{
					return m_nInstanceVal;
				}
				return 0;
			}
			set
			{
				if (key == "fred")
				{
					m_nInstanceVal = value;
				}
			}
		}

		//event(0)
		public event EventHandler SomeEvent;
		public void TriggerEvent()
		{
			if (SomeEvent != null)
			{
				SomeEvent(this,null);
			}
		}
	}
	public class Program
	{
		//event(1)
		static void MyEventHandler(object sender,EventArgs args)
		{
			Console.WriteLine("In MyEventHandler");
		}
		static void Main()
		{
			//Console.WriteLine("Hi NET");
			SomeType o = new SomeType();
			//SomeType o2 = new SomeType();
			Console.WriteLine("m_nInstanceVal before: {0}",o.m_nInstanceVal);
			o.SomeProp = 2020;
			Console.WriteLine("SomeProp: {0}",o.SomeProp);
			Console.WriteLine("m_nInstanceVal after: {0}",o.m_nInstanceVal);
			Console.WriteLine("SomeProp2: {0}",o.SomeProp2);
			o.SomeProp2 = 2021;
			Console.WriteLine("SomeProp2: {0}",o.SomeProp2);
			o["fred"] = 2022;
			Console.WriteLine("m_nInstanceVal : {0}",o.m_nInstanceVal);
			//event(2)
			o.SomeEvent += MyEventHandler;
			o.TriggerEvent();
		}
	}
}