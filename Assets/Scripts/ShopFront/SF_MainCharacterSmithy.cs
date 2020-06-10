using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SF_MainCharacterSmithy : MonoBehaviour
{

    //Movement variables
    int speed = 5;
    Vector3[] targets = { new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f) };
    int numberOfTargets;
    bool isMoving = false;

    Animator myAnimator;

    bool canControl = false;

    GameObject table;

    CameraScript cameraScript;

    public List<Vector3> pathDoorTable = new List<Vector3>(new Vector3[] {
        new Vector3(15.68f, 4.93f, 0f),
        new Vector3(14.22f, 4.27f, 0f),
        new Vector3(9.56f, 4.27f, 0f)
    });

    // Use this for initialization
    void Start()
    {
        isMoving = true;
        myAnimator = GetComponent<Animator>();
        SetTarget(pathDoorTable[0], pathDoorTable[1], pathDoorTable[2]);
        table = GameObject.FindGameObjectWithTag("SF_Table");
        GameObject cameraObj = GameObject.FindGameObjectWithTag("MainCamera");
        cameraScript = (CameraScript)cameraObj.GetComponent(typeof(CameraScript));

    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {

            if (MoveTowards(targets[numberOfTargets]))
            {

                numberOfTargets -= 1;
                if (targets[numberOfTargets].x < transform.position.x)
                {

                    transform.localScale = new Vector3(-1f, 1, 1);
                }
                else
                {

                    transform.localScale = new Vector3(1f, 1, 1);

                }
                if (numberOfTargets == 0)
                {
                    myAnimator.SetBool("Walking", false);
                    isMoving = false;
                    canControl = true;
                    targets[0] = gameObject.transform.position;
                    CheckTask();
                }
                else if (targets[numberOfTargets] == new Vector3(11.48f, 10.02f, 0f) && targets[1] == new Vector3(2.65f, 10.04f, 0f))// checks if the player is headed for the door
                {
                    cameraScript.SetTarget(new Vector3(4.13f, 11.09f, -10f), 2f);
                }

            }

        }

    }

    public bool GetControl()
    {

        return canControl;

    }
    public void SetControl(bool toSet)
    {

        canControl = toSet;

    }
    public float GetTask()
    {

        return transform.position.x;

    }

    void CheckTask()
    {

        if (transform.position.x == 9.26f)
        {

            canControl = false;
            gameObject.SetActive(false);

        }
        else if(transform.position.x == 7f)
        {
            canControl = false;
            gameObject.SetActive(false);
        }
        else if(transform.position.x == 3.34f)
        {

            canControl = false;
            gameObject.SetActive(false);

        }

    }

    public void DoorToTable()
    {
        SetTarget(pathDoorTable[0], pathDoorTable[1], pathDoorTable[2]);

    }

    public void TableToDoor()
    {
        SetTarget(pathDoorTable[2], pathDoorTable[1], pathDoorTable[0]);

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
        myAnimator.SetBool("Walking", true);
        targets[1] = target;
        isMoving = true;
        canControl = false;
        numberOfTargets = 1;

        if (targets[numberOfTargets].x < transform.position.x)
        {

            transform.localScale = new Vector3(-1f, 1, 1);
        }
        else
        {

            transform.localScale = new Vector3(1f, 1, 1);

        }
    }
    public void SetTarget(Vector3 target1, Vector3 target2)
    {
        myAnimator.SetBool("Walking", true);
        targets[1] = target2;
        targets[2] = target1;
        isMoving = true;
        canControl = false;
        numberOfTargets = 2;

        if (targets[numberOfTargets].x < transform.position.x)
        {

            transform.localScale = new Vector3(-1f, 1, 1);
        }
        else
        {

            transform.localScale = new Vector3(1f, 1, 1);

        }
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

        if (targets[numberOfTargets].x < transform.position.x)
        {

            transform.localScale = new Vector3(-1f, 1, 1);
        }
        else
        {

            transform.localScale = new Vector3(1f, 1, 1);

        }
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

        if (targets[numberOfTargets].x < transform.position.x)
        {

            transform.localScale = new Vector3(-1f, 1, 1);
        }
        else
        {

            transform.localScale = new Vector3(1f, 1, 1);

        }
    }
}
