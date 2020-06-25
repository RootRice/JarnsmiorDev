using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMovement : MonoBehaviour {

	// Use this for initialization
    private Vector3 target = new Vector3(5.0f, 0.0f, 0.0f);
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// transform.localScale += new Vector3(0f,0.001f,0f);
        // transform.position = new Vector3(transform.position.x, transform.position.y-0.002f, transform.position.z);
	}

	public void SetRotation(float degrees)
	{
        transform.RotateAround(target, transform.position, degrees);
	}

}
