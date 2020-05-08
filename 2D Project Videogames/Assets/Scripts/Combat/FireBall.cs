using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private Rigidbody fireBallRB;
    private Vector3 shootDirection;
    public float speed = 20f;
    private int damage = 20;

    public void Setup(Vector3 shootDirection){
        this.shootDirection = shootDirection;
        fireBallRB = GetComponent<Rigidbody>();
        fireBallRB.AddForce(shootDirection * speed, ForceMode.Impulse);

        Destroy(gameObject, 8f);
    }

    public void SetMagicDamage(int damage)
    {
        this.damage = damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy") 
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}