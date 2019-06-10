using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float rotX;
    public float rotY;
    public float rotZ;
    public float rotSpeed=50;
    //Vector3 playerPos;
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        //Camera Movement
        rotX -= Input.GetAxis("Mouse Y") * Time.deltaTime * rotSpeed;
        rotY += Input.GetAxis("Mouse X") * Time.deltaTime * rotSpeed;

        if (rotX < -45)
        {
            rotX = -45;
        }
        else if (rotX > 45)
        {
            rotX = 45;
        }

        /*if (rotY < -45)
        {
            rotY = -45;
        }
        else if (rotY > 45)
        {
            rotY = 45;
        }*/

        transform.rotation = Quaternion.Euler(rotX, rotY, 0);
        
        //gameObject.transform.rotation = Quaternion.Euler(rotX, rotY, 0);
    }

}
