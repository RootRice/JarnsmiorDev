﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ToDoListHint : MonoBehaviour {

	// ToDoListHint mToDoListHint = ToDoListHint.GetScript();
	public static ToDoListHint GetScript()
	{
		return (ToDoListHint)GameObject.FindGameObjectWithTag("ToDoListHint").GetComponent(typeof(ToDoListHint));
	}

	private S_GameManager mGameManager;
	public Sprite toDoListHint1;
	public Sprite toDoListHint2;
	public Sprite toDoListHint3;
    public Sprite toDoListHint4;

    RectTransform myTransform;
    public Vector3[] targets = { new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f) };
    int numberOfTargets;
    bool isMoving = false;
    float speed = 12.5f;
    bool upOrDown = true;

    // Use this for initialization
    void Start ()
	{
        myTransform = gameObject.GetComponent<RectTransform>();
		mGameManager = S_GameManager.GetGameManagerScript();
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (mGameManager.GetTutorialState() == S_GameManager.TutorialState.Heating)
        {
            transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
            gameObject.GetComponent<Image>().sprite = toDoListHint1;
        }
        else if (mGameManager.GetTutorialState() == S_GameManager.TutorialState.Elongation)
        {
            transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
            gameObject.GetComponent<Image>().sprite = toDoListHint2;
        }
        else if (mGameManager.GetTutorialState() == S_GameManager.TutorialState.Bevelling)
        {
            transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
            gameObject.GetComponent<Image>().sprite = toDoListHint3;
        }
        else if (mGameManager.GetTutorialState() == S_GameManager.TutorialState.Sharpening)
        {
            transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
            gameObject.GetComponent<Image>().sprite = toDoListHint4;
        }
        else
        {
            transform.localScale = new Vector3(0, 0, 0);
        }

        if (isMoving)
        {
            if (MoveTowards(targets[numberOfTargets]))
            {
                speed = 12.5f;
                numberOfTargets -= 1;
                Debug.Log(numberOfTargets);
                if (numberOfTargets == 0)
                {
                    speed = 12.5f;
                    upOrDown = !upOrDown;
                    isMoving = false;

                }
            }

        }
    }

    bool MoveTowards(Vector3 target)
    {

        myTransform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        speed = speed * 1.2f;


        Debug.Log(myTransform.position);
        Debug.Log(target);
        if (myTransform.position.y >= target.y && target.y > 117.4f)
        {

            return true;

        }
        else if (myTransform.position.y <= target.y+1 && target.y < 116.5f)
        {

            return true;

        }
        else
        {

            return false;

        }

    }

    public void SetTarget(Vector3 target1, Vector3 target2)
    {
        targets[1] = target2;
        targets[2] = target1;
        isMoving = true;
        numberOfTargets = 2;
    }

    public void Click()
    {
        if (upOrDown)
        {
            SetTarget(new Vector3(108.8f, 122.3f, 0f), new Vector3(108.8f, -76.7f, 0f));
        }
        else
        {
            SetTarget(new Vector3(108.8f, 122.3f, 0f), new Vector3(108.8f, 116.4f, 0f));
        }

    }
}
