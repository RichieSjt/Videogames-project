using UnityEngine;

[CreateAssetMenu(fileName = "Air Orb", menuName = "Inventory/Orb/AirOrb")]
public class AirOrb : Potion
{
    public override void Use()
    {
        Debug.Log("New magic unlocked");
        SoundManager.PlaySound("UseOrb", 1f);
        MagicController.numberOfMagicAttacks += 1;
        base.RemoveFromInventory(); 
    }
}

