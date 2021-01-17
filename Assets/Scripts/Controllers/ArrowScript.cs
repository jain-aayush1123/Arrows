using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public int damage;
    // public GameObject ArrowCollecter;
    private Rigidbody rb;
    private Transform transform;
    private bool isCollided = false;

    int delay = 2; //This implies a delay of 2 seconds.

    void Awake(){
        rb = gameObject.GetComponent<Rigidbody>();
        transform = gameObject.GetComponent<Transform>();
        transform.rotation = Quaternion.LookRotation(rb.velocity);

    }

    void Update(){
        if(!isCollided){
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }
    }

    void OnCollisionEnter(Collision col){
        if(!isCollided){
            isCollided = true;
            if (col.gameObject.tag != "Arrow")
            {
                // rb.isKinematic = true;
                // transform.parent = ArrowCollecter.transform;
                rb.constraints = RigidbodyConstraints.FreezeAll;
                Debug.Log("arrow hit");
            } else {
                rb.useGravity = true;
            }

            if(col.gameObject.tag != "Enemy"){
                Object.Destroy(gameObject, 2.0f);
            } else {
                Object.Destroy(gameObject);
            }
        }

        if(col.gameObject.GetComponent<EnemyStats>()){
            EnemyStats stats = col.gameObject.GetComponent<EnemyStats>();
            stats.TakeDamage(damage);
        }
    }


}
