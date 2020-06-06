using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElongateUI : MonoBehaviour {

    float speed;
    Vector3 bottomPosition;
    Vector3 topPosition;
    bool direction;

    float animationTimer;
    float timeToWait;

    bool slam;
    bool canSmith = true;

    float[] hitStore = new float[10];
    int counter = 0;

    float consistencyVal;
    float totalVal;
    float totalScore;

    // Use this for initialization
    void Start ()
    {
        topPosition = new Vector3(4.258f, 5.28f);
        bottomPosition = new Vector3(4.258f, 3.38f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (canSmith)
        {
            if (!slam)
            {
                CalculateSpeed();
                Move();
            }
            else
            {

                SlamDown();

            }
        }
	}

    void CalculateSpeed()
    {

        float botdist = gameObject.transform.position.y - bottomPosition.y;
        float topdist = topPosition.y - gameObject.transform.position.y;

        if (botdist > topdist)
        {
            speed = topdist * 2;
        }
        else
        {
            speed = botdist * 2;
        }

        if (speed < 0.25f)
        {
            speed = 0.25f;
        }

    }

    void Move()
    {

        if (direction)
        {

            if (gameObject.transform.position.y < topPosition.y)
            {
                transform.position = Vector3.MoveTowards(transform.position, topPosition, speed * Time.deltaTime);
            }
            else
            {
                direction = false;
            }
        }
        else if (gameObject.transform.position.y > bottomPosition.y)
        {
            transform.position = Vector3.MoveTowards(transform.position, bottomPosition, speed * Time.deltaTime);
        }
        else
        {
            direction = true;
        }

    }

    void SlamDown()
    {
        animationTimer += Time.deltaTime;
        if (animationTimer >= timeToWait)
        {
            
            if (gameObject.transform.position.y > bottomPosition.y)
            {
                transform.position = Vector3.MoveTowards(transform.position, bottomPosition, speed * Time.deltaTime);
            }

            if (animationTimer >= 0.63)
            {
                slam = false;
                animationTimer = 0;
            }

        }

    }

    public bool GetSlam()
    {

        return slam;

    }

    public float BeginSlam()
    {

        if (!slam)
        {
            slam = true;
            float botdist = gameObject.transform.position.y - bottomPosition.y;
            speed = botdist * 20;
            if (speed < 1)
            {
                timeToWait = 0.35f;
            }
            else
            {
                timeToWait = 0.25f;
            }

            hitStore[counter] = botdist;
            Debug.Log(hitStore[counter]);
            counter += 1;
            if (counter >= 10)
            {
                CalculateScore();               
            }
            return botdist;

        }

        return 0;
    }
    
    void CalculateScore()
    {
        float calculator = 0;
        float maxVal = 0;
        float minVal = 10000;
        for (int i = 0; i < 10; i++)
        {
            if (hitStore[i] > maxVal)
            {

                maxVal = hitStore[i];

            }
            if (hitStore[i] < minVal)
            {
                minVal = hitStore[i];
            }

            calculator += hitStore[i];

        }
        
        totalVal = calculator;
        calculator = totalVal / 10;
        consistencyVal += Mathf.Abs(calculator - minVal);
        consistencyVal += Mathf.Abs(calculator - maxVal);
        totalScore += 50 - (consistencyVal * 25);
        print(consistencyVal);
        print(totalVal);
        print(totalScore);
        canSmith = false;


    } 


}
