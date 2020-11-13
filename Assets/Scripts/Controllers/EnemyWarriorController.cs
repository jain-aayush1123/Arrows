using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyWarriorController : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;
    public float attackRadius = 1f;
    private Animator anim;
    private bool deliveredAttack = false;


    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);

        float distance = Vector3.Distance(target.position, transform.position);
        if(distance <= attackRadius && !deliveredAttack){
            deliveredAttack = true;
            CharStats stats = target.GetComponent<CharStats>();
            anim.Play("Warrior_Attack");
            stats.TakeDamage(100);
        }
    }
}
