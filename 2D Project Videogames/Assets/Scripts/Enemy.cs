using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{

    private Animator anim;
    private Transform target;

    public int damage = 20;
    public float stoppingDistance = 1f;
    public float maxFollowDistance = 5f;
    public float speed = 6f;
    private bool facingRight;



    void Start(){
        anim = gameObject.GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        facingRight = true;
    }

    void Update(){
        FollowPlayer();
    }

    public int GetDamage(){
        return damage;
    }

    public void FollowPlayer(){
        
        Vector3 enemyPos = transform.position;
        Vector3 playerPos = target.position;
        Vector2 movement = Vector2.MoveTowards(enemyPos, playerPos, speed * Time.deltaTime);
        float distanceBetween = Vector2.Distance(enemyPos, playerPos);

        Debug.Log(movement.x);

        if(movement.x > 0 && !facingRight) {
            Flip();
        }
        if(movement.x < 0 && facingRight) {
            Flip();
        }

        //If the enemy isn't close enough to the player and is in the maximum follow range then it moves towards him
        if(distanceBetween > stoppingDistance && distanceBetween < maxFollowDistance){
            //Move from enemy position towards player at certain speed
            transform.position = movement;
            anim.SetBool("Attack", false);
            anim.SetBool("IsMoving", true);
        }else if(distanceBetween > maxFollowDistance){
            anim.SetBool("Attack", false);
            anim.SetBool("IsMoving", false);
        }else{
            anim.SetBool("Attack", true);
        }

    }

    private void Flip() {
        transform.Rotate(0f, 180f, 0f);
        facingRight = !facingRight;
    }
}
