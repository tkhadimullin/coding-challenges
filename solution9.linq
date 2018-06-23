<Query Kind="Program" />

public static class Extensions
{
	public static List<int> Increment(this List<int> digits, int b, int position = 0)
	{
		if (position >= digits.Count) return digits;//to prevent index out of bounds exception silently do nothing
		if (digits[position] < (b - 1))
		{
			digits[position]++;
		} else {
			digits[position] = 0;
			digits.Increment(b, position + 1);
		}
		return digits;
	}
}

public bool IsMagic(char[] numChar)
{
	var left = 0; //0 is identity of xor
	var right = 0;
	for (int i = 0; i < (numChar.Length / 2); i++)
	{
		var leftL = numChar[i];
		var rightL = numChar[numChar.Length - i];
		left = left ^ (leftL);
		right = right ^ (rightL);
		continue;
	}
	var isMagic = left ^ right;
	return isMagic == 0;
}

public IEnumerable<Tuple<int,List<int>>> GetHalfTicketSums(int length, int b, List<int> startNumber = null, int? start = null)
{
	var number = new List<int>();
	if (start != null) {
		int[] tmp = new int[length];
		startNumber.CopyTo(tmp);
		number.AddRange(tmp);
	}
	else
	{
		number.AddRange(Enumerable.Repeat(0, length)); // <- the thing I've learned today: a cool way of initializing a list with repeating values
	}

	var max = Math.Pow(b, length);//go over all possible digit combinations in a number
	for (var i = 0; i < max; i++)
	{
		number.Increment(b);//build a next number by incrementing the current one
		yield return new Tuple<int,List<int>>(i, number);
	}
}

public string CountMatches(int length, int b) {
	var result = 0;
	var l = length/2;//there should be better ways splitting number in two...
	if(l == 0) l = 1;//...but I just can't be bothered
	foreach (var left in GetHalfTicketSums(l, b))
		foreach (var right in GetHalfTicketSums(l, b, left.Item2, left.Item1))		
			if (left.Item2.Sum() == right.Item2.Sum()) result++;
	return result.ToString();
}

void Main()
{
	var n = 8; // Length of ticket
	var b = 10; // Character set b^(n/2)
	n = n/2;
	Console.Write(CountMatches(n, b));

	for (var i = 1L; i < n; i++)
	{
		for (var j = 1L; j < n; j++) {
			var l = 1L << (Math.Pow())
			isMagicNumber (l.tostring());
			
		}
	}
}