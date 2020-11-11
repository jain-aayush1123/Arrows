using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public int damage;
    private Rigidbody rb;
    private Transform transform;
    void Awake(){
        rb = gameObject.GetComponent<Rigidbody>();
        transform = gameObject.GetComponent<Transform>();

        Debug.Log("*********************arise");

    }

    void OnCollisionEnter(Collision col){
        rb.isKinematic = true;
        transform.parent = col.gameObject.transform;
        Debug.Log("ouch");

        // if(Input.GetKeyDown("Fire1")){
        //     Debug.Log("hit");
            // if(col.GetComponent<EnemyStats>()){
            //     EnemyStats stats = col.GetComponent<EnemyStats>();
            //     stats.Hit(damage);
            // }
        // }
    }
}
