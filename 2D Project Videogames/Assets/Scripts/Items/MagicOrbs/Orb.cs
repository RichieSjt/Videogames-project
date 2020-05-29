using UnityEngine;

[CreateAssetMenu(fileName = "New Orb", menuName = "Inventory/Orb")]
public class Orb : Item
{
    public override void Use()
    {
        //Modify the player health or mana
        //Remove the potion from the inventory
        base.Use();
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}

