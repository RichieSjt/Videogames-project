using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("Animator")]
    public Animator playerAnim;

    [Header("Attack Settings")]
    public GameObject hitBox;
    public int attackDamage = 50;
    public float attackRate = 2f;
    private float nextAttackTime = 0f;

    [Header("Magic Attack Settings")]
    public GameObject fireBallPrefab;
    public int magicDamage = 30;
    public int manaPerAttack = 40;
    public float magicAttackRate = 1f;

    [Header("Fire points")]
    public Transform firepoint;
    public Transform firepointEnd;
    
    private void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                MagicAttack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    private void Attack()
    {
        playerAnim.SetTrigger("Attack");
        hitBox.GetComponent<HitBox>().EnableHitBox();

        Collider hittedEnemy = hitBox.GetComponent<HitBox>().GetHittedObject("Enemy");
        if (hittedEnemy != null)
            hittedEnemy.GetComponent<Enemy>().TakeDamage(attackDamage);

        hitBox.GetComponent<HitBox>().DisableHitBox(0.15f);
    }

    private void MagicAttack()
    {
        playerAnim.SetTrigger("Attack");
        ManaSystem playerMS = PlayerManager.instance.player.GetComponent<ManaSystem>();
        playerMS.ReduceMana(manaPerAttack);
        Vector3 shootDirection = (firepoint.position - firepointEnd.position).normalized;
        GameObject fireball = Instantiate(fireBallPrefab, firepoint.position, Quaternion.identity);
        fireball.GetComponent<FireBall>().Setup(shootDirection);
    }
}
