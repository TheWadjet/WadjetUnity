using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VolumetricLines;

public class MainTower : MonoBehaviour
{
	private float lastReloadTime = -100f;

	public int hp;
	public int damage;
	public float reloadTime;
	public VolumetricLineBehavior laser;

	private int maxHP;

	public string HP {
		get {
			if ((float)hp / (float)maxHP > 0.5f)
				return "<color=green>"+hp+"</color>";
			else if ((float)hp / (float)maxHP > 0.3f)
				return "<color=yellow>" + hp + "</color>";
			return "<color=red>" + hp + "</color>";
		}
	}

	private void Start()
	{
		hp = SaveLoader.Health;
		damage = SaveLoader.Damage;
		reloadTime = SaveLoader.ReloadTime;
		maxHP = hp;
	} 

	public void Hit (int damage)
	{
		hp -= damage;
		if (hp < 0)
		{
			EvContr.OnDefeat();
		}
	}

	public void Attack(GameObject plane)
	{
		if (lastReloadTime + reloadTime <= Time.time)
		{
			laser.SetStartAndEndPoints(new Vector3(0f, 1.23f, 0f), plane.transform.position);
			Invoke("HideLaser", 0.15f);
			plane.SendMessage("GetDamage", damage);
			lastReloadTime = Time.time;
		}
	}
	
	private void HideLaser ()
	{
		laser.SetStartAndEndPoints(new Vector3(0f, 1.23f, 0f), new Vector3(0f, 1.23f, 0f));
	}

	void Update ()
	{
		
	}
}
