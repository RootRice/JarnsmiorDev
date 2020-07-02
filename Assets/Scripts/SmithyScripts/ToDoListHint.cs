using System.Collections;
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

	// Use this for initialization
	void Start ()
	{
		mGameManager = S_GameManager.GetGameManagerScript();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(mGameManager.GetTutorialState() == S_GameManager.TutorialState.Heating)
		{
			transform.localScale = new Vector3(1, 1, 1);
			gameObject.GetComponent<Image>().sprite = toDoListHint1;
		}
		else if(mGameManager.GetTutorialState() == S_GameManager.TutorialState.Elongation)
		{
			transform.localScale = new Vector3(1, 1, 1);
			gameObject.GetComponent<Image>().sprite = toDoListHint2;
		}
		else if(mGameManager.GetTutorialState() == S_GameManager.TutorialState.Bevelling)
		{
			transform.localScale = new Vector3(1, 1, 1);
			gameObject.GetComponent<Image>().sprite = toDoListHint3;
		}
		else
		{
			transform.localScale = new Vector3(0, 0, 0);
		}
	}
}
