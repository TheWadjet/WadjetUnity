using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
	public GameObject explode;
	public int damage;

	void Start ()
	{
		
	}
	
	void Update ()
	{
		transform.Translate(0f, -2f * Time.deltaTime, 0f, Space.World);
		if (transform.position.y < 1.5f)
		{
			Instantiate(explode, transform.position, Quaternion.identity);
			EvContr.OnHitMainTower(damage);
			Destroy(gameObject);
		}
	}
}
