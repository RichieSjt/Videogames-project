using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirSlash : MonoBehaviour
{
    private Rigidbody airSlashRB;
    private Vector3 shootDirection;
    public float destroyTime = 4f;
    public float speed = 30f;
    private int damage;

    public void Setup(Vector3 shootDirection){
        this.shootDirection = shootDirection;
        airSlashRB = GetComponent<Rigidbody>();
        airSlashRB.AddForce(shootDirection * speed, ForceMode.Impulse);

        Destroy(gameObject, destroyTime);
    }

    public void SetMagicDamage(int damage)
    {
        this.damage = damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy") 
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.TakeDamage(damage);
            //Apply knockback to the enemies
            enemy.ApplyKnockback(shootDirection, 30);
            Destroy(gameObject);
        }
    }
}