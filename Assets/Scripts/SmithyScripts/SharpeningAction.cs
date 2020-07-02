﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharpeningAction : MonoBehaviour {

    GameObject swordHolder;
    GameObject grindStone;
    GameObject mainCharacter;
    SharpeningAlghoritm mSharpeningAlghoritm;
    Animator grindStoneAnimator;


    // Use this for initialization
    void Start ()
    {
        mainCharacter = GameObject.FindGameObjectWithTag("MainCharacterSmithy");
        swordHolder = GameObject.FindGameObjectWithTag("SwordHolder");
        mSharpeningAlghoritm = (SharpeningAlghoritm)swordHolder.GetComponent(typeof(SharpeningAlghoritm));
        grindStone = GameObject.FindGameObjectWithTag("Grindstone");
        grindStoneAnimator = grindStone.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Stop()
	{
        PlayerPrefs.SetFloat("Fade", 0f);
        grindStone.GetComponent<BoxCollider2D>().enabled = true;
        mainCharacter.SetActive(true);
        grindStoneAnimator.SetBool("IsSharpening", false);
        mSharpeningAlghoritm.Stop();
	}

	public SharpeningAction SetItemLength(float length)
	{
		mSharpeningAlghoritm.SetItemLength(length);
		return this;
	}

	public void StartSharpeningAction()
	{
        PlayerPrefs.SetFloat("Fade", 0.7f);
        grindStone.GetComponent<BoxCollider2D>().enabled = false;
        mainCharacter.SetActive(false);
        grindStoneAnimator.SetBool("IsSharpening", true);
        SetItemLength(PlayerPrefs.GetFloat("SwordLength"));
		mSharpeningAlghoritm.StartSharpening();		
	}



}
