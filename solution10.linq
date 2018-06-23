<Query Kind="Program">
  <Namespace>System.Collections.Concurrent</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

static string GetColumn(char[,] src, int startRow, int startCol, int? length = null)
{
	var rows = src.GetLength(0);
	var sb = new StringBuilder();
	length = length ?? rows;
	var bottom = (startRow + length) <= rows ? length : rows - startRow;
	for (var j = startRow; j < bottom; j++)
	{
		sb.Append(src[j, startCol]);
	}
	return sb.ToString();
}

static string GetLine(char[,] source, int startRow, int startCol, int? length = null)
{
	var cols = source.GetLength(1);
	length = length ?? cols;
	var sb = new StringBuilder();
	var right = (startCol + length) <= cols ? length : cols - startCol;
	for (var i = startCol; i < right; i++)
	{
		sb.Append(source[startRow, i]);
	}
	return sb.ToString();
}

static Tuple<int, int> LocatePattern(char[,] haystack, char[,] needle)
{
	var rows = haystack.GetLength(0); // a cool way of discovering array dimensions
	var pattern = GetLine(needle, 0, 0);
	// discover pattern dimensions
	var patternW = needle.GetLength(0);
	var patternH = needle.GetLength(1);
	//do the search
	var cb = new ConcurrentBag<Tuple<int, int>>();
	Parallel.For(0, rows - 1, i =>
	{		
		var line = GetLine(haystack, i, 0);
		var location = line.IndexOf(pattern, StringComparison.Ordinal);
		var matchedCols = 0;
		if (location >= 0)
		{

			for (var j = location; j < (location + patternW); j++)
			{
				if (GetColumn(haystack, i, j, patternH) == GetColumn(needle, i, j - location))
					matchedCols++;
			}
		}
		if (matchedCols == patternW)
			cb.Add(new Tuple<int, int>(i, location));
	});
	return cb.Count == 0 ? null : cb.First();
}
static void Main()
{
	var haystack = new[,] {
						{'1','3','6','9','3','4'},
						{'1','3','6','9','3','4'},
						{'1','3','6','9','1','2'},
						{'1','3','6','9','3','4'}
					};
	var needle = new[,] {
						{'1','2'},
						{'3','4'}
					};

	var loc = LocatePattern(haystack, needle);
	if (loc != null)
		Console.WriteLine($"Found at row [{loc.Item1}], col [{loc.Item2}]");
	else
		Console.WriteLine("Pattern not found");

}