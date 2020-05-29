using UnityEngine;

[CreateAssetMenu(fileName = "Electricity Orb", menuName = "Inventory/Orb/ElectricityOrb")]
public class ElectricityOrb : Potion
{
    public override void Use()
    {
        Debug.Log("New magic unlocked");
        MagicController.numberOfMagicAttacks += 1;
        base.RemoveFromInventory(); 
    }
}

