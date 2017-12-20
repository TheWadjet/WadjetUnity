using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Updator : MonoBehaviour
{
	
	public static int IncreaseHealthCost
	{
		get
		{
			return SaveLoader.Health;
		}
	}

	public static int IncreaseHealthCount
	{
		get
		{
			return SaveLoader.Health / 2;
		}
	}

	public static void IncreaseHealth ()
	{
		if (SaveLoader.Money >= IncreaseHealthCost)
		{
			SaveLoader.Money -= IncreaseHealthCost;
			SaveLoader.Health += IncreaseHealthCount;
			SaveLoader.Save();
		}
	}

	public static int IncreaseDamageCost
	{
		get
		{
			return SaveLoader.Damage * 2;
		}
	}

	public static int IncreaseDamageCount
	{
		get
		{
			return SaveLoader.Damage / 3;
		}
	}

	public static void IncreaseDamage()
	{
		if (SaveLoader.Money >= IncreaseDamageCost)
		{
			SaveLoader.Money -= IncreaseDamageCost;
			SaveLoader.Damage += IncreaseDamageCount;
			SaveLoader.Save();
		}
	}

	public static int IncreaseReloadTimeCost
	{
		get
		{
			return (int)(SaveLoader.ReloadTime * 100f);
		}
	}

	public static float IncreaseReloadTimeCount
	{
		get
		{
			return SaveLoader.ReloadTime / 2;
		}
	}

	public static void IncreaseReloadTime()
	{
		if (SaveLoader.Money >= IncreaseReloadTimeCost)
		{
			SaveLoader.Money -= IncreaseReloadTimeCost;
			SaveLoader.ReloadTime += IncreaseReloadTimeCount;
			SaveLoader.Save();
		}
	}
}
