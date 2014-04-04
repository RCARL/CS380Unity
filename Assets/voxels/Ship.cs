using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {
	private double Speed = 10.0;
	private double OxygenLevel = 100.0;
	private double SecurityLevel = 100.0;
	private int ShieldCount = 20;
	//50 - Low level
	//85 - Medium level
	//100 - Highest level/default

	public int getShields(){return ShieldCount;}
	public double GetSecurity(){return SecurityLevel;}
	public double GetOxygen(){return OxygenLevel;}
	public double getSpeed(){ return Speed;}

	public void newSecurity(double id){SecurityLevel = id;}
	public void newOxygen(double id){OxygenLevel = id;}
	public void newSpeed(double id){Speed = id;}
	public void newShield(int i){ShieldCount = i;}
}
