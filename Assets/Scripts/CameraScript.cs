using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    // Use this for initialization
    bool toMove;
    float moveTime;
    int numberOfTargets;
    Vector3[] targets = { new Vector3(0f, 0f, -10f), new Vector3(0f, 0f, -10f) };

    Vector3 defaultPosition = new Vector3(11.45f, 7.31f, -10);

    float cameraZoom = 1;

    private Camera gameCamera;

    float speed = 1;

    void Start ()
    {
        gameCamera = gameObject.GetComponent<Camera>();
        SetTarget(new Vector3(11.45f, 7.31f, -10));


    }
	
	// Update is called once per frame
	void Update ()
    {
		if(toMove)
        {

            MoveTowards(targets[1], 6);

        }
	}

    public void SetTarget(Vector3 target)
    {
        targets[1] = target;
        toMove = true;
        numberOfTargets = 1;
    }
    public void SetTarget(Vector3 target1, Vector3 target2)
    {

        targets[1] = target2;
        targets[2] = target1;
        toMove = true;
        numberOfTargets = 2;
    }

    void MoveTowards(Vector3 target, float zoom)
    {
        //Movement control
        speed = Mathf.Abs((target.x + target.y) - (transform.position.x + transform.position.y));
        if (speed < 1f)
        {

            speed = 1f;

        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * 1.5f * Time.deltaTime);

        //Zoom control
        speed = Mathf.Abs(zoom - cameraZoom);
        if (speed < 0.5f)
        {

            speed = 0.5f;

        }

        if (transform.position == target)
        {

            cameraZoom = zoom;
        }
        else if (cameraZoom < zoom)
        {

            cameraZoom += speed = speed * Time.deltaTime;

        }
        else if (cameraZoom > zoom)
        {
            cameraZoom -= speed = speed * Time.deltaTime;
        }



        gameCamera.orthographicSize = cameraZoom;
        

    }
}
