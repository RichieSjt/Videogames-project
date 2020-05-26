using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlimeController : Enemy
{

    [Header("Animator")]    
    public Animator anim;
    public float attackDuration = 0.3f;
    public float deadDuration = 1.4f;

    [Header("Movement targets")]
    private Transform target;
    private NavMeshAgent agent;
    
    [Header("Movement settings")]
    public float lookRadius = 3f;
    public float speed = 1.5f;
    private Rigidbody slimeRigidbody;
    
    [Header("Health")]
    private HealthSystem healthSystem;
    public int maxHealth = 100;
    public GameObject floatingTextPrefab;

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
        slimeRigidbody = GetComponentInChildren<Rigidbody>();
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

            //slimeRigidbody.AddForce(Vector3.up * 20f, ForceMode.Impulse);
            if(Time.time >= timeLoopSound){
                SoundManager.PlaySound("SlimeMove", 0.2f);
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

        Collider hittedEnemy = hitBox.GetComponent<HitBox>().GetHittedObject("Player");
        if (hittedEnemy != null)
            hittedEnemy.GetComponent<PlayerController>().TakeDamage(attackDamage);

        hitBox.GetComponent<HitBox>().DisableHitBox(attackDuration);
    }

    public override void TakeDamage(int damage)
    {
        healthSystem.TakeDamage(damage);
        //Debug.Log("Slime health: "+currentHealth);
        anim.SetTrigger("Hurt");

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

        SoundManager.PlaySound("SlimeDie", 0.3f);

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
