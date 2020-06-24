using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharpeningAlghoritm : MonoBehaviour {

	// Use this for initialization
	void Start () {	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (MouseToLeft())
		{
			if (transform.rotation.z < 0.2f)
			{
				transform.Rotate (new Vector3 (0, 0, 10) * Time.deltaTime);
			}
		}
		else
		{
			if (transform.rotation.z > -0.2f)
			{
				transform.Rotate (new Vector3 (0, 0, -10) * Time.deltaTime);
			}
		}

	}

	bool MouseToLeft()
	{

		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		return transform.position.x > mousePosition.x;

	}

}
