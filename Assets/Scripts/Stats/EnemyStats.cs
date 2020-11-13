using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyStats : CharStats
{

    private Animator anim;

    void Start(){
        anim = GetComponent<Animator>();
    }
    public override void Die(){
        base.Die();
      Debug.Log("ouchie DEAD");
      this.GetComponent<EnemyWarriorController>().enabled = false;
      this.GetComponent<NavMeshAgent>().enabled = false;
      this.GetComponent<CapsuleCollider>().enabled = false;


      anim.SetTrigger("GotHit");
     Object.Destroy(gameObject, 3.0f);

    }
}
