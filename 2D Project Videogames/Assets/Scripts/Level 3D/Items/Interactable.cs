﻿
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

    public void Update()
    {
        if(!hasInteracted)
        {
            float distanceBetween = Vector3.Distance(player.position, transform.position);
            if(distanceBetween <= radius)
            {
                Debug.Log("Interact");
                Interact();
                hasInteracted = true;
            }
        }
    }

    public virtual void Interact()
    {
        //This method is meant to be overwritten
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
