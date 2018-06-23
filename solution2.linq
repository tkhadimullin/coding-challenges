<Query Kind="Program" />

string[] days = { "first", "second", "third", "fourth", "fifth", "sixth", "seventh", "eighth", "ninth", "tenth", "eleventh", "twelfth" };
string[] gifts = {
	"Partridge in a Pear Tree",
	"Turtle Doves",
	"French Hens",
	"Calling Birds",
	"Golden Rings",
	"Geese a Laying",
	"Swans a Swimming",
	"Maids a Milking",
	"Ladies Dancing",
	"Lords a Leaping",
	"Pipers Piping",
	"Drummers Drumming"
};
void Day(int i, Stack<string> giftStack)
{
	if (i == days.Length) return;
	if (i == 1) giftStack.Push($"and {giftStack.Pop()}");
	giftStack.Push($"{i+1} {gifts[i]}");
	Console.WriteLine($"\r\nOn the {days[i]} day of Christmas\r\nmy true love sent to me:");
	foreach (var line in giftStack)
		Console.WriteLine(line);
	Day(i+1, giftStack);// as per @andrewsav's recommendation ;)
}
void Main()
{
	Day(0, new Stack<string>());
}