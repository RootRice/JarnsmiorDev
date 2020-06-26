using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharpeningAlghoritm : MonoBehaviour {


	private int rangeImproverD = 30;
	private int rangeImproverR = 10;
	private float speed = 0.5f; //how fast it shakes
	private float amount = 1.0f; //how much it shakes
    private float consistency = 0f;
	public float nextActionTime = 0.0f;
	private float period = 0.1f;
    public float rotationGravityLerp = 0.0f;
	public float rotationGravity = 0.0f;

    private float adjustTimer = 0f;

	private float startTime;
	public float elapsedTime = 0f;

    GameObject Sword;
    SwordMovement mSwordMovement;

    float[] hitStore = new float[10];
    int counter = 0;

    // Use this for initialization
    void Start ()
	{	
        Sword = GameObject.FindGameObjectWithTag("Sword");
        mSwordMovement = (SwordMovement)Sword.GetComponent(typeof(SwordMovement));
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (mSwordMovement.GetMouseDown())
        {
            elapsedTime += Time.deltaTime;
            if (MouseToLeft())
            {
                if (transform.rotation.z < 0.2f)
                {
                    transform.Rotate(new Vector3(0, 0, rangePointer()) * Time.deltaTime);
                }
            }
            else
            {
                if (transform.rotation.z > -0.2f)
                {
                    transform.Rotate(new Vector3(0, 0, (-1) * rangePointer()) * Time.deltaTime);
                }
            }
            if (rotationGravity < rotationGravityLerp)
            {

                if (adjustTimer > 0.03f)
                {
                    adjustTimer = 0;
                    rotationGravity += 0.01f;
                }
                else
                {

                    adjustTimer += Time.deltaTime;

                }

            }
            else if (rotationGravity > rotationGravityLerp)
            {

                if (adjustTimer > 0.03f)
                {
                    adjustTimer = 0;
                    rotationGravity -= 0.01f;
                }
                else
                {

                    adjustTimer += Time.deltaTime;

                }

            }

            RotateAction();
        }

	}

	void RotateAction()
	{
		
		if (elapsedTime < nextActionTime)
		{
			if (transform.rotation.z > -0.2f && rotationGravity < 0)
			{
				transform.Rotate (new Vector3 (0, 0, rotationGravity));
			}
			else if (transform.rotation.z < 0.2f && rotationGravity >= 0)
			{
				transform.Rotate (new Vector3 (0, 0, rotationGravity));
			}
		}
		else
		{
            elapsedTime = 0f;
			nextActionTime = Random.Range(1.0f, 3.0f);
			rotationGravityLerp = Random.Range(-0.2f, 0.2f) * rangeImproverR;
            hitStore[counter] = transform.rotation.z;
            //Debug.Log(transform.rotation.z);
            counter += 1;
            if(counter >= 10)
            {

                CalculateScore();

            }
		}

	}

	bool MouseToLeft()
	{

		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		return transform.position.x > mousePosition.x;

	}

	float rangePointer()
	{

		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		return rangeImproverD * Mathf.Abs(transform.position.x - mousePosition.x);

	}

	public void Restart()
	{
		startTime = Time.time;
		transform.Rotate (new Vector3 (0, 0, 0));
		mSwordMovement.SetSize(2.0f);
	}

	public void Stop()
	{
		startTime = Time.time;
		transform.Rotate (new Vector3 (0, 0, 0));
	}

    void CalculateScore()
    {
        float totalVal;
        float consistencyVal = 0;
        float totalScore = 0;
        float calculator = 0;
        float angleCalculator = 0;
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
            angleCalculator += Mathf.Abs(hitStore[i]);

        }

        totalVal = calculator*10;
        calculator = totalVal / counter;
        //Debug.Log(angleCalculator);
        angleCalculator = (angleCalculator * 100) / counter;
        //Debug.Log(angleCalculator);
        consistencyVal += Mathf.Abs(calculator - minVal);
        consistencyVal += Mathf.Abs(calculator - maxVal);
        totalScore += 50 - (angleCalculator*3);
        print(consistencyVal);
        print(calculator);
        print(totalScore);



    }

}
