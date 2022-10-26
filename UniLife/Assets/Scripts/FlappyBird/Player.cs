using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speedFactor = 20; //doesnt work when named "speed"???, possibly a name clash with an engine variable or something.
    float horizontalInput;
    float verticalInput;
    public bool moveAllowed = true;
    public Camera mainCam;
    public Camera mapCam;

    private void Start()
    {
        mapCam.enabled = false;
        mainCam.enabled = true;
    }


    // once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.M))
        {
            if (moveAllowed)
            {
                OpenMap();
            }
            else
            {
                CloseMap();
            }
        }


        if (moveAllowed)
        {
            //float xDir = Input.GetAxis("Horizontal");
            //float zDir = Input.GetAxis("Vertical");

            //Vector3 moveDir = new Vector3(xDir, 0.0f, zDir);

            //transform.position += moveDir * speed;

            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
        }
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(horizontalInput * speedFactor, GetComponent<Rigidbody>().velocity.y, verticalInput * speedFactor);


    }

    void OpenMap()
    {
        moveAllowed = false;
        mainCam.enabled = false;
        mapCam.enabled = true;
    }

    void CloseMap()
    {
        moveAllowed = true;
        mapCam.enabled = false;
        mainCam.enabled = true;
        
    }

}
