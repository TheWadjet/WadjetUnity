using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public float delay;
	public GameObject[] planePrefabs;
    ObjectPool[] objectPool;

    public float roundDuration = 100f;

	private float lastSpawn = -3f;
	
	void Start ()
	{
        objectPool = new ObjectPool[planePrefabs.Length];
        for (int i = 0;i < planePrefabs.Length; i++)
        {
            objectPool[i] = new ObjectPool(planePrefabs[i], 4);
        }
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
        GameObject plane = objectPool[rnd].Pool(new Vector3(Random.Range(0, 20) - 10f, 7f, -15f), Quaternion.identity);
        //GameObject plane = Instantiate(planePrefabs[rnd], new Vector3(Random.Range(0, 20) - 10f, 7f, -15f), Quaternion.identity) as GameObject;
        EvContr.OnSpawn(plane.GetComponent<Plane>());
	}
}
