using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : MonoBehaviour
{
	public float speed;
	public GameObject bomb;

	private bool isLaunch = false;

	public void Go (Transform purpose)
	{
		transform.LookAt(purpose);
		transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);
		gameObject.SetActive(true);
	}

	void Start ()
	{
		
	}
	
	void Update ()
	{
		if (gameObject.activeSelf)
		{
			transform.Translate(0f, 0f, speed * Time.deltaTime);
		}
		if (!isLaunch && EvContr.OnCheckDistance(transform.position))
		{
			isLaunch = true;
			GameObject bomber = Instantiate(bomb, transform.position, Quaternion.Euler(0f,0f,-90f)) as GameObject;
		}
		if (Vector3.Distance(transform.position, Vector3.zero) > 30f)
		{
			Destroy(gameObject);
		}
	}
}
