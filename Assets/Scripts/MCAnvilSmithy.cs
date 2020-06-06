using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCAnvilSmithy : MonoBehaviour {

    Animator myAnimator;
    // Use this for initialization
    void Start ()
    {
        myAnimator = GetComponent<Animator>();
        myAnimator.ResetTrigger("Slam");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        Debug.Log("Works!");
        myAnimator.SetTrigger("Slam");
       // myAnimator.ResetTrigger("Slam");
    }
}
