public class Resource : Artificial{

	public string type;
	public int tier;
	/// <summary>
	///  0 = Building
	/// 1 = Fuel
	/// 2 = Electric.
	/// </summary>
	public int use;
	/// <summary>
	/// byte value used to call this
	/// </summary>
	public byte symbol;
	
	private Resource (string type, int mass, int use, int tier, byte symbol) : base(mass,1,type,null) {
		this.use = use;
		this.tier = tier;
		this.symbol = symbol;
	}
	public static Resource makeFromByte (byte b) {


		switch (b) {
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
	public static Resource iron () {
		return new Resource ("Iron", 56, 0, 1, 0x01);
	}
	public static Resource platinum () {
		return new Resource ("Platinum", 165, 0, 2, 0x02);
	}
	public static Resource titanium () {
		return new Resource ("Titanium", 48, 0, 3, 0x03);
	}
	public static Resource beryllium () {
		return new Resource ("Beryllium", 9, 1, 1, 0x04);
	}
	public static Resource uranium () {
		return new Resource ("Uranium", 104, 1, 2, 0x05);
	}
	public static Resource plutonium () {
		return new Resource ("Plutonium", 244, 1, 3, 0x06);
	}
	public static Resource copper () {
		return new Resource ("Copper", 64, 2, 1, 0x07);
	}
	public static Resource silver () {
		return new Resource ("Silver", 107, 2, 2, 0x08);
	}
	public override string ToString () {
		return type + " " + mass + " " + tier;
	}
} 