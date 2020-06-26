using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMovement : MonoBehaviour {

	private float PivotAxisY = 4.28f;
    bool mouseDown = false;

    // Use this for initialization
    void Start ()
	{
		transform.localScale = new Vector3(0.7f, 0.6f, 1.0f);
		transform.position = new Vector3(transform.position.x, PivotAxisY + GetComponent<Renderer>().bounds.size.y/2, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
        if (mouseDown)
        {
            if (transform.position.y < PivotAxisY - GetComponent<Renderer>().bounds.size.y / 2)
            {

            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.002f, transform.position.z);
            }
        }
	}

	public void SetSize(float length)
	{
		
		transform.localScale = new Vector3(0.7f, length/4, 1.0f);
		transform.position = new Vector3(transform.position.x, PivotAxisY + GetComponent<Renderer>().bounds.size.y/2, transform.position.z);
	}

    public bool GetMouseDown()
    {

        return mouseDown;

    }

    void OnMouseDown()
    {

        mouseDown = true;

    }
    void OnMouseUp()
    {

        mouseDown = false;

    }

}
