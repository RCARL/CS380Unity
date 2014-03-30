using UnityEngine;
using System.Collections;
	
public class Resource : MonoBehaviour {
	readonly int usableBits = 32;
	readonly int tierBits = 4;
	string type;
	int tier;
	int rarity;
	int mass;
	/*
	 * 0 = Building
	 * 1 = Fuel
	 * 2 = Electric
	 */
	int use;

	public Resource (byte b) {
		b = (byte) (b % usableBits);
		tier = (b % tierBits) + 1;

		if (b >= 0 && b <= 3) {
			type = "Iron";
			mass = 56;
			rarity = 1;
			use = 0;
				} else if (b >= 4 && b <= 7) {
			type = "Platinum";
			mass = 165;
			rarity = 2;
			use = 0;
				} else if (b >= 8 && b <= 11) {
			type = "Titanium";
			mass = 48;
			rarity = 3;
			use = 0;
				} else if (b >= 12 && b <= 15) {
			type = "Beryllium";
			mass = 9;
			rarity = 1;
			use = 1;
				} else if (b >= 16 && b <= 19) {
			type = "Uranium";
			mass = 104;
			rarity = 2;
			use = 1;
				} else if (b >= 20 && b <= 23) {
			type = "Plutonium";
			mass = 244;
			rarity = 3;
			use = 1;
				} else if (b >= 24 && b <= 27) {
			type = "Copper";
			mass = 64;
			rarity = 1;
			use = 2;
				} else if (b >= 28 && b <= 31) {
			type = "Silver";
			mass = 107;
			rarity = 2;
			use = 2;
				}
	}
}