using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharpeningAlghoritm : MonoBehaviour {


	int rangeImproverD = 15;
	float speed = 1.0f; //how fast it shakes
	float amount = 1.0f; //how much it shakes
    float consistency = 0f;
	private float nextActionTime = 0.0f;
	private float period = 0.1f;

	// Use this for initialization
	void Start () {	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (MouseToLeft())
		{
			if (transform.rotation.z < 0.2f)
			{
				transform.Rotate (new Vector3 (0, 0, rangePointer()) * Time.deltaTime);
			}
		}
		else
		{
			if (transform.rotation.z > -0.2f)
			{
				transform.Rotate (new Vector3 (0, 0, (-1) * rangePointer()) * Time.deltaTime);
			}
		}
		
		RotateAction();
		transform.Rotate (new Vector3 (0, 0, Random.Range(-0.1f, 0.1f) * rangeImproverD));

	}

	void RotateAction()
	{
		
		if (Time.time > nextActionTime)
		{
			nextActionTime += period;
		}
		else
		{
			print("done");
		}

	}

	bool MouseToLeft()
	{

		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		return transform.position.x > mousePosition.x;

	}

	float rangePointer()
	{

		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		return rangeImproverD * Mathf.Abs(transform.position.x - mousePosition.x);

	}

}
