using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    [Header("Animator")]    
    public Animator anim;

    [Header("Movement targets")]
    private Transform target;
    private NavMeshAgent agent;
    
    [Header("Movement settings")]
    public float lookRadius = 0;
    
    [Header("Health")]
    private HealthSystem healthSystem;
    public int maxHealth = 100;

    [Header("Attack Settings")]
    public GameObject hitBox;
    public float attackTime = 0;
    public int attackDamage = 50;
    public float attackRate = 2f;
    private float nextAttackTime = 0f;

    [Header("Sprite Facing")]
    public bool isFacingToRight;

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        healthSystem = GetComponent<HealthSystem>();
        healthSystem.maxHealth = maxHealth;
    }

    void Update()
    {
        EnemyAIController();
    }

    private void EnemyAIController()
    {
        float distanceBetween = Vector3.Distance(target.position, transform.position);
        
        if(distanceBetween <= lookRadius)
        {
            agent.SetDestination(target.position);
            anim.SetBool("IsMoving", true);
        }
        else if(distanceBetween > lookRadius)
        {
            anim.SetBool("IsMoving", false);
        }
        if(distanceBetween <= 0.8f)
        {
            if (Time.time >= nextAttackTime)
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

        if (isFacingToRight){
            if(target.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            if(target.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
        else
        {
            if(target.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            if(target.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
    }

    private void Attack()
    {
        anim.SetTrigger("Attack");
        hitBox.GetComponent<HitBox>().EnableHitBox();

        Collider hittedEnemy = hitBox.GetComponent<HitBox>().GetHittedObject("Player");
        if (hittedEnemy != null)
            hittedEnemy.GetComponent<EnemyController>().TakeDamage(attackDamage);

        hitBox.GetComponent<HitBox>().DisableHitBox(attackTime);
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
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
