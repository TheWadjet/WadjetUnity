using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : Plane
{
	private float lastAttack = -100f;

	public float speed;
	public float reloadSpeed;
	public int damage;
	public GameObject shoot;


	public override void Go(Transform purpose)
	{
		transform.LookAt(purpose);
		transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);
		gameObject.SetActive(true);
	}

	void Update ()
	{
		if (EvContr.OnMeasureDistance(transform.position) > 13f)
		{
			transform.Translate(0f, 0f, speed * Time.deltaTime);
		}
		else if (EvContr.OnMeasureDistance(transform.position) > 9f)
		{
			// TODO: rotation to tower and maneuver
			speed -= (speed / 3f) * Time.deltaTime;
			transform.Translate(0f, 0f, speed * Time.deltaTime);
		}
		else if (lastAttack + reloadSpeed <= Time.time)
		{
			Shoot();
			lastAttack = Time.time;
		}
	}

	void Shoot ()
	{
		// TODO: show sound and GO of shoot
		EvContr.OnHitMainTower(damage);
	}
}
