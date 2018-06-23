<Query Kind="Program" />

public static int getNum(int size, int x, int y, bool ccw = false)
{
	x = 2 * x - size + 1;
	y = 2 * y - size + 1;
	int n = Math.Max(Math.Abs(x), Math.Abs(y));
	int p = (x + y) / 2;
	if (x < y && !ccw) p = 2 * n - p;
	if (x > y && ccw) p = 2 * n - p;
	return size * size - n * n - n + p;
}
public static int getLength(int num)
{
	int length = 0;
	while (num > 0)
	{
		length++;
		num = num / 10;
	}
	return length;
}

void Main()
{
	var n = 5;
	var length = getLength(n*n);
	for (int y = 0; y < n; y++)
	{
		for (int x = 0; x < n; x++)
			Console.Write("{0} ", getNum(n, x, y, true).ToString().PadLeft(length, ' '));
		Console.WriteLine();
	}
}

// https://www.reddit.com/r/dailyprogrammer/comments/6i60lr/20170619_challenge_320_easy_spiral_ascension/