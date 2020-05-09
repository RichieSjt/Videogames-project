using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderController : Enemy
{

    [Header("Animator")]    
    public Animator anim;
    public float attackDuration = 0.3f;
    public float deadDuration = 1.4f;

    [Header("Movement targets")]
    private Transform target;
    private NavMeshAgent agent;
    
    [Header("Movement settings")]
    public float lookRadius = 5f;
    public float speed = 4.5f;
    private Rigidbody spiderRigidbody;
    
    [Header("Health")]
    private HealthSystem healthSystem;
    public int maxHealth = 50;

    [Header("Attack Settings")]
    public GameObject hitBox;
    public int attackDamage = 10;
    public float attackRate = 5f;
    private float nextAttackTime = 0f;

    private float timeLoopSound = 0f;


    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        healthSystem = GetComponent<HealthSystem>();
        spiderRigidbody = GetComponentInChildren<Rigidbody>();
        healthSystem.maxHealth = maxHealth;
        healthSystem.health = maxHealth;
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
            agent.speed = speed;
            anim.SetBool("IsMoving", true);

            //spiderRigidbody.AddForce(Vector3.up * 20f, ForceMode.Impulse);
            if(Time.time >= timeLoopSound){
                SoundManager.PlaySound("SpiderMove", 1f);
                timeLoopSound = Time.time + 1.5f;
            }
        }
        else if(distanceBetween > lookRadius)
        {
            anim.SetBool("IsMoving", false);
            agent.speed = 0;
        }
        if(distanceBetween <= 0.8f)
        {
            if (Time.time >= nextAttackTime)
            {
                Attack();
                nextAttackTime = Time.time + attackRate;
            }
        }

    
        if(target.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if(target.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    private void Attack()
    {
        anim.SetTrigger("Attack");
        hitBox.GetComponent<HitBox>().EnableHitBox();
        SoundManager.PlaySound("SpiderAttack", 1f);

        Collider hittedEnemy = hitBox.GetComponent<HitBox>().GetHittedObject("Player");
        if (hittedEnemy != null)
            hittedEnemy.GetComponent<PlayerController>().TakeDamage(attackDamage);

        hitBox.GetComponent<HitBox>().DisableHitBox(attackDuration);
    }

    public override void TakeDamage(int damage)
    {
        healthSystem.TakeDamage(damage);
        //Debug.Log("Spider health: "+currentHealth);
        anim.SetTrigger("Hurt");
        SoundManager.PlaySound("SpiderHurt", 1f);

        if(healthSystem.GetHealth() <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        anim.SetBool("IsDead", true);

        SoundManager.PlaySound("SpiderDie", 1f);

        //Disable enemy
        GetComponent<CapsuleCollider>().enabled = false;
        this.enabled = false;
        StartCoroutine(DestroyAfterTime(deadDuration));
    }

    IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
