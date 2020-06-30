using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuenchUI : MonoBehaviour {

    Transform[] barTransforms = new Transform[4];
    float[] barLengths = new float[4];
    bool shouldShowScore = false;


	// Use this for initialization
	void Start ()
    {
        Transform[] temp = gameObject.GetComponentsInChildren<Transform>();
        int i = 0;
        foreach (Transform bar in temp)
        {
            if (bar.gameObject.transform.localPosition.x == 0.753f)
            {
                barTransforms[i] = bar;
                i++;
            }
            else if(bar.gameObject.transform.localPosition.x == -5.187f)
            {
                barTransforms[3] = bar;
            }
        }
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (shouldShowScore)
        {
            DisplayScore();
        }
	}

    public void showState(bool state)
    {

        shouldShowScore = state;

    }

    public void DisplayScore()
    {


        if(barLengths[0] > barTransforms[0].localScale.x)
        {

            barTransforms[0].localScale += new Vector3(0.005f, 0f, 0f);

        }
        else if (barLengths[1] > barTransforms[1].localScale.x)
        {

            barTransforms[1].localScale += new Vector3(0.005f, 0f, 0f);

        }
        else if (barLengths[2] > barTransforms[2].localScale.x)
        {

            barTransforms[2].localScale += new Vector3(0.005f, 0f, 0f);

        }


    }

    public void SetValues(int bar, float value, float maxValue)
    {
        float score = value / maxValue;
        Debug.Log(value);
        barLengths[bar] = score;
    }

    public void AdjustValues(int bar, float value, float maxValue)
    {

        float score = value/maxValue;
        barLengths[bar] = barLengths[bar] * score;

    }
}
