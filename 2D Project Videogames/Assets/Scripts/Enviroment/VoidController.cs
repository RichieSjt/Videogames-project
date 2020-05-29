using UnityEngine;

public class VoidController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            //If an enemy falls into the void it is destroyed
            Debug.Log("An enemy has fallen into the void");
            Destroy(other.GetComponent<GameObject>());
        }
        if(other.tag == "Player")
        {
            //If the player falls into the void, send him to the last checkpoint
            Debug.Log("The player has fallen into the void");
            other.GetComponent<PlayerController>().Die();
        }
    }
}