using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;

    public override void Interact()
    {
        Pickup();
    }
    private void Pickup()
    {
        Debug.Log("Picking up " + item.name);
        
        //If the item was picked up succesfuly we destroy the object
        //however, if there isn't enough space we shouldn't destroy it.
        bool wasPickedUp = Inventory.instance.Add(item);
        if(wasPickedUp)
            Destroy(gameObject);
    }
}
