<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Namespace>System.Numerics</Namespace>
</Query>


public static class Extensions
{
	public static BigInteger GetGCD(this (BigInteger, BigInteger) pair)
	{
		var a = pair.Item1; 
		var b = pair.Item2;
		while (b != 0)
		{
			BigInteger temp = b;
			b = a % b;
			a = temp;
		}
		return a;
	}
}

void Main()
{
	var input = new List<(BigInteger, BigInteger)>(){
		(4, 8),
		(1536, 78360),
		(51478, 5536),
		(46410, 119340),
		(7673, 4729),
		(4096, 1024)
	};
	foreach (var pair in input)
	{
		var gcd = pair.GetGCD();
		Console.WriteLine($"{pair.Item1/gcd} {pair.Item2/gcd}");
	}	
}