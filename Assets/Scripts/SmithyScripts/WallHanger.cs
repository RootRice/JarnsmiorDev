using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHanger : MonoBehaviour {

    GameObject mainCharacter;
    GameObject anvil;

    CameraScript cameraScript;
    MainCharacterSmithy mainCharacterScript;
    MCFurnace myHeat;

    GameObject heatUI;

    // Use this for initialization
    void Start ()
    {
		mainCharacter = GameObject.FindGameObjectWithTag("MainCharacterSmithy");
        mainCharacterScript = (MainCharacterSmithy)mainCharacter.GetComponent(typeof(MainCharacterSmithy));
        GameObject cameraObj = GameObject.FindGameObjectWithTag("MainCamera");
        cameraScript = (CameraScript)cameraObj.GetComponent(typeof(CameraScript));
        anvil = GameObject.FindGameObjectWithTag("Anvil");
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
        if (mainCharacterScript.GetTask() == 8.11f)
        {
            anvil.GetComponent<BoxCollider2D>().enabled = true;
            if (bevelSmith != null)
            {
                bevelSmith.SetActive(false);

            }
            else if(anvilSmith!= null)
            {
                anvilSmith.SetActive(false);
                ElongateUI myElongateUI = (ElongateUI)anvilSmith.GetComponentInChildren(typeof(ElongateUI));
                if (myElongateUI.GetCounter() == 10)
                {

                    mainCharacterScript.SetAnvilType(true);

                }
            }
        }
        else if (furnaceSmith != null)
        {
            heatUI = GameObject.FindGameObjectWithTag("HeatUI");
            myHeat = (MCFurnace)heatUI.GetComponentInChildren(typeof(MCFurnace));
            
            myHeat.setHeat(-0.01f);
            furnaceSmith.SetActive(false);
        }
        mainCharacterScript.StopAction();

        
        
        
        cameraScript.SetTarget(new Vector3(11.45f, 7.31f, -10), 6.31f);
         
    }
}
