<Query Kind="Program" />

static class Extensions {
	public  static string AlignCenter(this string input, int length) { 
		var sb = new StringBuilder();
		var pad = (length - input.Length) / 2;//since we generate only odd numbers this is always going to be an integer
		return sb.Append(' ', pad).Append(input).Append(' ', pad).ToString();
	}
	
	public static string Repeat(this char input, int num) {
		var result = new StringBuilder(num);
		return result.Append(input, num).ToString();
	}
}

void Main()
{
	var height = 7;
	var baseLength = 2*height - 1;
	var lines = new List<string>(height);	
	foreach (var i in Enumerable.Range(1, baseLength).Where(x => x%2 == 1))
	{
		var line = new StringBuilder();
		foreach (var j in Enumerable.Range(1, height))
			line.Append('*'.Repeat(i).AlignCenter(baseLength)).Append(' ');
		lines.Add(line.ToString());
	}
	lines.ForEach(Console.WriteLine);
}