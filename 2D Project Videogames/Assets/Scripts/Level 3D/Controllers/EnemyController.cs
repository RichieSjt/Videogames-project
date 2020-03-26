using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour{

    [Header("Animator")]    
    [SerializeField] private Animator anim;

    [Header("Movement targets")]
    [SerializeField] private Transform target;
    [SerializeField] private NavMeshAgent agent;

    [Header("Movement settings")]
    [SerializeField] public float lookRadius = 4f;

    void Start(){
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update(){
        //Distance between the player and the enemy
        float distanceBetween = Vector3.Distance(target.position, transform.position);

        if(distanceBetween <= lookRadius){
            agent.SetDestination(target.position);
            anim.SetBool("IsMoving", true);
        }else if(distanceBetween > lookRadius){
            anim.SetBool("Attack", false);
            anim.SetBool("IsMoving", false);
        }else if(distanceBetween <= agent.stoppingDistance){
            // Attack
            anim.SetBool("Attack", true);
        }

        if(target.position.x > transform.position.x) {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if(target.position.x < transform.position.x) {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
