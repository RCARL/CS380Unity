public class Resource {
	static readonly int maxBitMask = 0x1f;
	static readonly int tierBitMask = 0x13;
	static readonly int padding = 4;
	public string type;
	public int tier;
	public int rarity;
	public int mass;
	/*
	 * 0 = Building
	 * 1 = Fuel
	 * 2 = Electric
	 */
	public int use;
	
	private Resource (string type, int mass, int rarity, int use, int tier) {
		this.type = type;
		this.mass = mass;
		this.rarity = rarity;
		this.use = use;
		this.tier = tier;
	}
	public static Resource makeFromByte (byte b) {
		b = (byte) (b & maxBitMask);
		int tempTier = (b & tierBitMask) + 1;

		switch (b/padding) {
		case 0:
			return new Resource ("Iron", 56, 1, 0, tempTier);
		case 1:
			return new Resource ("Platinum", 165, 2, 0, tempTier);
		case 2:
			return new Resource ("Titanium", 48, 3, 0, tempTier);
		case 3:
			return new Resource ("Beryllium", 9, 2, 1, tempTier);
		case 4:
			return new Resource ("Uranium", 104, 2, 1, tempTier);
		case 5:
			return new Resource ("Plutonium", 244, 3, 1, tempTier);
		case 6:
			return new Resource ("Copper", 64, 1, 2, tempTier);
		case 7:
			return new Resource ("Silver", 107, 2, 2, tempTier);
		default:
			return null;
		}
	}
	public static Resource iron (int tempTier) {
		return new Resource ("Iron", 56, 1, 0, tempTier);
	}
	public static Resource platinum (int tempTier) {
		return new Resource ("Platinum", 165, 2, 0, tempTier);
	}
	public static Resource titanium (int tempTier) {
		return new Resource ("Titanium", 48, 3, 0, tempTier);
	}
	public static Resource beryllium (int tempTier) {
		return new Resource ("Beryllium", 9, 2, 1, tempTier);
	}
	public static Resource uranium (int tempTier) {
		return new Resource ("Uranium", 104, 2, 1, tempTier);
	}
	public static Resource plutonium (int tempTier) {
		return new Resource ("Plutonium", 244, 3, 1, tempTier);
	}
	public static Resource copper (int tempTier) {
		return new Resource ("Copper", 64, 1, 2, tempTier);
	}
	public static Resource silver (int tempTier) {
		return new Resource ("Silver", 107, 2, 2, tempTier);
	}
	public override string ToString () {
		return type + " " + mass + " " + rarity + " " + tier;
	}
} 