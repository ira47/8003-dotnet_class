using System;

//方法 字段 类型
//private、protected、public、internal、protected internel (or)

//仅仅类型
//abstract、sealed

//字段
//static、readonly

//方法修饰
//实例方法
//static、virtual 、new、override、abstract、sealed

abstract class BaseClass
{
	public virtual void vf()
	{
		Console.WriteLine("In BaseClass vf");
	}

	public virtual void vf_new()
	{
		Console.WriteLine("In BaseClass vf_new");
	}

	public abstract void vf_abstract();

	public sealed override string ToString()
	{
		Console.WriteLine("In BaseClass vf_sealed");
		return "BaseClass_ToString";
	}
}

internal class DerivedClass : BaseClass
{
	public override void vf()
	{
		Console.WriteLine("In DerivedClass vf");
	}
	public new void vf_new()
	{
		Console.WriteLine("In DerivedClass vf_new");
	}
	public override void vf_abstract()
	{
		Console.WriteLine("In DerivedClass vf_abstract");
	}
	/*
	public sealed override string ToString()
	{
		Console.WriteLine("In BaseClass vf_sealed");
		return "BaseClass_ToString";
	}
	*/
}

class Test
{
	static void Main()
	{
		System.Console.WriteLine("Hi");
		DerivedClass o2 = new DerivedClass();
		BaseClass    o  = o2;
		o.vf();
		o.vf_new();
		o.vf_abstract();
		o.ToString();

		o2.vf();
		o2.vf_new();
		o2.vf_abstract();
		o2.ToString();
	}
}