using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTower : MonoBehaviour
{
	public int hp;

	public int HP { get { return hp; } }

	public void Hit (int damage)
	{
		hp -= damage;
		if (hp < 0)
		{
			EvContr.OnDefeat();
		}
	}
	
	void Update ()
	{
		
	}
}
