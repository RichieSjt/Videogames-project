using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{

    public float speed = 0.12f;
    private HealthSystem healthSystem;

    void Start(){
        healthSystem = new HealthSystem(100);
    }

    void Update(){
        float x = Input.GetAxis("Horizontal") * speed;
        float y = Input.GetAxis("Vertical") * speed;

        gameObject.transform.Translate(new Vector3(x, y, 0));
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
