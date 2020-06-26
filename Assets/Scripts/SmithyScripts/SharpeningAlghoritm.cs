using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharpeningAlghoritm : MonoBehaviour {


	private int rangeImproverD = 15;
	private int rangeImproverR = 5;
	private float degress = 0.15f;
	private float speed = 1.0f; //how fast it shakes
	private float amount = 1.0f; //how much it shakes
    private float consistency = 0f;
	private float nextActionTime = 0.0f;
	private float period = 0.1f;
	private float rotationGravity = 0.0f;

	private float startTime;
	private float elapsedTime;

    GameObject Sword;
    SwordMovement mSwordMovement;
    GameObject mainCharacter;
    MainCharacterSmithy mainCharacterScript;
    CameraScript cameraScript;

	// Use this for initialization
	void Start ()
	{	
        Sword = GameObject.FindGameObjectWithTag("Sword");
        mSwordMovement = (SwordMovement)Sword.GetComponent(typeof(SwordMovement));
		mainCharacter = GameObject.FindGameObjectWithTag("MainCharacterSmithy");
        mainCharacterScript = (MainCharacterSmithy)mainCharacter.GetComponent(typeof(MainCharacterSmithy));
        GameObject cameraObj = GameObject.FindGameObjectWithTag("MainCamera");
        cameraScript = (CameraScript)cameraObj.GetComponent(typeof(CameraScript));
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		elapsedTime = Time.time - startTime;
		if(!mSwordMovement.IsActionDone())
		{
			if (MouseToLeft())
			{
				if (transform.rotation.z < degress)
				{
					transform.Rotate(new Vector3(0, 0, rangePointer()) * Time.deltaTime);
				}
			}
			else
			{
				if (transform.rotation.z > -degress)
				{
					transform.Rotate(new Vector3(0, 0, (-1) * rangePointer()) * Time.deltaTime);
				}
			}
			
			RotateAction();
		}
		else
		{
			if(Mathf.Abs(transform.rotation.z) > 0.001)
			{
				transform.localRotation = Quaternion.Euler(0, 0, -transform.rotation.z);
				mSwordMovement.ResetAxisX();
			}
			if(mSwordMovement.IsItemInPos())
			{
				mainCharacter.SetActive(true);
				mainCharacterScript.SetControl(true);
				mainCharacterScript.StopAction();
				cameraScript.SetTarget(new Vector3(11.45f, 7.31f, -10), 6.31f);
			}
		}

	}

	void RotateAction()
	{
		
		if (elapsedTime > nextActionTime)
		{
			nextActionTime += period;
			if (transform.rotation.z > -degress && rotationGravity < 0)
			{
				transform.Rotate (new Vector3 (0, 0, rotationGravity));
			}
			else if (transform.rotation.z < degress && rotationGravity >= 0)
			{
				transform.Rotate (new Vector3 (0, 0, rotationGravity));
			}
		}
		else
		{
			nextActionTime = Random.Range(1.0f, 3.0f);
			rotationGravity = Random.Range(-degress, degress) * rangeImproverR;
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

	public void SetItemLength(float length)
	{
		mSwordMovement.SetLength(length);
	}

	public void StartSharpening()
	{
		startTime = Time.time;
		transform.Rotate (new Vector3 (0, 0, 0));
	}

	public void Stop()
	{
		startTime = Time.time;
		transform.Rotate (new Vector3 (0, 0, 0));
	}

}
