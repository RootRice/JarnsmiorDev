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

	private float startTime;
	private float elapsedTime;

    GameObject Sword;
    SwordMovement mSwordMovement;

	// Use this for initialization
	void Start ()
	{	
        Sword = GameObject.FindGameObjectWithTag("Sword");
        mSwordMovement = (SwordMovement)Sword.GetComponent(typeof(SwordMovement));
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		elapsedTime = Time.time - startTime;
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

		mSwordMovement.SetRotation(transform.rotation.z);

	}

	void RotateAction()
	{
		
		if (elapsedTime > nextActionTime)
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

	public void Restart()
	{
		startTime = Time.time;
		transform.Rotate (new Vector3 (0, 0, 0));
	}

	public void Stop()
	{
		startTime = Time.time;
		transform.Rotate (new Vector3 (0, 0, 0));
	}

}
