using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharStats
{
    private Animator anim;
    bool isDead = false;

    void Start(){
        anim = GetComponent<Animator>();
    }
    public override void Die(){
        base.Die();
      Debug.Log("Game Over");

      // this.GetComponent<EnemyWarriorController>().enabled = false;
      // this.GetComponent<NavMeshAgent>().enabled = false;
      // this.GetComponent<CapsuleCollider>().enabled = false;

      if(!isDead){
        isDead = true;
        anim.SetTrigger("GotHit");

      }

      this.GetComponent<PlayerStats>().enabled = false;
      this.GetComponent<Legolas>().enabled = false;


     // Object.Destroy(gameObject, 3.0f);

    }
}
