<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Namespace>System</Namespace>
  <Namespace>System.Collections</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Numerics</Namespace>
</Query>

public static class Extensions
{
	public static IEnumerable<T> InsertAt<T>(
	  this IEnumerable<T> items, int position, T newItem)
	{
		if (items == null)
			throw new ArgumentNullException("items");
		if (position < 0)
			throw new ArgumentOutOfRangeException("position");
		return InsertAtIterator<T>(items, position, newItem);
	}

	private static IEnumerable<T> InsertAtIterator<T>(
		this IEnumerable<T> items, int position, T newItem)
	{
		int index = 0;
		bool yieldedNew = false;
		foreach (T item in items)
		{
			if (index == position)
			{
				yield return newItem;
				yieldedNew = true;
			}
			yield return item;
			index += 1;
		}
		if (index == position)
		{
			yield return newItem;
			yieldedNew = true;
		}
		if (!yieldedNew)
			throw new ArgumentOutOfRangeException("position");
	}
}

struct Permutation : IEnumerable<int>
{
	public static Permutation Empty { get { return empty; } }
	private static Permutation empty = new Permutation(new int[] { });
	private int[] permutation;
	private Permutation(int[] permutation) { this.permutation = permutation; }
	private Permutation(IEnumerable<int> permutation) : this(permutation.ToArray()) { }
	private static BigInteger Factorial(int x) { BigInteger result = 1; for (int i = 2; i <= x; ++i) result *= i; return result; }
	public int this[int index] { get { return permutation[index]; } }
	public IEnumerator<int> GetEnumerator() { foreach (int item in permutation) yield return item; }
	System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { return this.GetEnumerator(); }
	public int Count { get { return this.permutation.Length; } }
	public override string ToString() { return string.Join<int>(",", permutation); }
	
	public static Permutation NthPermutation(int size, BigInteger index)
	{
		if (index < 0 || index >= Factorial(size))
			throw new ArgumentOutOfRangeException("index");
		if (size == 0) // index must be zero since it is smaller than 0!
			return Empty;
		BigInteger group = index / size; // What block are we in?
		Permutation permutation = NthPermutation(size - 1, group);
		bool forwards = group % 2 != 0; // Forwards or backwards?
		int insert = (int)(index % size); // Where are we making the insert?                      
		return new Permutation(
		  permutation.InsertAt(forwards ? insert : size - insert - 1, size - 1));
	}

	// Produce a random number between 0 and n!-1
	static BigInteger RandomFactoradic(int n, Random random)
	{
		BigInteger result = 0;
		BigInteger radix = 1;
		for (int i = 1; i < n; ++i)
		{
			// We need a digit between 0 and i.
			result += radix * random.Next(i + 1);
			radix *= (i + 1);
		}
		return result;		
	}
	public static Permutation RandomPermutation(int size, Random random)
	{
		return NthPermutation(size, RandomFactoradic(size, random));
	}
}

class Program
{
	static void Main()
	{
		string[] suits = { "Spades", "Hearts", "Diamonds", "Clubs" };
		string[] values = {"Ace", "Deuce", "Trey", "Four", "Five",
					   "Six", "Seven", "Eight", "Nine", "Ten",
					   "Jack", "Queen", "King" };
		foreach (var seed in Enumerable.Range(0, int.MaxValue))
		{
			// do a shuffle with a known seed
			var p = Permutation.RandomPermutation(52, new Random(seed));
			if (p.ToString() != "10,48,49,26,42,3") continue; // check if starts with the right sequence
			// print off the whole sequence
			foreach (int i in p)
				Console.WriteLine("{0}: {1} of {2}",
					i, values[i % 13], suits[i / 13]);
		}		
	}
}