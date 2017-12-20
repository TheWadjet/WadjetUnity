using System;
using UnityEngine;

public class EvContr : MonoBehaviour
{
	static GameObject mainTowerObj;
	static MainTower mainTower;
	static Spawner spawner;

	void Start()
	{
		mainTowerObj = GameObject.Find("MainTower");
		mainTower = mainTowerObj.GetComponent<MainTower>();
		spawner = mainTowerObj.GetComponent<Spawner>();
	} 

	public static void OnTowerAttack(GameObject plane)
	{
		mainTower.Attack(plane);
	}

	public static void OnHitMainTower(int damage)
	{
		mainTower.Hit(damage);
	}

	public static void OnDefeat()
	{
		SaveLoader.Save();
		Time.timeScale = 0f;
		SceneGUI.ILayer = 1;
	}

	public static void OnVictory()
	{
		int currentLvl = int.Parse(Application.loadedLevelName.Substring(6));
		SaveLoader.Level = currentLvl + 1;
		SaveLoader.Save();
		Time.timeScale = 0f;
		SceneGUI.ILayer = 2;
	}

	public static void OnSpawn(Plane plane)
	{
		plane.Go(mainTower.transform);
	}

	public static bool OnCheckDistance(Vector3 pos)
	{
		if (Vector3.Distance(pos, mainTower.transform.position) <= 7.2f)
			return true;
		return false;
	}

	public static float OnMeasureDistance(Vector3 pos)
	{
		return Vector3.Distance(pos, mainTower.transform.position);
	}

	void Update()
	{
	} 

	/*public static void Notify (Ev ev)
	{

	}

	public enum Ev
	{
		OnHitMainTower,
		OnDefeat
	}*/
}
