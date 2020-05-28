using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public virtual void TakeDamage(int damage){}

    public virtual void DestroyEnemy()
    {
        Destroy(gameObject);
    }
    public virtual void ApplyKnockback(){}
}
