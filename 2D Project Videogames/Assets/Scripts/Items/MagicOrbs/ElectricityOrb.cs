using UnityEngine;

[CreateAssetMenu(fileName = "Electricity Orb", menuName = "Inventory/Orb/ElectricityOrb")]
public class ElectricityOrb : Potion
{
    public override void Use()
    {
        Debug.Log("New magic unlocked");
        SoundManager.PlaySound("UseOrb", 1f);
        MagicController.numberOfMagicAttacks += 1;
        base.RemoveFromInventory(); 
    }
}

