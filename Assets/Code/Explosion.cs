using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
	public float timeLive;

	void Start ()
	{
		Destroy(gameObject, timeLive);
	}
	
	void Update ()
	{
		
	}
}
