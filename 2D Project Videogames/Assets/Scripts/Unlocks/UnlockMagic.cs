using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockMagic : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log("New magic unlocked");
        MagicController.currentMagic += 1;
        Destroy(gameObject);
    }
}
