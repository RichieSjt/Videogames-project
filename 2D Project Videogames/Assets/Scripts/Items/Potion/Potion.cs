using UnityEngine;

[CreateAssetMenu(fileName = "New Potion", menuName = "Inventory/Potion")]
public class Potion : Item
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
