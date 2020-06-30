using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterSmithy : MonoBehaviour
{

    //Movement variables
    int speed = 5;
    Vector3[] targets = { new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f) };
    int numberOfTargets;
    bool isMoving = false;

    Animator myAnimator;

    bool canControl = false;
    bool elongateOrBevel = false;

    GameObject anvilSmith;
    GameObject furnaceSmith;
    GameObject bookSmith;
    GameObject elongateUI;
    GameObject grindstoneSmith;
    GameObject heatUI;

    private SharpeningAction mSharpeningAction;
    GameObject bevelUI;

    CameraScript cameraScript;

    Renderer myRenderer;

    int stage;

    // Use this for initialization
    void Start()
    {
        isMoving = true;
        myAnimator = GetComponent<Animator>();
        myRenderer = GetComponent<Renderer>();
        SetTarget(new Vector3(12.48f, 10.02f, 0f), new Vector3(17.18f, 5.04f, 0f), new Vector3(19.68f, 5.04f, 0f));
        anvilSmith = GameObject.FindGameObjectWithTag("MCAnvil");
        furnaceSmith = GameObject.FindGameObjectWithTag("MCFurnace");
        bookSmith = GameObject.FindGameObjectWithTag("MCBook");
        grindstoneSmith = GameObject.FindGameObjectWithTag("SharpeningAction");
        bevelUI = GameObject.FindGameObjectWithTag("MCBevel");
        heatUI = GameObject.FindGameObjectWithTag("HeatUI");
        mSharpeningAction = (SharpeningAction)grindstoneSmith.GetComponent(typeof(SharpeningAction));
        bookSmith.SetActive(false);
        anvilSmith.SetActive(false);
        furnaceSmith.SetActive(false);
        grindstoneSmith.SetActive(false);
        bevelUI.SetActive(false);
        heatUI.SetActive(false);
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
                else if (targets[numberOfTargets] == new Vector3(12.98f, 10.02f, 0f) && targets[1] == new Vector3(2.65f, 10.04f, 0f))// checks if the player is headed for the door
                {
                    cameraScript.SetTarget(new Vector3(4.13f, 11.09f, -10f), 2f);
                }

                if(transform.position == new Vector3(19.68f, 5.04f, 0f))
                {
                    if (numberOfTargets == 0)
                    {

                        myRenderer.sortingOrder = 5;

                    }
                    else
                    {
                        myRenderer.sortingOrder = 0;

                    }

                }

            }

        }
        else
        {
            if(grindstoneSmith.activeSelf)
            {
                transform.localScale = new Vector3(-1f, 1, 1);
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

            if (!elongateOrBevel)
            {
                canControl = false;
                anvilSmith.SetActive(true);
                gameObject.SetActive(false);
            }
            else
            {
                canControl = false;
                bevelUI.SetActive(true);
                gameObject.SetActive(false);

            }

        }
        else if(transform.position.x == 7f)
        {
            MCFurnace myHeat = (MCFurnace)heatUI.GetComponentInChildren(typeof(MCFurnace));
            myHeat.setHeat(0.1f);
            canControl = false;
            furnaceSmith.SetActive(true);
            gameObject.SetActive(false);
        }
        else if(transform.position.x == 3.34f)
        {

            canControl = false;
            bookSmith.SetActive(true);
            gameObject.SetActive(false);

        }
        else if(transform.position.x == 15.5f)
        {

            canControl = false;
            grindstoneSmith.SetActive(true);
            mSharpeningAction.Restart();

        }
        else if (transform.position.x == 2.24f)
        {
            canControl = true;
            heatUI.SetActive(true);
        }
        else if(transform.position.x == 14.58f)
        {

            GameObject scoreManager = GameObject.FindGameObjectWithTag("ScoreManager");
            QuenchUI myQuenchUI = (QuenchUI)scoreManager.GetComponent(typeof(QuenchUI));
            myQuenchUI.showState(true);

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

    public void StopAction()
    {
        if(anvilSmith.activeSelf)
        {
            anvilSmith.SetActive(false);
        }
        if(furnaceSmith.activeSelf)
        {
            furnaceSmith.SetActive(false);
        }
        if(grindstoneSmith.activeSelf)
        {
            grindstoneSmith.SetActive(false);
            mSharpeningAction.Stop();
        }
    }

    public void SetAnvilType(bool type)
    {

        elongateOrBevel = type;

    }

}
