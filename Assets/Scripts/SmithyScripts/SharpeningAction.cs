using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharpeningAction : MonoBehaviour {

    GameObject swordHolder;
    SharpeningAlghoritm mSharpeningAlghoritm;


	// Use this for initialization
	void Start () {
        swordHolder = GameObject.FindGameObjectWithTag("SwordHolder");
        mSharpeningAlghoritm = (SharpeningAlghoritm)swordHolder.GetComponent(typeof(SharpeningAlghoritm));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Stop()
	{
		mSharpeningAlghoritm.Stop();
	}

	public SharpeningAction SetItemLength(float length)
	{
		mSharpeningAlghoritm.SetItemLength(length);
		return this;
	}

	public void StartSharpeningAction()
	{
		mSharpeningAlghoritm.StartSharpening();		
	}



}
