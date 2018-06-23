<Query Kind="Program" />

public sealed class A
{
	public Func<string, int?, int> CalculateFunc { get; set;}
	public event Func<string, int?, int> OnCalculate;
	
	public int Foo(string a, int? b = null) {
		if(OnCalculate != null) return OnCalculate(a,b); 
		return CalculateFunc(a, b);
	}
}
void Main()
{
	var a = new A();
	
	// write code to calculate sum of two integers
	try
	{	        
		Console.WriteLine(a.Foo(12.ToString(), 12));
	}
	catch
	{
		
	}
	
}