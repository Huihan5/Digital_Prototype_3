using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    public Camera myCam;

    public float camMinSize = 2f;
    public float camMaxSize = 8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Changing Camera Size
        if (Input.GetKey(KeyCode.Q)) 
        {
            myCam.orthographicSize = myCam.orthographicSize + 1 * Time.deltaTime;

            if (myCam.orthographicSize > camMaxSize)
            {
                myCam.orthographicSize = camMaxSize;
            }
        }

        if (Input.GetKey(KeyCode.E))
        {
            myCam.orthographicSize = myCam.orthographicSize - 1 * Time.deltaTime;

            if (myCam.orthographicSize < camMinSize)
            {
                myCam.orthographicSize = camMinSize;
            }
        }

    }
}
