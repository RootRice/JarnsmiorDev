using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterSmithy : MonoBehaviour
{

    //Movement variables
    int speed = 5;
    Vector3[] targets = { new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f) };
    int numberOfTargets;
    bool isMoving = false;

	// Use this for initialization
	void Start ()
    {
        isMoving = true;
        SetTarget(new Vector3(11.48f, 10.02f, 0f), new Vector3(16.18f, 5.04f, 0f), new Vector3(19.18f, 5.04f, 0f));
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (isMoving)
        {
            
            if(MoveTowards(targets[numberOfTargets]))
            {

                numberOfTargets -= 1;
                if (numberOfTargets == 0)
                {

                    isMoving = false;
                    targets[0] = gameObject.transform.position;

                }

            }

        }
        
	}

    bool MoveTowards(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position == target)
        {

            return true;

        }
        else
        {

            return false;

        }

    }

    public void SetTarget(Vector3 target)
    {
        targets[1] = target;
        isMoving = true;
        numberOfTargets = 1;
    }
    public void SetTarget(Vector3 target1, Vector3 target2)
    {

        targets[1] = target2;
        targets[2] = target1;
        isMoving = true;
        numberOfTargets = 2;
    }
    public void SetTarget(Vector3 target1, Vector3 target2, Vector3 target3)
    {

        targets[1] = target3;
        targets[2] = target2;
        targets[3] = target1;
        isMoving = true;
        numberOfTargets = 3;
    }
    public void SetTarget(Vector3 target1, Vector3 target2, Vector3 target3, Vector3 target4)
    {

        targets[1] = target4;
        targets[2] = target3;
        targets[3] = target2;
        targets[4] = target1;
        isMoving = true;
        numberOfTargets = 4;
    }
}
