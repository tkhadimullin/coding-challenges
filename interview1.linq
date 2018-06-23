<Query Kind="Program" />

interface I1 { 
	void Foo();
	void Bar();
	void Baz();
}
interface I2
{
	void Baz();
	void Qux();
}
class A: I1
{
	public A():this(false) {}
	public A(bool silent) { if(!silent) Console.WriteLine("A ctor"); }
	
	public virtual void Foo() { Console.WriteLine("A Foo"); }
	public void Bar() { Console.WriteLine("A Bar"); }
	public virtual void Baz() { Console.WriteLine("A Baz"); }	
}
class B : A, I2
{
	public B():this(false) { }
	public B(bool silent) { if(!silent) Console.WriteLine("B ctor"); }
	
	public override void Foo() { Console.WriteLine("B Foo"); }
	public void Bar() { Console.WriteLine("B Bar"); }
	public new void Baz() { Console.WriteLine("B Baz");	}
	public void Qux() { Console.WriteLine("B Qux");	}
	void I2.Qux() { Console.WriteLine("I2 Qux");	}
}

void Main()
{
	//for each line below specify what the output would be. Don't forget constructor output!
	B obj1 = new A();
	obj1.Foo();		 
	obj1.Bar();		 
	obj1.Baz();
					 
	B obj2 = new B();
	obj2.Foo();
	obj2.Bar();
	obj2.Baz();
					 
	A obj3 = new B();
	obj3.Foo();
	obj3.Bar();
	obj3.Baz();
	//obj3.Qux();//this line is breaking the build and needs to be fixed
	
	I1 o1 = new B(silent: true);
	I2 o2 = new B(true);
	o1.Baz();
	o2.Baz();
	//suggest a way to abstract usage of `Console.WriteLine` in case we want to swap out out for Log4Net later
}