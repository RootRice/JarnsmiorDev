using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_GameManager : MonoBehaviour {

    public enum GameState : ushort
    {
        JustStarted = 0,
        IgnotObtained = 1,
        IgnotHeated = 2,
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

}
