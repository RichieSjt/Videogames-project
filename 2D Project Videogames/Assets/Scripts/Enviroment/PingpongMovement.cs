using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingpongMovement : MonoBehaviour{

    public Transform ping;
    public Transform pong;
    public Vector3 currentTarget;
    public float speed = 3.5f;

    void Start(){
        currentTarget = ping.position;
    }

    void Update(){
        Move();
    }

    void Move(){
        float distance = Vector3.Distance(transform.position, currentTarget);
        if(distance <= 0){
            if(currentTarget == ping.position){
                currentTarget = pong.position;
            }else{
                currentTarget = ping.position;
            }
        }else{
            transform.position = Vector3.Lerp(transform.position, currentTarget, (Time.deltaTime * speed) / distance);
        }
    }

}
