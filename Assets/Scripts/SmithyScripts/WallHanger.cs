using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHanger : MonoBehaviour {

    GameObject mainCharacter;
   
    CameraScript cameraScript;
    MainCharacterSmithy mainCharacterScript;


    // Use this for initialization
    void Start ()
    {
		mainCharacter = GameObject.FindGameObjectWithTag("MainCharacterSmithy");
        mainCharacterScript = (MainCharacterSmithy)mainCharacter.GetComponent(typeof(MainCharacterSmithy));

        

        GameObject cameraObj = GameObject.FindGameObjectWithTag("MainCamera");
        cameraScript = (CameraScript)cameraObj.GetComponent(typeof(CameraScript));

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnMouseDown()
    {
        GameObject anvilSmith = GameObject.FindGameObjectWithTag("MCAnvil");
        GameObject furnaceSmith = GameObject.FindGameObjectWithTag("MCFurnace");
        GameObject bevelSmith = GameObject.FindGameObjectWithTag("MCBevel");
        mainCharacter.SetActive(true);
        mainCharacterScript.SetControl(true);
        if (mainCharacterScript.GetTask() == 9.26f)
        {
            if (bevelSmith != null)
            {
                bevelSmith.SetActive(false);

            }
            else
            {
                anvilSmith.SetActive(false);
            }
        }
        else if (mainCharacterScript.GetTask() == 7f)
        {
            furnaceSmith.SetActive(false);
        }
        mainCharacterScript.StopAction();

        
        
        
        cameraScript.SetTarget(new Vector3(11.45f, 7.31f, -10), 6.31f);
         
    }
}
