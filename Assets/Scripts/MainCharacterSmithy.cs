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

    Animator myAnimator;

    bool canControl = true;

    GameObject anvilSmith;

	// Use this for initialization
	void Start ()
    {
        isMoving = true;
        myAnimator = GetComponent<Animator>();
        SetTarget(new Vector3(11.48f, 10.02f, 0f), new Vector3(16.18f, 5.04f, 0f), new Vector3(19.18f, 5.04f, 0f));
        anvilSmith = GameObject.FindGameObjectWithTag("MCAnvil");
        anvilSmith.SetActive(false);

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
                    myAnimator.SetBool("Walking", false);
                    isMoving = false;
                    canControl = true;
                    targets[0] = gameObject.transform.position;
                    CheckTask();

                }

            }

        }
        
	}

    void CheckTask()
    {

        if (transform.position.x == 5.93f)
        {

            canControl = false;
            anvilSmith.SetActive(true);
            gameObject.SetActive(false);

        }

    }

    bool MoveTowards(Vector3 target)
    {
        
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if(target.x < transform.position.x)
        {

            transform.localScale = new Vector3(-1f, 1, 1);
        }
        else
        {

            transform.localScale = new Vector3(1f, 1, 1);

        }
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
        myAnimator.SetBool("Walking", true);
        targets[1] = target;
        isMoving = true;
        canControl = false;
        numberOfTargets = 1;
    }
    public void SetTarget(Vector3 target1, Vector3 target2)
    {
        myAnimator.SetBool("Walking", true);
        targets[1] = target2;
        targets[2] = target1;
        isMoving = true;
        canControl = false;
        numberOfTargets = 2;
    }
    public void SetTarget(Vector3 target1, Vector3 target2, Vector3 target3)
    {
        myAnimator.SetBool("Walking", true);
        targets[1] = target3;
        targets[2] = target2;
        targets[3] = target1;
        isMoving = true;
        canControl = false;
        numberOfTargets = 3;
    }
    public void SetTarget(Vector3 target1, Vector3 target2, Vector3 target3, Vector3 target4)
    {
        myAnimator.SetBool("Walking", true);
        targets[1] = target4;
        targets[2] = target3;
        targets[3] = target2;
        targets[4] = target1;
        isMoving = true;
        canControl = false;
        numberOfTargets = 4;
    }
}
