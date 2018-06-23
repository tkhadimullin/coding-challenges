<Query Kind="Program" />

#region Table Setup
public class Element
{
	//converted from text with: ([a-zA-Z]+)\|([a-zA-Z]{1,2})\|[0-9]+\|\(?([0-9\.]+)\)?\|[0-9\.]*
	public string Name { get; set;}
	public string Symbol { get; set;}
	public double Weight { get; set;}
}

public List<Element> Table = new List<Element> {
	new Element {Name = "Actinium", Symbol = "Ac", Weight = 227},
	new Element {Name = "Aluminum", Symbol = "Al", Weight = 26.9815},
	new Element {Name = "Americium", Symbol = "Am", Weight = 243},
	new Element {Name = "Antimony", Symbol = "Sb", Weight = 121.75},
	new Element {Name = "Argon", Symbol = "Ar", Weight = 39.948},
	new Element {Name = "Arsenic", Symbol = "As", Weight = 74.9216},
	new Element {Name = "Astatine", Symbol = "At", Weight = 210},
	new Element {Name = "Barium", Symbol = "Ba", Weight = 137},
	new Element {Name = "Berkelium", Symbol = "Bk", Weight = 247},
	new Element {Name = "Beryllium", Symbol = "Be", Weight = 9.0122},
	new Element {Name = "Bismuth", Symbol = "Bi", Weight = 208.980},
	new Element {Name = "Boron", Symbol = "B", Weight = 10.81},
	new Element {Name = "Bromine", Symbol = "Br", Weight = 79.904},
	new Element {Name = "Cadmium", Symbol = "Cd", Weight = 112.40},
	new Element {Name = "Calcium", Symbol = "Ca", Weight = 40.08},
	new Element {Name = "Californium", Symbol = "Cf", Weight = 251},
	new Element {Name = "Carbon", Symbol = "C", Weight = 12.011},
	new Element {Name = "Cerium", Symbol = "Ce", Weight = 140.12},
	new Element {Name = "Cesium", Symbol = "Cs", Weight = 132.9054},
	new Element {Name = "Chlorine", Symbol = "Cl", Weight = 35.453},
	new Element {Name = "Chromium", Symbol = "Cr", Weight = 51.996},
	new Element {Name = "Cobalt", Symbol = "Co", Weight = 58.9332},
	new Element {Name = "Copper", Symbol = "Cu", Weight = 63.546},
	new Element {Name = "Curium", Symbol = "Cm", Weight = 247},
	new Element {Name = "Dysprosium", Symbol = "Dy", Weight = 162.50},
	new Element {Name = "Einsteinium", Symbol = "Es", Weight = 254},
	new Element {Name = "Erbium", Symbol = "Er", Weight = 167.26},
	new Element {Name = "Europium", Symbol = "Eu", Weight = 151.96},
	new Element {Name = "Fermium", Symbol = "Fm", Weight = 257},
	new Element {Name = "Fluorine", Symbol = "F", Weight = 18.9984},
	new Element {Name = "Francium", Symbol = "Fr", Weight = 223},
	new Element {Name = "Gadolinium", Symbol = "Gd", Weight = 157.25},
	new Element {Name = "Gallium", Symbol = "Ga", Weight = 69.72},
	new Element {Name = "Germanium", Symbol = "Ge", Weight = 72.59},
	new Element {Name = "Gold", Symbol = "Au", Weight = 196.966},
	new Element {Name = "Hafnium", Symbol = "Hf", Weight = 178.49},
	new Element {Name = "Helium", Symbol = "He", Weight = 4.00260},
	new Element {Name = "Holmium", Symbol = "Ho", Weight = 164.930},
	new Element {Name = "Hydrogen", Symbol = "H", Weight = 1.0079},
	new Element {Name = "Indium", Symbol = "In", Weight = 114.82},
	new Element {Name = "Iodine", Symbol = "I", Weight = 126.904},
	new Element {Name = "Iridium", Symbol = "Ir", Weight = 192.22},
	new Element {Name = "Iron", Symbol = "Fe", Weight = 55.847},
	new Element {Name = "Krypton", Symbol = "Kr", Weight = 83.80},
	new Element {Name = "Lanthanum", Symbol = "La", Weight = 138.905},
	new Element {Name = "Lawrencium", Symbol = "Lr", Weight = 256},
	new Element {Name = "Lead", Symbol = "Pb", Weight = 207.2},
	new Element {Name = "Lithium", Symbol = "Li", Weight = 6.941},
	new Element {Name = "Lutetium", Symbol = "Lu", Weight = 174.97},
	new Element {Name = "Magnesium", Symbol = "Mg", Weight = 24.305},
	new Element {Name = "Manganese", Symbol = "Mn", Weight = 54.9380},
	new Element {Name = "Mendelevium", Symbol = "Md", Weight = 258},
	new Element {Name = "Mercury", Symbol = "Hg", Weight = 200.59},
	new Element {Name = "Molybdenum", Symbol = "Mo", Weight = 95.94},
	new Element {Name = "Neodymium", Symbol = "Nd", Weight = 144.24},
	new Element {Name = "Neon", Symbol = "Ne", Weight = 20.179},
	new Element {Name = "Neptunium", Symbol = "Np", Weight = 237.048},
	new Element {Name = "Nickel", Symbol = "Ni", Weight = 58.70},
	new Element {Name = "Niobium", Symbol = "Nb", Weight = 92.9064},
	new Element {Name = "Nitrogen", Symbol = "N", Weight = 14.0067},
	new Element {Name = "Nobelium", Symbol = "No", Weight = 255},
	new Element {Name = "Osmium", Symbol = "Os", Weight = 190.2},
	new Element {Name = "Oxygen", Symbol = "O", Weight = 15.9994},
	new Element {Name = "Palladium", Symbol = "Pd", Weight = 106.4},
	new Element {Name = "Phosphorus", Symbol = "P", Weight = 30.9738},
	new Element {Name = "Platinum", Symbol = "Pt", Weight = 195.09},
	new Element {Name = "Plutonium", Symbol = "Pu", Weight = 244},
	new Element {Name = "Polonium", Symbol = "Po", Weight = 210},
	new Element {Name = "Potassium", Symbol = "K", Weight = 39.098},
	new Element {Name = "Praseodymium", Symbol = "Pr", Weight = 140.908},
	new Element {Name = "Promethium", Symbol = "Pm", Weight = 147},
	new Element {Name = "Protactinium", Symbol = "Pa", Weight = 231.036},
	new Element {Name = "Radium", Symbol = "Ra", Weight = 226.025},
	new Element {Name = "Radon", Symbol = "Rn", Weight = 222},
	new Element {Name = "Rhenium", Symbol = "Re", Weight = 186.207},
	new Element {Name = "Rhodium", Symbol = "Rh", Weight = 102.906},
	new Element {Name = "Rubidium", Symbol = "Rb", Weight = 85.4678},
	new Element {Name = "Ruthenium", Symbol = "Ru", Weight = 101.07},
	new Element {Name = "Rutherfordium", Symbol = "Rf", Weight = 261},
	new Element {Name = "Samarium", Symbol = "Sm", Weight = 150.4},
	new Element {Name = "Scandium", Symbol = "Sc", Weight = 44.9559},
	new Element {Name = "Selenium", Symbol = "Se", Weight = 78.96},
	new Element {Name = "Silicon", Symbol = "Si", Weight = 28.086},
	new Element {Name = "Silver", Symbol = "Ag", Weight = 107.868},
	new Element {Name = "Sodium", Symbol = "Na", Weight = 22.9898},
	new Element {Name = "Strontium", Symbol = "Sr", Weight = 87.62},
	new Element {Name = "Sulfur", Symbol = "S", Weight = 32.06},
	new Element {Name = "Tantalum", Symbol = "Ta", Weight = 180.948},
	new Element {Name = "Technetium", Symbol = "Tc", Weight = 98.9062},
	new Element {Name = "Tellurium", Symbol = "Te", Weight = 127.60},
	new Element {Name = "Terbium", Symbol = "Tb", Weight = 158.925},
	new Element {Name = "Thallium", Symbol = "Tl", Weight = 204.37},
	new Element {Name = "Thorium", Symbol = "Th", Weight = 232.038},
	new Element {Name = "Thulium", Symbol = "Tm", Weight = 168.934},
	new Element {Name = "Tin", Symbol = "Sn", Weight = 118.69},
	new Element {Name = "Titanium", Symbol = "Ti", Weight = 47.90},
	new Element {Name = "Tungsten", Symbol = "W", Weight = 183.85},
	new Element {Name = "Uranium", Symbol = "U", Weight = 238.029},
	new Element {Name = "Vanadium", Symbol = "V", Weight = 50.9414},
	new Element {Name = "Xenon", Symbol = "Xe", Weight = 131.30},
	new Element {Name = "Ytterbium", Symbol = "Yb", Weight = 173.04},
	new Element {Name = "Yttrium", Symbol = "Y", Weight = 88.9059},
	new Element {Name = "Zinc", Symbol = "Zn", Weight = 65.38},
	new Element {Name = "Zirconium", Symbol = "Zr", Weight = 91.22},
};
#endregion

public static class Extensions
{
	public static string Without(this string s, Element e) {
		return s.Substring(e.Symbol.Length);
	}
	public static bool StartsWith(this string word, Element e)
	{
		if(e.Symbol.Length > word.Length) return false;
		return e.Symbol.Equals(word.Substring(0, e.Symbol.Length),StringComparison.InvariantCultureIgnoreCase);
	}

	public static string ToFormattedString(this List<Element> l)
	{
		var sb1 = new StringBuilder();
		var sb2 = new StringBuilder();
		foreach (var e in l)
		{
			sb1.Append(e.Symbol);
			sb2.Append(e.Name).Append(" ");
		}
		return $"{sb1} ({ sb2.ToString().TrimEnd()})";
	}
}

List<Element> Match(string word, List<Element> e) {
	if(string.IsNullOrWhiteSpace(word)) return null;
	var matchingElement = e.AsParallel().FirstOrDefault(x => word.StartsWith(x));
	if (matchingElement != null)
	{
		var result = new List<Element> {matchingElement};
		result.AddRange(Match(word.Without(matchingElement), e) ?? new List<Element>());
		return result;
	}
	throw new Exception($"No Match {word}");
}

void Main()
{
	var word = "FUNCTiONS";//Console.ReadLine();
	var sortedElements = Table.OrderByDescending(t => t.Symbol.Length).ThenByDescending(t => t.Weight).ToList();
	var result = Match(word, sortedElements);
	result.ToFormattedString().Dump();
}