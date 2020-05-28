using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FlyingEyeController : Enemy
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
    public int maxHealth = 0;
    public GameObject floatingTextPrefab;

    [Header("Attack Settings")]
    public GameObject hitBox;
    public int attackDamage = 0;
    private bool onceCall = false;

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

            if (!onceCall)
            {
                Attack();
                Invoke("DestroyAfterTime", attackDuration);
                onceCall = true;
            }
            //StartCoroutine(DestroyAfterTime(attackDuration));
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

        StartCoroutine(GetHittedPlayer(0.2f));     
    }

    IEnumerator GetHittedPlayer(float time)
    {
        yield return new WaitForSeconds(time);
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
        this.enabled = false;
        Invoke("DestroyAfterTime", deadDuration);
    }

    private void DestroyAfterTime()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}