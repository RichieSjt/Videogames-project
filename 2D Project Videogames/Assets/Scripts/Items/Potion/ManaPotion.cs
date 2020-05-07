using UnityEngine;

[CreateAssetMenu(fileName = "New Potion", menuName = "Inventory/Potion/ManaPotion")]
public class ManaPotion : Potion
{
    [SerializeField]
    public int manaRecoverAmount = 20;

    public override void Use()
    {
        ManaSystem playerMS = PlayerManager.instance.player.GetComponent<ManaSystem>();
        base.Use();
        if(playerMS.mana < playerMS.maxMana)
        {
            //Recover mana
            playerMS.RecoverMana(manaRecoverAmount);
            //Remove the potion from the inventory
            base.RemoveFromInventory();   
        }
            
    }
}
