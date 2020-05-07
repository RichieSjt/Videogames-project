using UnityEngine;

[CreateAssetMenu(fileName = "New Potion", menuName = "Inventory/Potion/HealthPotion")]
public class HealthPotion : Potion
{    
    [SerializeField]
    public int healAmount = 20;

    public override void Use()
    {
        HealthSystem playerHS = PlayerManager.instance.player.GetComponent<HealthSystem>();
        base.Use();
        if(playerHS.health < playerHS.maxHealth)
        {
            //heal the player
            playerHS.Heal(healAmount);
            //Remove the potion from the inventory
            base.RemoveFromInventory();   
        }
            
    }


}
