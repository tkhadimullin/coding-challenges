<Query Kind="Program">
  <Namespace>System.Net</Namespace>
</Query>

public static class Extensions
{
	private static void Check(char[] s, int position, int[] buffer, ref int bufferPointer)
	{
		if (s[position] != s[position - 1])
		{
			bufferPointer++;
		}
		buffer[bufferPointer]++;
	}
	public static int[] ToPattern(this char[] s)
	{
		if (s.Length <= 0)
		{
			return new int[] {0};
		}
		int[] buffer = new int[s.Length];
		int[] result = null;
		int bufferPointer = 0;
		buffer[bufferPointer] = s.Length > 0 ? 1 : 0;
		for (int i = 1; i < s.Length - 1; i++)
		{
			Check(s, i, buffer, ref bufferPointer);			
		}
		Check(s, s.Length - 1, buffer, ref bufferPointer);
		int index = Array.FindIndex(buffer, x => x == 0);
		index = index> 0 ? index: buffer.Length; 
		result = new int[index];
		Array.Copy(buffer, result, index);
		return result;
	}
	public static bool Matches(this string s, int[] p) {
		return s.ToCharArray().ToPattern().ToOutString().Contains(p.ToOutString());
	}
	public static string ToOutString(this int[] input)
	{
		var result = new StringBuilder();
		foreach (var i in input)
		{
			result.Append(i.ToString());
		}
		return result.ToString();
	}
}

void Main()
{
	List<string> dictionary = null;
	//var pattern = Console.ReadLine().ToUpperInvariant().ToCharArray().ToFreqPattern();
	var pattern = "XXYYX".ToCharArray().ToPattern();
	using (WebClient client = new WebClient())
	{
		client.Proxy = new WebProxy("172.27.24.30", 3128);
		dictionary = client.DownloadString("https://raw.githubusercontent.com/dolph/dictionary/master/enable1.txt").Split('\r', '\n').Select(x => x.Trim()).ToList();
	}
	dictionary.Where(x => x.Matches(pattern))
				.ToList()
				.ForEach(x => Console.WriteLine(x));
}