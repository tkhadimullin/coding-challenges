<Query Kind="Program" />

void Main()
{	
    var commands = new List<Command>();
	bool eof;
	var line = "";
	do {
		line = Console.ReadLine();
		eof = line == "EOF";
		if (!eof) { commands.Add(Command.Make(line));}
	} while (!eof);
    var state = new State();
	int ip = 0;
	for (ip = 0; ip < commands.Count; ip++) {
		ip = commands[ip].Run(ip, state, commands);
	}
}

public class State {
	Dictionary<string, byte> _registers;

	public State() {
		_registers = new Dictionary<string, byte>();
	}
	
	public void SetRegister(string register, byte value) {
		_registers[register] = value;
	}

	public byte GetRegister(string register) { 
		return _registers[register]; 
	}
	public void Shift(string register, int number)
	{						
		var byteLen = 8;
		if (number > 0) _registers[register] = (byte)(_registers[register] >> number | _registers[register] << (byteLen - number));		
		if (number < 0) _registers[register] = (byte)(_registers[register] << number | _registers[register] >> (byteLen - number));
	}
}

public class Ld : Command
{	
	byte _value;
	public Ld(string label, string register, byte value) { Label = label; _register = register; _value = value;}
	public override int Run(int ip, State state, List<Command> commands)
	{
		state.SetRegister(_register, _value);
		return ip;
	}
}
public class Out : Command 
{
	public Out(string label, string register) { Label = label; _register = register; }
	public override int Run(int ip, State state, List<Command> commands)
	{
		var list = Convert.ToString(state.GetRegister(_register), 2).PadLeft(8, '0').ToCharArray().Select(x => x == '1' ? true : false).ToList();
		foreach (var bit in list) {
			Console.Write(bit?"*":".");
		}	
		Console.WriteLine();
		return ip;
	}
}
public class Djnz : Command
{
	string _destination;
	public Djnz(string label, string destination) { Label = label; _destination = destination;}
	public override int Run(int ip, State state, List<Command> commands)
	{
		byte value = state.GetRegister("b");
		value = (byte)(value-1);
		state.SetRegister("b", value);
		var newIp = ip;
		if (value > 0) {
			newIp = commands.FindIndex(x => x.Label.StartsWith(_destination));
		}		
		return newIp;
	}
}
public class Rlca : Command
{	
	public Rlca(string label) { Label = label; _register = "a"; }
	public override int Run(int ip, State state, List<Command> commands)
	{
		state.Shift(_register, -1);
		return ip;
	}
}
public class Rrca : Command
{
    public Rrca(string label) { Label = label;  _register = "a"; }
	public override int Run(int ip, State state, List<Command> commands)
	{
		state.Shift(_register, 1);
		return ip;
	}
}
public class Nop : Command
{
	public Nop(string label) { Label = label;}
	public override int Run(int ip, State state, List<Command> commands)
	{		
		return ip;
	}
}

public abstract class Command
{	
	protected string _register;
	public string Label;
	public static Command Make(string line)
	{
		var match = Regex.Match(line, @"([a-zA-Z]+:)?\s*([a-zA-Z]{2,4})?\s*([a-zA-Z()0-9]+)?,?([a-zA-Z()0-9]+)?\s*");
		switch (match.Groups[2].Value.ToLowerInvariant()) {
			case "ld": 
				return new Ld(match.Groups[1].Value, match.Groups[3].Value, byte.Parse(match.Groups[4].Value));
			case "out":
				return new Out(match.Groups[1].Value, match.Groups[4].Value);
			case "djnz":
				return new Djnz(match.Groups[1].Value, match.Groups[3].Value);
			case "rlca":
				return new Rlca(match.Groups[1].Value);
			case "rrca":
				return new Rrca(match.Groups[1].Value);
			default:
				return new Nop(match.Groups[1].Value);
		}		
	}
	public abstract int Run(int ip, State state, List<Command> commands);
}
