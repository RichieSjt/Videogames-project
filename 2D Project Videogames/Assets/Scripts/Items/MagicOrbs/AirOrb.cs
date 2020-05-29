using UnityEngine;

[CreateAssetMenu(fileName = "Air Orb", menuName = "Inventory/Orb/AirOrb")]
public class AirOrb : Potion
{
    public override void Use()
    {
        Debug.Log("New magic unlocked");
        MagicController.numberOfMagicAttacks += 1;
        base.RemoveFromInventory(); 
    }
}

