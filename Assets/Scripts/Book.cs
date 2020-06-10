﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour {



    public Sprite[] pages;

    int currentPage = 0;
    SpriteRenderer myRenderer;

    GameObject mainCharacter;

    CameraScript cameraScript;
    MainCharacterSmithy mainCharacterScript;

    // Use this for initialization
    void Start ()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        mainCharacter = GameObject.FindGameObjectWithTag("MainCharacterSmithy");
        mainCharacterScript = (MainCharacterSmithy)mainCharacter.GetComponent(typeof(MainCharacterSmithy));
        GameObject cameraObj = GameObject.FindGameObjectWithTag("MainCamera");
        cameraScript = (CameraScript)cameraObj.GetComponent(typeof(CameraScript));
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ModifyPage(int goToPage)
    {

        myRenderer.sprite = pages[goToPage];

    }
    public void ModifyPage(bool switchPage)
    {

        if (switchPage && currentPage < 3)
        {

            currentPage += 1;

        }
        else if(!switchPage && currentPage > 0)
        {

            currentPage -= 1;

        }

        myRenderer.sprite = pages[currentPage];
    }

    void OnMouseDown()
    {
        mainCharacter.SetActive(true);
        mainCharacterScript.SetControl(true);
        cameraScript.SetPosition(new Vector3(2.56f, 5.49f, -10f), 0.68f);
        cameraScript.SetTarget(new Vector3(11.45f, 7.31f, -10), 6);

    }
}
