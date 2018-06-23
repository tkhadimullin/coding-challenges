<Query Kind="Program" />

class Point
{
	List<double> _coords = new List<double>(3);	
	public Point(params double[] coords) {
		_coords = coords.ToList();
	}

	public int Dimension {get { return _coords.Count;}}
	public double this[int i]
	{
		get { return _coords[i]; }
	}

	public static List<double> operator -(Point p1, Point p2)
	{		
		//should check if p1.Dimension != p2.Dimension
		var result = new List<double>();
		for (var i = 0; i < p1.Dimension; i++)
		{
			result.Add(p1[i] - p2[i]);
        }
		return result;
	}
}
class Line
{
	Point _point;
	Point _vector;
	List<double> _parameters;
	
	public Line(Point point1, Point point2){	
		_point = point1;
		_vector = new Point((point2-point1).ToArray());	
	}

	public bool IsOn(Point p)
	{
		var r = false;
		var t = (p[0]-_point[0])/_vector[0];//i am aware _vector components can not be zero
		for (var i = 1; i < _vector.Dimension; i++) {			
			r = (t == (p[i]-_point[i])/_vector[i]);
		}
		return r;
	}

	public void Cross(Line other) {
		
	}

	#region gaussian elimination borrowed from http://codereview.stackexchange.com/questions/79462/better-implementation-of-gaussian-elimination
	private double[] SolveLinearEquations(string[] input)
	{
		double[][] rows = new double[input.Length][];
		for (int i = 0; i < rows.Length; i++)
		{
			rows[i] = (double[])Array.ConvertAll(input[i].Split(' '), double.Parse);
		}
		return SolveLinearEquations(rows);
	}

	private double[] SolveLinearEquations(double[][] rows)
	{

		int length = rows[0].Length;

		for (int i = 0; i < rows.Length - 1; i++)
		{
			if (rows[i][i] == 0 && !Swap(rows, i, i))
			{
				return null;
			}

			for (int j = i; j < rows.Length; j++)
			{
				double[] d = new double[length];
				for (int x = 0; x < length; x++)
				{
					d[x] = rows[j][x];
					if (rows[j][i] != 0)
					{
						d[x] = d[x] / rows[j][i];
					}
				}
				rows[j] = d;
			}

			for (int y = i + 1; y < rows.Length; y++)
			{
				double[] f = new double[length];
				for (int g = 0; g < length; g++)
				{
					f[g] = rows[y][g];
					if (rows[y][i] != 0)
					{
						f[g] = f[g] - rows[i][g];
					}

				}
				rows[y] = f;
			}
		}

		return CalculateResult(rows);
	}

	private bool Swap(double[][] rows, int row, int column)
	{
		bool swapped = false;
		for (int z = rows.Length - 1; z > row; z--)
		{
			if (rows[z][row] != 0)
			{
				double[] temp = new double[rows[0].Length];
				temp = rows[z];
				rows[z] = rows[column];
				rows[column] = temp;
				swapped = true;
			}
		}

		return swapped;
	}
	private double[] CalculateResult(double[][] rows)
	{
		double val = 0;
		int length = rows[0].Length;
		double[] result = new double[rows.Length];
		for (int i = rows.Length - 1; i >= 0; i--)
		{
			val = rows[i][length - 1];
			for (int x = length - 2; x > i - 1; x--)
			{
				val -= rows[i][x] * result[x];
			}
			result[i] = val / rows[i][i];

			if (!IsValidResult(result[i]))
			{
				return null;
			}
		}
		return result;
	}

	private bool IsValidResult(double result)
	{
		return result.ToString() != "NaN" || !result.ToString().Contains("Infinity");
	}
	#endregion
}

void Main()
{
	var l1 = new Line(new Point(0,0), new Point(1,2));
	l1.IsOn(new Point(2,4)).Dump();
}