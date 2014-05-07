public class Resource : Artificial{

	public int tier;
	/// <summary>
	///  0 = Building
	/// 1 = Fuel
	/// 2 = Electric.
	/// </summary>
	public int use;


	
	private Resource (string type, int use, int tier, byte symbol, string description) : base(1,type,null, description) {
		this.use = use;
		this.tier = tier;
		this.symbol = symbol;
	}
	public static Resource makeFromByte (byte b) {


		switch (b) {
		case 0x00:
			return Resource.nothing();
		case 0x01:
			return Resource.iron();
		case 0x02:
			return Resource.platinum();
		case 0x03:
			return Resource.titanium();
		case 0x04:
			return Resource.beryllium();
		case 0x05:
			return Resource.uranium();
		case 0x06:
			return Resource.plutonium();
		case 0x07:
			return Resource.copper();
		case 0x08:
			return Resource.silver();
		default:
			return null;
		}
	}
	public static Resource nothing()	{
		return new Resource ("nothing", 0, 0, 0x00, "absence of stuff");
	
	}
	public static Resource iron () {
		string stringTemp = "Mineral used to make structural things";
		return new Resource ("Iron", 0, 1, 0x01, stringTemp);
	}
	public static Resource platinum () {
		string stringTemp = "Mineral used to make structural things, better than iron";
		return new Resource ("Platinum", 0, 2, 0x02, stringTemp);
	}
	public static Resource titanium () {
		string stringTemp = "Mineral used to make structural things, better than both iron and platinum";
		return new Resource ("Titanium", 0, 3, 0x03, stringTemp);
	}
	public static Resource beryllium () {
		string stringTemp = "Mineral used for fuel";
		return new Resource ("Beryllium", 1, 1, 0x04, stringTemp);
	}
	public static Resource uranium () {
		string stringTemp = "Mineral used for fuel, better than beryllium";
		return new Resource ("Uranium", 1, 2, 0x05, stringTemp);
	}
	public static Resource plutonium () {
		string stringTemp = "Mineral used for fuel, better than beryllium and uranium";
		return new Resource ("Plutonium", 1, 3, 0x06, stringTemp);
	}
	public static Resource copper () {
		string stringTemp = "Mineral used for electronics";
		return new Resource ("Copper", 2, 1, 0x07, stringTemp);
	}
	public static Resource silver () {
		string stringTemp = "Mineral used for electronics, better than copper";
		return new Resource ("Silver", 2, 2, 0x08, stringTemp);
	}
	public override string ToString () {
		return type + " " + tier;
	}
} 
