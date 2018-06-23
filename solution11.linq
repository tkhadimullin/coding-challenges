<Query Kind="Program" />

#region mapping
public static List<Tuple<string, string>> mapping = new List<Tuple<string, string>> {
		new Tuple<string, string> ( "A", "4"),
		new Tuple<string, string> ( "B", "6"),
		new Tuple<string, string> ( "E", "3"),
		new Tuple<string, string> ( "I", "1"),
		new Tuple<string, string> ( "L", "|"),
		new Tuple<string, string> ( "M", "(V)"),
		new Tuple<string, string> ( "N", "(\\)"),
		new Tuple<string, string> ( "O", "0" ),
		new Tuple<string, string> ( "S", "5" ),
		new Tuple<string, string> ( "T", "7" ),
		new Tuple<string, string> ( "V", "\\/"),
		new Tuple<string, string> ("W", "`//" )
};
#endregion

static class Extensions
{
	public static List<char> ToCharSet(this IEnumerable<string> list)
	{
		var sb = new List<char>();
		foreach (var element in list.SelectMany(c => c.ToCharArray()).Distinct().OrderBy(c => c)) sb.Add(element);
		return sb;
	}

	public static TranslateDirection FigureDirection(this string s, List<Tuple<string, string>> mapping)
	{
		var charSet = (new List<string> { s }).ToCharSet();
		var sourceSetIntersection = mapping.Select(m => m.Item1).ToCharSet().Intersect(charSet).ToList();
		var leetSetIntersection = mapping.Select(m => m.Item2).ToCharSet().Intersect(charSet).ToList();
		if (sourceSetIntersection.Count == leetSetIntersection.Count) throw new Exception("Could not detect translation direction");

		Func<Tuple<string, string>, Tuple<string, string>> func;
		if (sourceSetIntersection.Count > leetSetIntersection.Count)
			func = (src) => new Tuple<string, string>(src.Item1, src.Item2);
		else
			func = (src) => new Tuple<string, string>(src.Item2, src.Item1);
		return new TranslateDirection(func, mapping);
	}
}
class TranslateDirection
{
	Dictionary<string, string> translationMap = new Dictionary<string, string>();

	public TranslateDirection(Func<Tuple<string, string>, Tuple<string, string>> buildFunc, List<Tuple<string, string>> mapping) {
		foreach (var element in mapping)
		{
			var e = buildFunc(element);
			translationMap.Add(e.Item1, e.Item2);
		}
	}

	private Tuple<string, string> Trans1ate(string ss)
	{
		while (!translationMap.ContainsKey(ss))
		{
			if(ss.Length == 1) return new Tuple<string, string>(ss, ss);
			return Trans1ate(ss.Substring(0, ss.Length-1));
		};
		return new Tuple<string, string>(ss, translationMap[ss]);
	}
	
	public StringBuilder Translate(string src, StringBuilder sb = null) {
		sb = sb ?? new StringBuilder();
		if(src.Length == 0) return sb;
		var r = Trans1ate(src);
		sb.Append(r.Item2);
		return Translate(src.Substring(r.Item1.Length), sb);
	}
}

void Main()
{	
	var input = "6451C";
	var direction = input.FigureDirection(mapping);
	Console.WriteLine(direction.Translate(input));
}