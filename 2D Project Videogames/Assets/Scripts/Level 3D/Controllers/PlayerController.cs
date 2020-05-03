using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 slope;
    private bool grounded;
    private float verticalVelocity;

    [Header("Animator")]
    [SerializeField] private Animator anim;
    
    [Header("Movement configuration")]
    [SerializeField] private float speedX = 10;
    [SerializeField] private float speedZ = 10;
    [SerializeField] private float gravity = 0.2f;
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private float maxVelocity = 8f;

    [Header("Ground Check Raycast")]
    [SerializeField] private float extremitiesOffset = 0.5f;   
    [SerializeField] private float innerVerticalOffset = 0.25f;   
    [SerializeField] private float distanceGrounded = 0.15f;    
    [SerializeField] private float slopeThereshold = 0.55f;

    [Header("Health")]
    public int maxHealth = 100;
    private int currentHealth;

    public HealthSystem healthSystem;
    public HealthBar healthBar;

    private void Awake(){
        controller = GetComponent<CharacterController>();
        healthSystem = GetComponent<HealthSystem>();
        healthSystem.maxHealth = maxHealth;
        healthBar.Setup(healthSystem);
    }

    void Start(){
        currentHealth = maxHealth;
    }

    private void Update(){
        Vector3 inputVector = Movement();
        Vector3 moveVector = new Vector3(inputVector.x*speedX,0,inputVector.y*speedZ);
        anim.SetFloat("Speed", moveVector.magnitude);
        
        grounded = Grounded();
        anim.SetBool("Grounded", grounded);
        if (grounded)
        {
          verticalVelocity = -1; //Slight Gravity

          if (Input.GetKeyDown(KeyCode.Space))
          {
              verticalVelocity = jumpForce;
              slope = Vector3.up;
              anim.SetTrigger("Jump");
          }  
        }else
        {
            verticalVelocity -= gravity;
            slope = Vector3.up;

            //Clamp to match maximun velocity if faster
            if (verticalVelocity < -maxVelocity)
                verticalVelocity = -maxVelocity;
        }

        moveVector.y = verticalVelocity; //Apply verticalVelocity to movement vector
        anim.SetFloat("VerticalVelocity", verticalVelocity);

        if (slope != Vector3.up) moveVector = StayFloor(moveVector); //Angle the vector to macth floor's curves
        
        controller.Move(moveVector*Time.deltaTime); //Move the controller
    }

    private Vector3 Movement(){
        Vector3 v = Vector3.zero;

        float x = Input.GetAxisRaw("Horizontal");
        CharacterFacing(x);
        v.x = x;
        v.y = Input.GetAxisRaw("Vertical");
        return v.normalized;
    }

    private void CharacterFacing(float x){
        if (x > 0.1)
            transform.localScale = new Vector3(1f, 1f, 1f);
        if (x < -0.1)
            transform.localScale = new Vector3(-1f, 1f, 1f);
    }

    private Vector3 StayFloor(Vector3 moveVector){
        Vector3 right = new Vector3(slope.y, -slope.x, 0).normalized;
        Vector3 forward = new Vector3(0, -slope.z, slope.y).normalized;
        return right * moveVector.x + forward * moveVector.z;
    }

    private bool Grounded(){
        if (verticalVelocity>0)
            return false;

        float yRay = (controller.bounds.center.y - (controller.height * 0.5f)) + innerVerticalOffset; //Bottom of the character controller

        RaycastHit hit;

        //Middle
        if (Physics.Raycast(new Vector3(controller.bounds.center.x, yRay, controller.bounds.center.z), -Vector3.up, out hit, innerVerticalOffset + distanceGrounded))
        {
            Debug.DrawRay(new Vector3(controller.bounds.center.x, yRay, controller.bounds.center.z), -Vector3.up * (innerVerticalOffset + distanceGrounded), Color.red);
            slope = hit.normal;
            return (slope.y > slopeThereshold) ? true : false;
        }

        //Front Right
        if (Physics.Raycast(new Vector3(controller.bounds.center.x + (controller.bounds.extents.x - extremitiesOffset), yRay, controller.bounds.center.z + (controller.bounds.extents.z - extremitiesOffset)), -Vector3.up, out hit, innerVerticalOffset + distanceGrounded))
        {
            slope = hit.normal;
            return (slope.y > slopeThereshold) ? true : false;
        }

        //Front Left
        if (Physics.Raycast(new Vector3(controller.bounds.center.x - (controller.bounds.extents.x - extremitiesOffset), yRay, controller.bounds.center.z + (controller.bounds.extents.z - extremitiesOffset)), -Vector3.up, out hit, innerVerticalOffset + distanceGrounded))
        {
            slope = hit.normal;
            return (slope.y > slopeThereshold) ? true : false;
        }

        //Back Right
        if (Physics.Raycast(new Vector3(controller.bounds.center.x + (controller.bounds.extents.x - extremitiesOffset), yRay, controller.bounds.center.z - (controller.bounds.extents.z - extremitiesOffset)), -Vector3.up, out hit, innerVerticalOffset + distanceGrounded))
        {
            slope = hit.normal;
            return (slope.y > slopeThereshold) ? true : false;
        }

        //Back Left
        if (Physics.Raycast(new Vector3(controller.bounds.center.x - (controller.bounds.extents.x - extremitiesOffset), yRay, controller.bounds.center.z - (controller.bounds.extents.z - extremitiesOffset)), -Vector3.up, out hit, innerVerticalOffset + distanceGrounded))
        {
            slope = hit.normal;
            return (slope.y > slopeThereshold) ? true : false;
        }

        return false;
    }

    public void TakeDamage(int damage)
    {
        healthSystem.TakeDamage(damage);

        Debug.Log("Player health: "+ healthSystem.GetHealth());
        anim.SetTrigger("Hurt");

        if(healthSystem.GetHealth() <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        anim.SetBool("IsDead", true);

        //Disable enemy
        GetComponent<CharacterController>().enabled = false;
        this.enabled = false;
    }

}
