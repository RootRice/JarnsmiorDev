using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        print(GetComponent<Renderer>().bounds.center);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
