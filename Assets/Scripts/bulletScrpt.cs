using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScrpt : MonoBehaviour {

    private float speed = 50f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.position += transform.forward * speed * Time.deltaTime;
    }

    /*void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            Destroy(other.gameObject);
        }
    }*/
}
