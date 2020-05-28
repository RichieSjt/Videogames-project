using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MushroomController : Enemy
{

    [Header("Animator")]    
    public Animator anim;
    public float attackDuration = 0;
    public float deadDuration = 0;

    [Header("Movement targets")]
    private Transform target;
    private NavMeshAgent agent;
    
    [Header("Movement settings")]
    public float lookRadius = 0;
    public float speed = 0;
    
    [Header("Health")]
    private HealthSystem healthSystem;
    public int maxHealth = 100;
    public GameObject floatingTextPrefab;

    [Header("Attack Settings")]
    public GameObject hitBox;
    public int attackDamage = 0;
    public float attackRate = 0;
    private float nextAttackTime = 0;

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        healthSystem = GetComponent<HealthSystem>();
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
        }
        else if(distanceBetween > lookRadius)
        {
            anim.SetBool("IsMoving", false);
            agent.speed = 0;
        }
        if(distanceBetween <= agent.stoppingDistance)
        {
            agent.speed = 0;

            if (Time.time >= nextAttackTime)
            {
                Attack();
                nextAttackTime = Time.time + attackRate;
            }
        }

        if(target.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if(target.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    private void Attack()
    {
        hitBox.GetComponent<HitBox>().EnableHitBox();
        anim.SetTrigger("Attack");
        
        //SoundManager.PlaySound("SwordSlashSkeleton", 1f);

        Invoke("GetHittedPlayer", 0.4f); 
    }

    private void GetHittedPlayer()
    {
        Collider hittedEnemy = hitBox.GetComponent<HitBox>().GetHittedObject("Player");
        if (hittedEnemy != null)
            hittedEnemy.GetComponent<PlayerController>().TakeDamage(attackDamage);

        hitBox.GetComponent<HitBox>().DisableHitBox(attackDuration);
    }

    public override void TakeDamage(int damage)
    {
        healthSystem.TakeDamage(damage);
        //Debug.Log("Enemy health: "+currentHealth);
        anim.SetTrigger("Hurt");
        //SoundManager.PlaySound("SkeletonHurt", 1f);

        ShowFloatingText(damage);

        if(healthSystem.GetHealth() <= 0)
        {
            Die();
        }
    }

    private void ShowFloatingText(int damage)
    {
        var go=Instantiate(floatingTextPrefab,transform.position,Quaternion.identity,transform);
        go.GetComponent<TextMesh>().text=damage.ToString();
    }

    private void Die()
    {
        anim.SetBool("IsDead", true);
        //SoundManager.PlaySound("SkeletonDie", 1f);
        //Disable enemy
        GetComponent<CapsuleCollider>().enabled = false;
        agent.enabled = false;
        this.enabled = false;
        Invoke("DestroyEnemy", deadDuration);
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}