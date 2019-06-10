using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{

    public GameObject bullet;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(bullet,this.transform.position, this.transform.rotation);
            bullet.transform.forward = this.transform.forward;

        }
    }
}
