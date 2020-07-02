using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class ToDoList : MonoBehaviour {

	// ToDoList mToDoList = ToDoList.GetScript();
	public static ToDoList GetScript()
	{
		return (ToDoList)GameObject.FindGameObjectWithTag("ToDoList").GetComponent(typeof(ToDoList));
	}

	private S_GameManager mGameManager;
	public Sprite toDoList1;
	public Sprite toDoList2;
	public Sprite toDoList3;
	public Sprite toDoList4;
	public Sprite toDoList5;
	public Sprite toDoList6;
	public Sprite toDoList7;

	// Use this for initialization
	void Start ()
	{
		mGameManager = S_GameManager.GetGameManagerScript();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(mGameManager.GetGameState() == S_GameManager.GameState.JustStarted)
		{
			gameObject.GetComponent<Image>().sprite = toDoList1;
		}
		else if(mGameManager.GetGameState() == S_GameManager.GameState.IngotObtained)
		{
			gameObject.GetComponent<Image>().sprite = toDoList2;
		}
		else if(mGameManager.GetGameState() == S_GameManager.GameState.IngotHeated)
		{
			gameObject.GetComponent<Image>().sprite = toDoList3;
		}
		else if(mGameManager.GetGameState() == S_GameManager.GameState.BarElongated)
		{
			gameObject.GetComponent<Image>().sprite = toDoList4;
		}
		else if(mGameManager.GetGameState() == S_GameManager.GameState.BarBevelled)
		{
			gameObject.GetComponent<Image>().sprite = toDoList5;
		}
		else if(mGameManager.GetGameState() == S_GameManager.GameState.BarSharpened)
		{
			gameObject.GetComponent<Image>().sprite = toDoList6;
		}
		else if(mGameManager.GetGameState() == S_GameManager.GameState.SwordQuenched)
		{
			gameObject.GetComponent<Image>().sprite = toDoList7;
		}
	}
}
