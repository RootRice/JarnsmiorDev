using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMovement : MonoBehaviour {

	private float PivotAxisY = 4.28f;
	private float posX;
	private bool ActionDone = true;
    bool mouseDown = false;
	bool finalAnimation = false;

    // Use this for initialization
    void Start ()
	{
		posX = transform.position.x;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(transform.position.y < PivotAxisY - GetComponent<Renderer>().bounds.size.y/2  && !ActionDone)
		{
			ActionDone = true;
			finalAnimation = true;
		}
		else if(GetMouseDown())
		{
			if(transform.position.y >= PivotAxisY - GetComponent<Renderer>().bounds.size.y/2 && !ActionDone)
			{
				transform.position = new Vector3(transform.position.x, transform.position.y-0.002f, transform.position.z);
			}
		}
		else if(transform.position.y >= PivotAxisY - GetComponent<Renderer>().bounds.size.y/2 && ActionDone && finalAnimation)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y-0.02f, transform.position.z);
		}
	}

	public void SetLength(float length)
	{
		if(posX == 0)
		{
			posX = transform.position.x;
		}
		transform.localScale = new Vector3(0.7f, length/2, 1.0f);
		transform.position = new Vector3(transform.position.x, PivotAxisY + GetComponent<Renderer>().bounds.size.y/2, transform.position.z);
		ActionDone = false;
		finalAnimation = false;
	}

	public void ResetAxisX()
	{
		transform.position = new Vector3(posX, PivotAxisY + GetComponent<Renderer>().bounds.size.y/2, transform.position.z);
	}

	public bool IsActionDone()
	{
		return ActionDone;
	}

	public bool IsItemInPos()
	{
		return transform.position.y < PivotAxisY - GetComponent<Renderer>().bounds.size.y/2 && finalAnimation;
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
