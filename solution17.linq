<Query Kind="Program" />

int Digits(double n) {
	if(n % 1 > 0) return Digits(n*10);
	return Convert.ToInt32(Math.Floor(Math.Log10(n) + 1));
}
void Main()
{
	var number = Digits(123.45);
	
}

// Define other methods and classes here
