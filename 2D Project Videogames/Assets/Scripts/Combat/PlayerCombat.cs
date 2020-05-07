using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("Animator")]
    [SerializeField] private Animator anim;

    [Header("Attack Settings")]
    [SerializeField] private GameObject hitBox;
    [SerializeField] private int attackDamage = 50;
    [SerializeField] private float attackRate = 2f;
    private float nextAttackTime = 0f;
    
    private void Update()
    {
        if (Time.time >= nextAttackTime) {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        } 
    }

    private void Attack()
    {
        anim.SetTrigger("Attack");
        hitBox.GetComponent<HitBox>().EnableHitBox();

        Collider hittedEnemy = hitBox.GetComponent<HitBox>().GetHittedObject("Enemy");
        if (hittedEnemy != null)
            hittedEnemy.GetComponent<EnemyController>().TakeDamage(attackDamage);

        hitBox.GetComponent<HitBox>().DisableHitBox(0.15f);
    }
}
