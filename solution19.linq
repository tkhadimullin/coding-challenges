<Query Kind="Program" />

static class Extensions
{
	public static bool Equals(this (int, int) i, (int, int) other) {
		return i.Item1 == other.Item1 && i.Item2 == other.Item2;
	}

	public static bool Gt(this (int, int) i, (int, int) other)
	{
		return i.Item1 >= other.Item1 && i.Item2 >= other.Item2;
	}

	public static bool Lt(this (int, int) i, (int, int) other)
	{
		return i.Item1 <= other.Item1 && i.Item2 <= other.Item2;
	}
	public static void Swap((int, int) a, (int, int) b)
	{
		var tmp = a;
		a = b;
		b = tmp;
	}
}
class Puzzle
{
	private int _size;
	private string _targetState;
	private List<List<int?>> _state;
	private (int,int) _gap;
	private (int,int) _previousGap;
	private List<(int,int)> _lockedTiles;
	public StringBuilder TransitionLog;
	public readonly (int,int) Center;
	
	public override string ToString() {
		var result = new StringBuilder(_size);
		foreach (var row in _state)
		{
			foreach (var col in row)
				result.Append(col.HasValue ? col.ToString() : "*");
			result.Append("\r\n");
		}
		return result.ToString();
	}
	public Puzzle(string input) {	
		TransitionLog = new StringBuilder();
		_lockedTiles = new List<(int,int)>();
		_size = Convert.ToInt32(Math.Sqrt(input.Length));
		Center = (_size/2,_size/2);
		//set target state for future reference
		var s = new StringBuilder(input.Length);
		Enumerable.Range(1, _size * _size - 1).ToList().ForEach(x => s.Append(x));
		s.Append("*");
		_targetState = s.ToString();
		
		_state = new List<List<int?>>(_size);
		//parse state
		for (int i=0;i<_size; i++)
		{
			var row = new List<int?>(_size);
			for (int j = 0; j < _size; j++)
			{	
				if (int.TryParse(input[i * _size + j].ToString(), out int tmp)) {
					row.Add(tmp);
				} else {
					_gap = (i, j);
					row.Add((int?)null);
				}
			}
			_state.Add(row);
		}
	}
	public bool IsFinal()
	{		
		return this.ToString() == _targetState;
	}
	private bool SwapWith((int, int) after)
	{
		if(_lockedTiles.Any(t => t.Equals(after))) return false;
		_state[_gap.Item1][_gap.Item2] = _state[after.Item1][after.Item2];
		_state[after.Item1][after.Item2] = null;
		_previousGap = _gap;
		_gap = after;
		return true;
	}
	public bool U(int? boundary = null) {
		if(_previousGap.Equals((_gap.Item1 - 1, _gap.Item2)) || _gap.Item1==(boundary??0)) return false;//throw new Exception("invalid move");
		TransitionLog.Append("u");
		return SwapWith((_gap.Item1 - 1, _gap.Item2));
	}
	public bool D(int? boundary = null)
	{
		if (_previousGap.Equals((_gap.Item1 + 1, _gap.Item2)) || _gap.Item1 == (boundary??_size - 1)) return false;//throw new Exception("invalid move");
		TransitionLog.Append("d");
		return SwapWith((_gap.Item1 + 1, _gap.Item2));
	}
	public bool L(int? boundary = null)
	{
		if (_previousGap.Equals((_gap.Item1, _gap.Item2 - 1)) || _gap.Item2 == (boundary??0)) return false;//throw new Exception("invalid move");
		TransitionLog.Append("l");
		return SwapWith((_gap.Item1, _gap.Item2 - 1));
	}
	public bool R(int? boundary = null)
	{
		if (_previousGap.Equals((_gap.Item1, _gap.Item2 + 1)) || _gap.Item2 == (boundary??_size - 1)) return false;//throw new Exception("invalid move");
		TransitionLog.Append("r");
		return SwapWith((_gap.Item1, _gap.Item2 + 1));
	}
	private (int, int) Locate(int n) {
		for(var i = 0; i< _size; i++)
		{		
			var j = _state[i].IndexOf(n);
			if(j > -1) return (i, j);
		}
		throw new Exception("Number not found");
	}

	public List<(int, int)> RectanglePath((int, int) a, (int, int) b)
	{
		var result = new List<(int,int)>();		
		var topLeft = (Math.Min(a.Item1, b.Item1), Math.Min(a.Item2, b.Item2));
		var bottomRight = (Math.Max(a.Item1, b.Item1), Math.Max(a.Item2, b.Item2));
		//top
		//bottom
		for (var i = topLeft.Item1; i <= bottomRight.Item1; i++) { result.Add((i, topLeft.Item2));result.Add((i, bottomRight.Item2));}
		//right
		//left
		for (var i = topLeft.Item2; i <= bottomRight.Item2; i++) { result.Add((bottomRight.Item1, i));result.Add((topLeft.Item1, i));}
		return result.Distinct().ToList();
	}

	private bool RotateRectangle((int, int) a, (int, int) b, bool ccw = false)
	{
		var topLeft = (Math.Min(a.Item1, b.Item1), Math.Min(a.Item2, b.Item2));
		var bottomRight = (Math.Max(a.Item1, b.Item1), Math.Max(a.Item2, b.Item2));		
		//if(topLeft.Gt(bottomRight)) Extensions.Swap(topLeft, bottomRight);//throw new Exception("wrong rectangle dimensions")
		if (!ccw) {
			if (D(bottomRight.Item1)) {return true;}
			if (R(bottomRight.Item2)) {return true;}
			if (U(topLeft.Item1)) {return true;}
			if (L(topLeft.Item2)) { return true; }
		}
		else
		{
			if (R(bottomRight.Item2)) { return true; }
			if (D(bottomRight.Item1)) { return true; }
			if (L(topLeft.Item2)) { return true; }
			if (U(topLeft.Item1)) { return true; }			
		}
		return false;
	}

	public void MoveGapTo((int, int) location)
	{
		var verticalMove = _gap.Item1 - location.Item1;
		var horizontalMove = _gap.Item2 - location.Item2;
		for (int i = 0; i < Math.Abs(horizontalMove); i++) {
			if(horizontalMove < 0) R(); else L();
		}
		for (int j = 0; j < Math.Abs(verticalMove); j++)
		{
			if (verticalMove < 0) D(); else U();
		}
	}
	
	public void MoveTileTo(int n, (int, int ) location) {
		var initialLocation = Locate(n);
		var currentLocation = initialLocation;		

		var gapLocation = _gap;
		while(!currentLocation.Equals(location))
		{			
			if (!RotateRectangle(gapLocation, initialLocation)) {
				this.MoveGapTo(location);
				this.ToString().Dump();
				this.MoveTileTo(n, location);
			};
			currentLocation = Locate(n);
			this.ToString().Dump();
		}		
		_lockedTiles.Add(location);
	}
}

void Main()
{
	var p = new Puzzle("23415*768");
	
	p.RectanglePath((0,0), (2,2)).Dump();
	/*p.MoveGapTo((0,0));
	p.ToString().Dump();	
	p.MoveTileTo(1, (0,0));
	p.MoveTileTo(2, (0,2));
	p.MoveTileTo(3, (1,2));
	p.ToString().Dump();*/
	//p.TransitionLog.ToString().Dump();
	/*p.U().L().L().D().D().R().U().R().D().L().L().U().R().D().R().U().L().D().R();
	p.IsFinal().Dump();	
	p.ToString().Dump();*/
}