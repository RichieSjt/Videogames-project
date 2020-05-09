using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonBossController : Enemy
{
    [Header("Animator")]    
    public Animator anim;
    public float attackDuration = 1.4f;
    public float deadDuration = 0f;
    
    [Header("Sprite")]
    public SpriteRenderer spriteRenderer;

    [Header("Health")]
    private HealthSystem healthSystem;
    public int maxHealth = 100;

    [Header("Attack Settings")]
    public GameObject hitBox;
    public int attackDamage = 10;
    public float attackRate = 5f;
    private float nextAttackTime = 0f;
    private bool isPlayerNear = false;

    [Header("Enemies to spawn")]
    public GameObject[] enemies;


    private void Start()
    {
        healthSystem = GetComponent<HealthSystem>();
        healthSystem.maxHealth = maxHealth;
        healthSystem.health = maxHealth;
    }

    private void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if(isPlayerNear)
            {
                Attack();
                nextAttackTime = Time.time + attackRate;
            }   
        }
    }

    private void Attack()
    {
        anim.SetTrigger("Attack");
        StartCoroutine(FireSoundDelay(1f));

        hitBox.GetComponent<HitBox>().EnableHitBox();

        hitBox.GetComponent<HitBox>().DisableHitBox(attackDuration);
    }

    public override void TakeDamage(int damage)
    {
        healthSystem.TakeDamage(damage);
        Debug.Log("Demon health: " + healthSystem.GetHealth());
        spriteRenderer.color = Color.red;

        if(healthSystem.GetHealth() <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
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

    IEnumerator FireSoundDelay(float time)
    {
        yield return new WaitForSeconds(time);
        SoundManager.PlaySound("BossFire", 1f);
        Collider hittedEnemy = hitBox.GetComponent<HitBox>().GetHittedObject("Player");
        if (hittedEnemy != null)
            hittedEnemy.GetComponent<PlayerController>().TakeDamage(attackDamage);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player"){
            isPlayerNear = true;
            Debug.Log("Player enter: " + isPlayerNear);
        } 
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player"){
            isPlayerNear = false;
            Debug.Log("Player enter: " + isPlayerNear);
        } 
    }
}
