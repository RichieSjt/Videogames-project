
using UnityEngine;

public class Interactable : MonoBehaviour
{
    
    [SerializeField]Transform player;
    public float radius = 0.7f;
    private bool hasInteracted = false;
    
    private void Start()
    {
        player = PlayerManager.instance.player.transform;
    }

    public virtual void Interact()
    {
        //This method is meant to be overwritten
    }
    
    /*private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }*/

    private void OnTriggerEnter(Collider other) {
        if(!hasInteracted)
        {
            Debug.Log("Interact");
            Interact();
            hasInteracted = true;
            
        }
    }

}
