<Query Kind="Program" />

public class MyDate
{
	public DateTime dt { get; set; }
	public bool IsFriday()
	{
		return dt.DayOfWeek == DayOfWeek.Friday;
	}
	public bool IsFriday13th()
	{
		return IsFriday() && dt.Day == 13;
	}
	public MyDate(int y, int m, int d) {
		dt = new DateTime(y, m, d);
	}
	public MyDate AddDays(int d) {
		dt = dt.AddDays(d);
		return this;
	}
	
	public bool LessEquals(MyDate other) {
		return this.dt <= other.dt;
	}
	
}
void Main()
{
	var t = 10;
	var inputs = new List<(int, int, int, int, int, int)>(t) {
		(01, 01, 1900, 31, 12, 9999),
		(13, 02, 2009, 13, 02, 2009),
		(01, 01, 2009, 13, 02, 2009),
		(13, 02, 2009, 14, 02, 2009),
		(04, 02, 1923, 24, 09, 5715),
		(31, 01, 7365, 02, 08, 8570),
		(29, 09, 2206, 20, 02, 2273),
		(15, 08, 1922, 17, 04, 6540),
		(31, 03, 2720, 16, 06, 7469),
		(10, 05, 8077, 14, 07, 9533)
	};
	/* //use this code for hackerrank submissions pipeline
	var t = int.Parse(Console.ReadLine());
	var inputs = new List<(int, int, int, int, int, int)>(t);
	for (var i = 0; i < t; i++) {
		var matches = Regex.Match(Console.ReadLine(), @"(\d+ ?)(\d+ ?)(\d+ ?)(\d+ ?)(\d+ ?)(\d+ ?)");
		inputs.Add(	(int.Parse(matches.Groups[1].Value),
					int.Parse(matches.Groups[2].Value),
					int.Parse(matches.Groups[3].Value),
					int.Parse(matches.Groups[4].Value),
					int.Parse(matches.Groups[5].Value),
					int.Parse(matches.Groups[6].Value))
				);
	}*/
	
	foreach (var e in inputs)
	{
		var c = 0;
		var step = 1;
		var d1 = new MyDate(e.Item3, e.Item2, e.Item1);
		var d2 = new MyDate(e.Item6, e.Item5, e.Item4);
		while (d1.LessEquals(d2))
		{
			if (d1.IsFriday()) step = 7;
			if (d1.IsFriday13th()) c++;
			try { d1 = d1.AddDays(step);} catch { break;}
		}
		Console.WriteLine(c);
	}
}