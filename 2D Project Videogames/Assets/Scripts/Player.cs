using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{

    public float speed = 0.12f;
    private bool facingRight;

    public HealthSystem healthSystem;
    public HealthBar healthBar;
    private Animator anim;
    //private Rigidbody2D rb;

    private void Awake(){
        healthSystem = new HealthSystem(100);
        healthBar.Setup(healthSystem);

        anim = gameObject.GetComponent<Animator>();
        facingRight = true;
        //rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update(){
        Move();
        CheckAttack();
    }

    private void Move(){
        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float y = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        Vector3 moveDirection = new Vector3(Mathf.Abs(x), y, 0);

        transform.Translate(moveDirection);

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

    private void CheckAttack(){
        if(Input.GetKeyDown(KeyCode.Space)){
            anim.SetBool("IsAttacking", true);
            Invoke("ExitAttack", 0.3f);
        }
    }
    private void ExitAttack(){
        anim.SetBool("IsAttacking", false);
    }

    private void Flip() {
        transform.Rotate(0f, 180f, 0f);
        facingRight = !facingRight;
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.tag == "Enemy") {
            Enemy enemy = collision.GetComponent<Enemy>();
            healthSystem.TakeDamage(enemy.GetDamage());
            if (healthSystem.GetHealth() <= 0)
                Destroy(gameObject); 
        }
    }
    
}
