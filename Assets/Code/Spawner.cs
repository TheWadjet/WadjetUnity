using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public float delay;
	public GameObject[] planePrefabs;
	public float roundDuration = 100f;

	private float lastSpawn = -3f;
	
	void Start ()
	{
		
	}
	
	void Update ()
	{
		if (roundDuration < Time.time)
		{
			EvContr.OnVictory();
		}
		else if (lastSpawn + delay < Time.time)
		{
			Spawn();
			lastSpawn = Time.time;
		}
	}

	void Spawn()
	{
		int rnd = Random.Range(0, planePrefabs.Length);
		GameObject plane = Instantiate(planePrefabs[rnd], new Vector3(Random.Range(0, 20) - 10f, 7f, -15f), Quaternion.identity) as GameObject;
		EvContr.OnSpawn(plane.GetComponent<Plane>());
	}
}
