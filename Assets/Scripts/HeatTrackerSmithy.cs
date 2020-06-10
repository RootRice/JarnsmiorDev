using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatTrackerSmithy : MonoBehaviour {

    bool hotOrCold;
    float currentTemp = 0;

    int idealTemp;

    float currentScore;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(hotOrCold)
        {

            if(currentTemp < 100)
            {

                currentTemp += 1 * Time.deltaTime;

            }
            

        }
        else
        {

            if(currentTemp > 0)
            {

                currentTemp -= 1 * Time.deltaTime;

            }

        }
	}

    public void SetTemp(bool tempToSet)
    {

        hotOrCold = tempToSet;

    }
}
