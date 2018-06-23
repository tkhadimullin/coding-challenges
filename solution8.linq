<Query Kind="Program" />

const int MAX_X = 80;
const int MAX_Y = 25;
char?[,] frameBuffer = new char?[MAX_Y, MAX_X];

public static class Extensions
{
	public static double ToRadian(this double degree) {
		return Math.PI*degree/180;
	}
	public static void Print(this char?[,] fb)
	{
		for (var i = 0; i < 25; i++)
		{
			for (var j = 0; j < 80; j++)
			{
				Console.Write(fb[i, j]??' ');
			}
			Console.WriteLine();
		}
	}
	public static int ToInt(this double f) {
		return Convert.ToInt32(f);
	}
}

void DrawCenter(Tuple<int, int> startPoint) {
	frameBuffer[startPoint.Item1, startPoint.Item2] = '0';
}
void DrawLine(double angle, Tuple<int, int> startPoint, int length)
{
	var xx = startPoint.Item2;
	var yy = startPoint.Item1;
	for (int l = 1; l <= length; l++)
	{
		var y = (l * Math.Sin(angle) + startPoint.Item1).ToInt();
		var x = (l * Math.Cos(angle) + startPoint.Item2).ToInt();		
		frameBuffer[y, x] = '*';
	}
}

void Main()
{
	var hourHandLength = 2;
	var minuteHandLength = 3;
	var centerPoint = new Tuple<int,int>(12, 40);//just chose something that looks alright
	var timeString="5:00";//var time = Console.ReadLine();//use HH:mm here
	var time = timeString.Split(':').Select(int.Parse).ToList();	
	DrawLine((0.5*(60*time[0] + time[1])-90).ToRadian(), centerPoint, hourHandLength);
	DrawLine((6.0*time[1]-90).ToRadian(), centerPoint, minuteHandLength);
	DrawCenter(centerPoint);
	frameBuffer.Print();
}