using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HoundController : Enemy
{

    [Header("Animator")]    
    public Animator anim;

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
    private bool stopped = false;

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

        if(target.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if(target.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        
        if (stopped)
            return;

        if(distanceBetween <= lookRadius)
        {
            agent.SetDestination(target.position);
            agent.speed = speed;
            anim.SetBool("IsMoving", true);
            GetHittedPlayer();
        }
        else if(distanceBetween > lookRadius)
        {
            anim.SetBool("IsMoving", false);
            agent.speed = 0;
        }

        if(distanceBetween <= 0.38f)
        {
            agent.speed = 0;
            anim.SetBool("IsMoving", false);
            stopped = true;
            Invoke("MoveAgain", 1f);

        }
    }

    private void MoveAgain()
    {
        stopped = false;
    }

    private void GetHittedPlayer()
    {
        hitBox.GetComponent<HitBox>().EnableHitBox();
        Collider hittedEnemy = hitBox.GetComponent<HitBox>().GetHittedObject("Player");
        if (hittedEnemy != null)
        {
            SoundManager.PlaySound("HoundGrowl", 0.3f);
            hittedEnemy.GetComponent<PlayerController>().TakeDamage(attackDamage);
        }
    }

    public override void TakeDamage(int damage)
    {
        healthSystem.TakeDamage(damage);


        //SoundManager.PlaySound("SkeletonHurt", 1f);

        ShowFloatingText(damage);

        if(healthSystem.GetHealth() <= 0)
        {
            DestroyEnemy();
        }
    }

    private void ShowFloatingText(int damage)
    {
        var go=Instantiate(floatingTextPrefab,transform.position,Quaternion.identity,transform);
        go.GetComponent<TextMesh>().text=damage.ToString();
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
