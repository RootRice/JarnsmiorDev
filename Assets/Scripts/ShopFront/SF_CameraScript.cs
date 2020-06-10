using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SF_CameraScript : MonoBehaviour {

    // Use this for initialization
    bool toMove;
    float moveTime;
    int numberOfTargets;
    Vector3[] targets = { new Vector3(0f, 0f, -10f), new Vector3(0f, 0f, -10f), new Vector3(0f, 0f, -10f) };

    Vector3 defaultPosition = new Vector3(15.71f, 4.99f, -10);

    float toZoom;
    bool zoomDir;


    private Camera gameCamera;


    void Start ()
    {
        gameCamera = gameObject.GetComponent<Camera>();
        //gameCamera.transform.position = new Vector3(15.96f, 5.17f, -10f);
        //gameCamera.orthographicSize = 2f;
        //SetTarget(new Vector3(13.27f, 4f, -10f), new Vector3(11.4f, 7.2f, -10f), 6);

        gameCamera.transform.position = new Vector3(11.4f, 7.2f, -10f);
        gameCamera.orthographicSize = 8f;
    }

    // Update is called once per frame
    void Update ()
    {
        /*
		if(toMove)
        {

            transform.position = Vector3.MoveTowards(transform.position, targets[numberOfTargets], 3f * Time.deltaTime);
            if(transform.position == targets[numberOfTargets])
            {

                numberOfTargets -= 1;
                if(numberOfTargets == 0)
                {

                    toMove = false;

                }

            }

        }
        if (Mathf.Abs(toZoom - gameCamera.orthographicSize) > 0.02f)
        {

            if(!zoomDir)
            {

                gameCamera.orthographicSize += 0.02f;

            }
            else
            {
                gameCamera.orthographicSize -= 0.02f;   
            }
        }
        else
        {
            gameCamera.orthographicSize = toZoom;
        }*/
	}

    public void SetTarget(Vector3 target, float zoom)
    {
        targets[1] = target;
        toMove = true;
        toZoom = zoom;
        if (toZoom > gameCamera.orthographicSize)
        {

            zoomDir = false;

        }
        else
        {

            zoomDir = true;

        }
        numberOfTargets = 1;
    }
    public void SetTarget(Vector3 target1, Vector3 target2, float zoom)
    {

        targets[1] = target2;
        targets[2] = target1;
        toMove = true;
        toZoom = zoom;
        if(toZoom > gameCamera.orthographicSize)
        {

            zoomDir = false;

        }
        else
        {

            zoomDir = true;

        }
        numberOfTargets = 2;
    }

    public void SetPosition(Vector3 position, float toZoom)
    {

        gameCamera.transform.position = position;
        gameCamera.orthographicSize = toZoom;

    }

}
