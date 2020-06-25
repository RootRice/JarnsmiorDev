using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharpeningAlghoritm : MonoBehaviour {


	private int rangeImproverD = 30;
	private int rangeImproverR = 10;
	private float speed = 1.0f; //how fast it shakes
	private float amount = 1.0f; //how much it shakes
    private float consistency = 0f;
	private float nextActionTime = 0.0f;
	private float period = 0.1f;
	private float rotationGravity = 0.0f;

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

	}

	void RotateAction()
	{
		
		if (Time.time > nextActionTime)
		{
			nextActionTime += period;
			if (transform.rotation.z > -0.2f && rotationGravity < 0)
			{
				transform.Rotate (new Vector3 (0, 0, rotationGravity));
			}
			else if (transform.rotation.z < 0.2f && rotationGravity >= 0)
			{
				transform.Rotate (new Vector3 (0, 0, rotationGravity));
			}
		}
		else
		{
			nextActionTime = Random.Range(1.0f, 3.0f);
			rotationGravity = Random.Range(-0.2f, 0.2f) * rangeImproverR;
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
