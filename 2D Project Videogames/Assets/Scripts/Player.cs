using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{

    public float speed = 0.12f;
    private bool facingRight;

    private HealthSystem healthSystem;
    private Animator anim;

    void Start(){
        healthSystem = new HealthSystem(100);
        anim = gameObject.GetComponent<Animator>();
        facingRight = true;
    }

    void Update(){

        float x = Input.GetAxis("Horizontal") * speed;
        float y = Input.GetAxis("Vertical") * speed;

        gameObject.transform.Translate(new Vector3(Mathf.Abs(x), y, 0));

        //Animation condition
        if(Mathf.Abs(x) > 0 || Mathf.Abs(y) > 0){
            anim.SetBool("IsMoving", true);
        }else{  
            anim.SetBool("IsMoving", false);
        }

        //Flipping the player dependig on the direction it is facing
        if(x > 0 && !facingRight) {
            Flip();
        }
        if(x < 0 && facingRight) {
            Flip();
        }
    }

    private void Flip() {
        transform.Rotate(0f, 180f, 0f);
        facingRight = !facingRight;
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.tag == "Enemy") {
            //Meteor meteor = collision.GetComponent<Meteor>();
            //healthSystem.TakeDamage(meteor.GetDamage());
            if (healthSystem.GetHealth() <= 0)
                Destroy(gameObject); 
        }
    }
    
}
