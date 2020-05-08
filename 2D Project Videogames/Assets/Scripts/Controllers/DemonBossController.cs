using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonBossController : MonoBehaviour
{
    [Header("Animator")]    
    public Animator anim;
    public float attackDuration = 0.3f;
    
    [Header("Health")]
    private HealthSystem healthSystem;
    public int maxHealth = 100;

    [Header("Attack Settings")]
    public GameObject hitBox;
    public int attackDamage = 10;
    public float attackRate = 5f;
    private float nextAttackTime = 0f;
    public float lookRadius = 5f;

    private float currentTime = 0f;


    void Start()
    {
        healthSystem = GetComponent<HealthSystem>();
        healthSystem.maxHealth = maxHealth;
        healthSystem.health = maxHealth;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
