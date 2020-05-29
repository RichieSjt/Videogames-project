using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRigidbody;

    public virtual void TakeDamage(int damage){}

    public virtual void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    public virtual void ApplyKnockback(Vector3 direction, float knockBackForce)
    {
        enemyRigidbody = gameObject.GetComponent<Rigidbody>();
        enemyRigidbody.AddForce(direction.normalized * knockBackForce, ForceMode.Impulse);
        Invoke("StopKnockback", 0.7f);
    }

    public virtual void StopKnockback()
    {
        enemyRigidbody.velocity = new Vector3(0,0,0);
    }


}
