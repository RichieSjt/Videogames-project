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

    [Header("Health")]
    [SerializeField] public int maxHealth = 100;

    [Header("Attack Settings")]
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private int attackDamage = 40;
    [SerializeField] private float attackRate = 2f;
    private float nextAttackTime = 0f;

    public HealthSystem healthSystem;

    void Start(){
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        healthSystem = new HealthSystem(maxHealth);
    }

    void Update(){
        float distanceBetween = Vector3.Distance(target.position, transform.position);
        
        if(distanceBetween <= lookRadius){
            agent.SetDestination(target.position);
            anim.SetBool("IsMoving", true);
        }else if(distanceBetween > lookRadius){
            anim.SetBool("IsMoving", false);
        }

        if(distanceBetween <= 0.8f){
            if (Time.time >= nextAttackTime) {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }



        if(target.position.x > transform.position.x) {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if(target.position.x < transform.position.x) {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    private void Attack()
    {
        anim.SetTrigger("Attack");

        //Detect player in range of attack
        Collider[] hitPlayer = Physics.OverlapSphere(attackPoint.position, attackRange, playerLayer);

        //Damage player
        foreach (Collider player in hitPlayer)
        {
            player.GetComponent<PlayerController>().TakeDamage(attackDamage);
        }
    }

    public void TakeDamage(int damage)
    {
        healthSystem.TakeDamage(damage);
        //Debug.Log("Enemy health: "+currentHealth);
        anim.SetTrigger("Hurt");

        if(healthSystem.GetHealth() <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        anim.SetBool("IsDead", true);

        //Disable enemy
        GetComponent<CapsuleCollider>().enabled = false;
        this.enabled = false;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
