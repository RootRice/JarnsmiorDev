using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilSmithy : MonoBehaviour {


    MainCharacterSmithy mainCharacterScript;
    // Use this for initialization
    void Start ()
    {

        GameObject mainCharacter = GameObject.FindGameObjectWithTag("MainCharacterSmithy");
        mainCharacterScript = (MainCharacterSmithy)mainCharacter.GetComponent(typeof(MainCharacterSmithy));

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnMouseDown()
    {
        if (mainCharacterScript != null)
        {

            //mainCharacterScript.SetTarget;
            mainCharacterScript.SetTarget(new Vector3(157.7f, 138.7f, 0));

        }
    }
}
