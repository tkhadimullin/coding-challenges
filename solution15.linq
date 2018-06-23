<Query Kind="Program" />

(int, string) To12HrTime(int hh) {
	var isPm = hh >= 12;
	if (isPm) {
		hh = (hh - 12) > 0? hh-12 : 12;
	}
	return (hh, isPm?"PM":"AM");
}
string ToWords(int number, bool isMinute)
{
	var words = new StringBuilder();
	var unitsMap = new[] { "twelve", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
	var tensMap = new[] { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
	if (isMinute && number == 0) { return ""; }
	if (isMinute && number < 10) { words.Append("oh "); }	
	if (number < 20)
		words.Append(unitsMap[number]);
	else
	{
		words.Append(tensMap[number / 10]);
		if ((number % 10) > 0)
			words.Append("-");
			words.Append(unitsMap[number % 10]);
	}
	if (isMinute) { words.Append(" ");}
	return words.ToString();
}

void Main()
{
	var input = "00:01";
	var m = Regex.Match(input, @"(\d\d):(\d\d)$");
	var (hh24, mm) = (int.Parse(m.Groups[1].Value), int.Parse(m.Groups[2].Value));
	var (hh12, ampm) = To12HrTime(hh24);

	Console.Write($"{ToWords(hh12, false)} {ToWords(mm, true)}{ampm}");	
}

// Define other methods and classes here