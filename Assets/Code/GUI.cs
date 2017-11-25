using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI : MonoBehaviour
{
	MainTower mainTower;

	private void Start()
	{
		mainTower = GameObject.Find("MainTower").GetComponent<MainTower>();
	} 

	private void OnGUI()
	{
		GUILayout.Label("HP: " + mainTower.HP);
	} 
}
