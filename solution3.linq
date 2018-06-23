<Query Kind="Program" />

void Main()
{
	var input = "(((zbcd)(((e)fg))))";
	var outputMask = input.ToCharArray().Select(c => true).ToList();
	var matches = new List<Tuple<int, int>>();
	var remove = new List<Tuple<int, int>>();
	var p = new Stack<int>();
	for (int i = 0; i < input.Length; i++)
	{
		switch (input[i]) {
			case '(':
				p.Push(i);break;
			case ')': 
				matches.Add(new Tuple<int,int>(p.Pop(), i));//if we cannot pop the expression is unbalanced. 
				break;		
		}
	}
	matches = matches.OrderBy(x => x.Item1).ToList();
	for(var i = 1; i < matches.Count; i++) {
		var left = matches[i].Item1-1 == matches[i-1].Item1;
		var right = matches[i].Item2 + 1 == matches[i - 1].Item2;
		if (left && right) { 
			outputMask[matches[i].Item1] = false;
			outputMask[matches[i].Item2] = false;
		}
	}
	var output = new StringBuilder();
	for (var i = 0; i < input.Length; i++)
	{
		if(outputMask[i]) output.Append(input[i]);
	}
	Console.WriteLine(output);
}
