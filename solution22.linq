<Query Kind="Program" />

public static class Extensions
{
	private static int ToInt(this List<int> digits, int radix = 10) {
		int r = 0;
		digits.Reverse();
		for(int i = 0; i<digits.Count; i++) 
		{
			r+= digits[i]*(int)Math.Pow(radix, i);
		}
		return r;
	}
	private static List<int> Digits(this int number, int radix = 10)
	{
		List<int> digits = new List<int>();
		while (number > 0)
		{
			int digit;
			number = Math.DivRem(number, 10, out digit);
			digits.Add(digit);
		}		
		digits.Reverse();
		return digits;
	}

	public static int Compl(this int number, int complTo = 10, int radix = 10) {
		var res = new List<int>();
		foreach (var n in number.Digits(radix))
		{
			res.Add(complTo - n);
		}
		return res.ToInt(radix);
	}
}

public int Sub(int a, int b)
{
	bool neg = false;
	if (a < 0) { throw new NotImplementedException("Can't be bothered, sorry"); }
	if (b < 0) { throw new NotImplementedException("Can't be bothered, sorry"); }
	if (b > a) {
		(a,b) = (b,a);
		neg = !neg;
	}
	var r = (a.Compl(9) + b).Compl(9);
	return neg ? -1 * r : r;
}
void Main()
{
	Sub(100,-1).Equals(101).Dump();
	//Sub(218, 873).Equals(218-873).Dump();
	//Sub(48032, 391).Equals(48032-391).Dump();	
}