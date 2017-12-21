using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : Plane
{
	public float speed;
	public GameObject bomb;

	private bool isLaunch = false;
    Transform thisTransform;

	public override void Go (Transform purpose)
	{
        thisTransform.LookAt(purpose);
        thisTransform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);
		gameObject.SetActive(true);
	}

	void Update ()
	{
		if (gameObject.activeSelf)
		{
            thisTransform.Translate(0f, 0f, speed * Time.deltaTime);
		}
		if (!isLaunch && EvContr.OnCheckDistance(transform.position))
		{
			isLaunch = true;
			GameObject bomber = Instantiate(bomb, transform.position, Quaternion.Euler(0f,0f,-90f)) as GameObject;
		}
		if (Vector3.Distance(transform.position, Vector3.zero) > 30f)
		{
            this.gameObject.SetActive(false);
            //Destroy(gameObject);
		}
	}

    private void Start()
    {
        thisTransform = this.transform;
    }
}
