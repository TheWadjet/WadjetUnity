using System;
using UnityEngine;

public class EvContr : MonoBehaviour
{
	static GameObject mainTowerObj;
	static MainTower mainTower;

	void Start()
	{
		mainTowerObj = GameObject.Find("MainTower");
		mainTower = mainTowerObj.GetComponent<MainTower>();
	} 

	public static void OnHitMainTower(int damage)
	{
		mainTower.Hit(damage);
	}

	public static void OnDefeat()
	{

	}

	public static void OnSpawn(Bomber bomber)
	{
		bomber.Go(mainTower.transform);
	}

	public static bool OnCheckDistance(Vector3 pos)
	{
		if (Vector3.Distance(pos, mainTower.transform.position) <= 7.2f)
			return true;
		return false;
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
