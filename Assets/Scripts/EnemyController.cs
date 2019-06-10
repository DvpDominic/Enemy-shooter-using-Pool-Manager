using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyController : MonoBehaviour {

    private Rigidbody rb;
    private Animator anim;
    float speed;
    float rotSpeed;
    Vector3 moveDir = Vector3.zero;
    private float minDistance = 10;
    public Transform player;
    private Vector3 startPos;
    public float moveSpeed = 0.01f;
    public int PosId;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        startPos = rb.transform.position;

        //playerPos = player.transform.position;
        //distance = rb.transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update () {

        transform.LookAt(player);
        
        if(Vector3.Distance(rb.transform.position,player.transform.position) >= minDistance)
        {
            anim.SetTrigger("walk");
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
            rb.constraints = RigidbodyConstraints.FreezePositionY;
        }

        if(Vector3.Distance(rb.transform.position,player.transform.position) < minDistance)
        {
            anim.SetTrigger("stop");
            minDistance = 100;
        }
	}

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("bullet"))
        {
            this.gameObject.SetActive(false);
            Destroy(col.gameObject);
            EnemyPoolManager.Instance.OnKill(this.gameObject);
            
            /*this.gameObject.SetActive(false);
            StartCoroutine(resetPos());
            //rb.transform.position = startPos;*/
        }
    }

    /*IEnumerator resetPos()
    {
        yield return new WaitForSeconds(2f);
        rb.transform.position = startPos;
        this.gameObject.SetActive(true);
    }*/

}
