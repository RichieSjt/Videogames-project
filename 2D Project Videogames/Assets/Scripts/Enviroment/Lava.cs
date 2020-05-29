using UnityEngine;

public class Lava : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        Debug.Log("Player has fallen into lava");
        if(other.gameObject.CompareTag("Player")){
            //Send the player to the last checkpoint
            other.GetComponent<PlayerController>().Die();
        }
    }
}