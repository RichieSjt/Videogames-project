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

    private float currentTime = 0f;


    private void Start()
    {
        healthSystem = GetComponent<HealthSystem>();
        healthSystem.maxHealth = maxHealth;
        healthSystem.health = maxHealth;
    }

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            Debug.Log("ENTER PLAYER");
        }
    }
}
