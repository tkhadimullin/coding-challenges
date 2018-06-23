<Query Kind="Program" />

private void Step(string src, string dest, int i = 0) { 
	if(src == dest) return;	
	var step = new StringBuilder(src);
	if (step[i] != dest[i])
	{
		step[i] = dest[i];
		Console.WriteLine(step.ToString());
	}
	Step(step.ToString(), dest, ++i);		
}

void Main()
{
	var src = Console.ReadLine();
	var dst = Console.ReadLine();
	if(src.Length != dst.Length) return;
	Console.WriteLine(src);	
	Step(src, dst);
}

// Define other methods and classes here
