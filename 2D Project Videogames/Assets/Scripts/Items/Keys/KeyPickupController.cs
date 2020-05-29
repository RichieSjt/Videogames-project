using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickupController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(this.tag == "Key1")
            KeysController.key1 = true;
        else if(this.tag == "Key2")
            KeysController.key2 = true;
        else if(this.tag == "Key3")
            KeysController.key3 = true;
    }
}