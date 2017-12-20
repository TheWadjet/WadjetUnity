using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoader : MonoBehaviour
{
	public static int Money { get; set; }
	public static int Health { get; set; }
	public static int Damage { get; set; }
	public static float ReloadTime { get; set; }
	public static int Level { get; set; }
	public static int Score { get; set; }

	public static void Load()
	{
		if (PlayerPrefs.HasKey("money"))
		{
			GetData();
		}
		else
		{
			Money = 100;
			Health = 100;
			Damage = 30;
			ReloadTime = 1f;
			Level = 1;
			Score = 0;
			Save();
		}
	}

	static void GetData ()
	{
		Money = PlayerPrefs.GetInt("money");
		Health = PlayerPrefs.GetInt("health");
		Damage = PlayerPrefs.GetInt("damage");
		ReloadTime = PlayerPrefs.GetFloat("reloadTime");
		Level = PlayerPrefs.GetInt("level");
		Score = PlayerPrefs.GetInt("score");
	}

	public static void Save ()
	{
		PlayerPrefs.SetInt("money", Money);
		PlayerPrefs.SetInt("health", Health);
		PlayerPrefs.SetInt("damage", Damage);
		PlayerPrefs.SetFloat("reloadTime", ReloadTime);
		PlayerPrefs.SetInt("level", Level);
		PlayerPrefs.SetInt("score", Score);
		PlayerPrefs.Save();
	}
}
