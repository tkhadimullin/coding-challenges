<Query Kind="Program" />

void Main()
{
	var inputStr = "4 5 -1 -2 -7 2 -5 -3 -7 -3 1";
	var input = Regex.Split(inputStr, @"[ ]+").Select(x => int.Parse(x));
	var result = new Dictionary<int, (int, int, int)>();
	foreach (var first in input)
	{
		foreach (var second in input.Except(new List<int> { first }))
		{
			foreach (var third in input.Except(new List<int> { first, second }))
			{
				var hash = first.GetHashCode() * second.GetHashCode() * third.GetHashCode();
				if (first + second + third == 0 && !result.ContainsKey(hash)) {
					result.Add(hash, (first, second, third));
				}
			}
		}
	}
	result.Select(x => x.Value).Dump();
}
