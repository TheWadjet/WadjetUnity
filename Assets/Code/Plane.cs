using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
	public int hp;

	public virtual void Go(Transform purpose)
	{

	}

	void OnMouseUp()
	{
		EvContr.OnTowerAttack(gameObject);
	}

	public void GetDamage(int damage)
	{
		hp -= damage;
		if (hp <= 0)
		{
			SaveLoader.Money++;
			SaveLoader.Score++;
			Destroy(gameObject);
		}
	}
}