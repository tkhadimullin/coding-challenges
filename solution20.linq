<Query Kind="Program" />

static class Extensions
{
	public static List<int> Sieve(this List<int> range, int matching, int start, int index)
	{
		var remainder = new List<int>();
		remainder.Add(range[0]);
		for (var i = 1; i < range.Count; i++) if ((i + 1) % start != 0) remainder.Add(range[i]);
		if (range[index] < matching && !remainder.SequenceEqual(range))
			return remainder.Sieve(matching, remainder[index], index + 1);
		if (range[index] == matching) 
			Console.WriteLine($"{matching} is a lucky number");
		else 
			Console.WriteLine($"{range[index-1]}<{matching}<{range[index]}");
		return remainder;
	}
}
void Main()
{
	var n = 997;
	Enumerable.Range(1, int.MaxValue/256).ToList().Sieve(n, 2, 1);
	
}