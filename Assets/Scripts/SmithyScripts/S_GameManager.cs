using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_GameManager : MonoBehaviour {

	// S_GameManager mGameManager = S_GameManager.GetGameManagerScript();

	public static S_GameManager GetGameManagerScript()
	{
		return (S_GameManager)GameObject.FindGameObjectWithTag("S_GameManager").GetComponent(typeof(S_GameManager));
	}

    public enum GameState : ushort
    {
        JustStarted = 0,
        IngotObtained = 1,
        IngotHeated = 2,
        BarElongated = 3,
        BarBevelled = 4,
        BarSharpened = 5,
        SwordQuenched = 6
    }
	private GameState mGameState;
	// Use this for initialization
	void Start ()
	{
		mGameState = GameState.JustStarted;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void SetGameState(GameState mGameState)
	{
		this.mGameState = mGameState;
	}

	public GameState GetGameState()
	{
		return this.mGameState;
	}

	public void NextGameState()
	{
		if(mGameState != GameState.SwordQuenched)
		{
			mGameState++;
		}
	}

}
