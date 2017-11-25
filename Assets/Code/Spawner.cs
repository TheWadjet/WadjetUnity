using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public float delay;
	public GameObject bomberPrefab;

	private float lastSpawn = -3f;
	
	void Start ()
	{
		
	}
	
	void Update ()
	{
		if (lastSpawn + delay < Time.time)
		{
			Spawn();
			lastSpawn = Time.time;
		}
	}

	void Spawn()
	{
		GameObject bomber = Instantiate(bomberPrefab, new Vector3(Random.Range(0, 20) - 10f, 7f, -15f), Quaternion.identity) as GameObject;
		EvContr.OnSpawn(bomber.GetComponent<Bomber>());
	}
}
