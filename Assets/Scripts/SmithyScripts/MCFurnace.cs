using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCFurnace : MonoBehaviour {

    float hotOrCold = 0;
    float currentHeat = 0;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (hotOrCold != 0)
        {
            currentHeat += hotOrCold*Time.deltaTime;
        }
        if (currentHeat > 1f)
        {

            currentHeat = 1;

        }
        else if (currentHeat < 0f)
        {

            currentHeat = 0;

        }

        transform.localScale = new Vector3(currentHeat, 1f, 1f);
    }

    public void setHeat(float heatToSet)
    {

        hotOrCold = heatToSet;

    }
}
