using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        Debug.Log("Lavaaaaaaaaaaa");
        if(other.gameObject.CompareTag("Player")){
            other.transform.position=new Vector3(68,5,-1);
        }
    }
}