using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script should be attached to the game manager object in the hierarchy
public class KeyPickupController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            SoundManager.PlaySound("PickUpKey", 1f);

            if(this.tag == "Key1")
            {
                KeysManager.key1 = true;
                Debug.Log("Key 1 picked up, manager state: " + KeysManager.key1);
                Destroy(gameObject);
            }
            else if(this.tag == "Key2")
            {
                KeysManager.key2 = true;
                Debug.Log("Key 2 picked up, manager state: " + KeysManager.key2);
                Destroy(gameObject);
            }
            else if(this.tag == "Key3")
            {
                KeysManager.key3 = true;
                Debug.Log("Key 3 picked up, manager state: " + KeysManager.key3);
                Destroy(gameObject);
            }
        }
    }
}