using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricRay : MonoBehaviour
{
    private Vector3 shootDirection;
    public float destroyTime = 1.2f;
    private int damage;

    public void Setup(Vector3 shootDirection){
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