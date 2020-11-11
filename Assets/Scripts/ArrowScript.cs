using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public int damage;
    private Rigidbody rb;
    private Transform transform;
    private bool isCollided = false;

    int delay = 2; //This implies a delay of 2 seconds.

    void Awake(){
        rb = gameObject.GetComponent<Rigidbody>();
        transform = gameObject.GetComponent<Transform>();

        Debug.Log("*********************arise");

    }

    void OnCollisionEnter(Collision col){
        if(!isCollided){
            isCollided = true;
            if (col.gameObject.tag != "Arrow")
            {
                rb.isKinematic = true;
                transform.parent = col.gameObject.transform;
                Debug.Log("ouch");
            } else {
                rb.useGravity = true;
            }

            if(col.gameObject.tag != "Enemy"){
                Object.Destroy(gameObject, 2.0f);
            }
        }



        // if(Input.GetKeyDown("Fire1")){
        //     Debug.Log("hit");
            // if(col.GetComponent<EnemyStats>()){
            //     EnemyStats stats = col.GetComponent<EnemyStats>();
            //     stats.Hit(damage);
            // }
        // }
    }


}
