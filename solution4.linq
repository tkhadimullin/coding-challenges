<Query Kind="Program" />

public sealed class Circle
{
	private readonly double _radius;

	public Circle(double radius) {
		_radius = radius;
	}

	public double Calculate(Func<double, double> op)
	{
		return op(_radius);
	}
}

void Main()
{
	var c = new Circle(2);
	var result = c.Calculate((r) => {
		return 2 * Math.PI * r;
	});
	Console.WriteLine(result );
}
