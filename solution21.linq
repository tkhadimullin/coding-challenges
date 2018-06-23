<Query Kind="Program" />

public static class Extensions
{
	private static int ToInt(this List<int> digits, int radix = 10)
	{
		int r = 0;
		digits.Reverse();
		for (int i = 0; i < digits.Count; i++)
		{
			r += digits[i] * (int)Math.Pow(radix, i);
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

	public static int Compl(this int number, int radix = 10)
	{
		var res = new List<int>();
		foreach (var n in number.Digits(radix))
		{
			res.Add(radix - n - 1);
		}
		return res.ToInt(radix);
	}
}

public static int Neg(int a)
{
	var r = 0;
	if(a >= 0)
		for (int i = 0; i < a; i++) r += (int.MinValue + int.MaxValue);
	else
		for (int i = a; i < 0; i++) r += 1;
	return r;
}
public static int Abs(int a) { return (a>=0)? a : Neg(a); }
//public static int Sub(int a, int b) { return Add(a, Neg(b)); }
public static int Sub(int a, int b)
{
	bool neg = false;
	if (a < 0) { a = Math.Abs(a).Compl(); }
	if (b < 0) { b = Math.Abs(b).Compl(); }
	if (b > a)
	{
		(a, b) = (b, a);
		neg = !neg;
	}
	var r = (a.Compl() + b).Compl();
	return neg ? -1 * r : r;
}

public static int Add(int a, int b) { return a + b; }
public static int Mul(int a, int b)
{
	if (b < 0) { b = Neg(b); a = Neg(a); }
	Func<int, int, int> f = (a >= 0) ? (Func<int, int, int>)((x,y) => Add(x, y)) : (Func<int, int, int>)((x, y) => Sub(x, y));	
	var r = 0;
	foreach(var i in Enumerable.Range(1,b)) r = Add(r, a);
	return r;
}
public static int Div(int a, int b) {
	var remainder = Abs(a) ;
	var r = 0;
	if(b==0) throw new Exception("Not - defined");
	var step = Neg(Abs(b));
	while (remainder > 0) {
		remainder = Add(remainder, step);
		r = Add(r, 1);
	}
	if(remainder<0) throw new Exception("Non - integral answer");
	if(a<0 && b<0) return r;
	if(a<0 && b>0) return Neg(r);
	if(a>0 && b<0) return Neg(r);
	if(a>0 && b>0) return r;
	throw new Exception();
}
public static int Exp(int a, int b)
{
	if(b<0) throw new Exception("Non - integral answer");
	var r = 1;
	foreach (var i in Enumerable.Range(1,b)) { r = Mul(r, a); }
	return r;
}
public static string Calc(string input)
{
	input = input.Replace(" ", "");
	var matches = Regex.Match(input, @"([\-]?\d+)([+\-*\/^]){1}([\-]?\d+)").Groups;
	var left = int.Parse(matches[1].Value);
	var op = matches[2].Value;
	var right = int.Parse(matches[3].Value);
	try
	{
		switch (op)
		{
			case "+": return Add(left, right).ToString();
			case "-": return Sub(left, right).ToString();
			case "*": return Mul(left, right).ToString();
			case "/": return Div(left, right).ToString();
			case "^": return Exp(left, right).ToString();
			default: throw new Exception();
		}
	}
	catch(Exception ex) {
		return ex.Message;
	}
}

void Main()
{
	/*Calc("12 + 25").Equals("37").Dump();
	Calc("- 30 + 100").Equals("70").Dump();
	Calc("100 - 30").Equals("70").Dump();*/
	Calc("100 - -30").Equals("130").Dump();
	Calc("- 25 - 29").Equals("-54").Dump();
	Calc("- 41 - -10").Equals("-31").Dump();
	/*Calc("9 * 3").Equals("27").Dump();
	Calc("9 * -4").Equals("-36").Dump();
	Calc("- 4 * 8").Equals("-32").Dump();
	Calc("- 12 * -9").Equals("108").Dump();
	Calc("100 / 2").Equals("50").Dump();
	Calc("75 / -3").Equals("-25").Dump();
	Calc("- 75 / 3").Equals("-25").Dump();
	Calc("7 / 3").Equals("Non - integral answer").Dump();
	Calc("0 / 0").Equals("Not - defined").Dump();
	Calc("5 ^ 3").Equals("125").Dump();
	Calc("- 5 ^ 3").Equals("-125").Dump();
	Calc("- 8 ^ 3").Equals("-512").Dump();
	Calc("- 1 ^ 1").Equals("-1").Dump();
	Calc("1 ^ 1").Equals("1").Dump();
	Calc("0 ^ 5").Equals("0").Dump();
	Calc("5 ^ 0").Equals("1").Dump();
	Calc("10 ^ -3").Equals("Non - integral answer").Dump();*/
}