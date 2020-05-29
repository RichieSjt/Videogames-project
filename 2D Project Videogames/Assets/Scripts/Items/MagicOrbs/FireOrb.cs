using UnityEngine;

[CreateAssetMenu(fileName = "Fire Orb", menuName = "Inventory/Orb/FireOrb")]
public class FireOrb : Potion
{
    public override void Use()
    {
        Debug.Log("New magic unlocked");
        MagicController.numberOfMagicAttacks += 1;
        MagicController.currentMagic += 1;
        base.RemoveFromInventory(); 
    }
}
