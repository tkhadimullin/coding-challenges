<Query Kind="Program" />

void Main()
{
	

	foreach (var i in Enumerable.Range(1, 100))
	{
		if (fizz(i) && buzz(i)) {
			Console.WriteLine("FizzBuzz");
		}
		else if(fizz(i)){
			Console.WriteLine("Fizz");
		}
		else if (buzz(i))
		{
			Console.WriteLine("Buzz");
		}
		else {
			Console.WriteLine(i);
		}
	}
}

class Fizz : FizzBuzzPrinter
{
	protected override string Word {get { return "Fizz"}};
}

abstract class FizzBuzzPrinter
{
	protected abstract string Word { get;}
	
	void Print() {
		Console.WriteLine(Word);
	}

	public static FizzBuzzPrinter GetPrinter(int number)
	{
		Func<int, bool> fizz = (i) => (i % 3) == 0;
		Func<int, bool> buzz = (i) => (i % 5) == 0;
		
		if (fizz(number) && buzz(number)) return new FizzBuzz(number.ToString());		
		if (fizz(number)) return new Fizz(number.ToString());
		if (buzz(number)) return new Buzz(number.ToString());
	}
}