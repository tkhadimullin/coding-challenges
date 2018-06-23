<Query Kind="Program" />

public abstract class ElevatorBase
{
	///<summary>Represents the current location</summary>
	public int Floor { get; protected set; }
	///<summary>Represents elevator Id</summary>
	public readonly int Id;
	///<summary>Returns a "cost" of moving elevator from current location to a given floor </summary>
	public abstract int GetMovingCost(int? floor);
	///<summary>If required, moves the elevator to a given floor</summary>
	public virtual void MoveTo(int destinationFloor) {
		Console.WriteLine($"{Id} moved to {destinationFloor}");
	}
	///<summary>Calls an elevator to a given floor.</summary>
	public virtual void Call(int floor) {
		Console.WriteLine($"{Id} called to {floor}");
		MoveTo(floor);
	}

	///<summary>Base constructor. Only sets an Elevator Id</summary>
	protected ElevatorBase(int id) {
		Id = id;
	}
}

// write an ElevatorManager class that implements this interface.
interface IElevatorManager
{
	/// <summary>
	/// Given a floor that an elevator has been called from, 
	///	this method finds the most appropriate Elevator and calls it. See ElevatorBase.Call
	/// </summary>
	/// <returns>
	///	A selected Elevator Instance for further interactions
	/// </returns>
	ElevatorBase Call(int floor);
	/// <summary>
	/// Sets initial state of the controlled elevators
	/// </summary>
	void Init(List<ElevatorBase> initialState);
}

public class Elevator : ElevatorBase
{
	#region Implement Elevator class here
	public override int GetMovingCost(int? floor) {
		return Math.Abs(Floor - floor.Value);
	}
	
	public override void MoveTo(int destinationFloor)
	{
		if (Floor != destinationFloor) {
			Floor = destinationFloor;
			Console.WriteLine($"{Id} moved to {destinationFloor}");
		}
	}

	public Elevator(int id, int initialFloor): base(id)
	{
		Floor = initialFloor;
	}
	#endregion
}

#region Implement ElevatorManager here 
public class ElevatorManager: IElevatorManager {
	
	private List<ElevatorBase> elevators = new List<ElevatorBase>();

	public ElevatorBase Call(int floor)
	{
		var elevator = elevators.OrderBy(e => e.GetMovingCost(floor)).First();
		elevator.Call(floor);
		return elevator;
	}

	public ElevatorManager(List<ElevatorBase> initialState): this()
	{
		Init(initialState);
	}
	
	public ElevatorManager()
	{
	}

	public void Init(List<ElevatorBase> initialState) {
		elevators = initialState;
	}
}
#endregion

void Main()
{
	//initialising ElevatorManager
	var em = new ElevatorManager();
	em.Init(new List<ElevatorBase> {
			new Elevator(id: 0, initialFloor: 4),
			new Elevator(id: 1, initialFloor: 1),
			new Elevator(id: 2, initialFloor: 0),
			new Elevator(id: 3, initialFloor: 3),
		});
	// example calls		//example output
	em.Call(0).MoveTo(4);   //2 called to 0
							//2 moved to 4
	em.Call(4).MoveTo(0);   //0 called to 4
							//0 moved to 0
	em.Call(4).MoveTo(0);   //2 called to 4
							//2 moved to 0
	em.Call(3).MoveTo(0);   //3 called to 3
							//3 moved to 0
}