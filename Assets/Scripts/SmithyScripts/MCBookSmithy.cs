using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCBookSmithy : MonoBehaviour {

    Animator myAnimator;
    CameraScript cameraScript;
    // Use this for initialization
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        GameObject cameraObj = GameObject.FindGameObjectWithTag("MainCamera");
        cameraScript = (CameraScript)cameraObj.GetComponent(typeof(CameraScript));

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (myAnimator.GetCurrentAnimatorStateInfo(0).IsName("BookIdle"))
        {
            cameraScript.SetTarget(new Vector3(52f, 18.39f, -10f), 6.07f);
            cameraScript.SetPosition(new Vector3(52f, 18.39f, -10f), 6.07f);
            gameObject.SetActive(false);
        }
    }
}
