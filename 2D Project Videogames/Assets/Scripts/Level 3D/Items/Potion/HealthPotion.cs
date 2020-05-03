using UnityEngine;

[CreateAssetMenu(fileName = "New Potion", menuName = "Inventory/Potion/HealthPotion")]
public class HealthPotion : Potion{
    
    [SerializeField]public int healAmount = 20;

    public override void Use(){
        base.Use();
        HealthSystem playerHS = PlayerManager.instance.player.GetComponent<HealthSystem>();
        //heal the player
        playerHS.Heal(healAmount);
        //Remove the potion from the inventory
        base.RemoveFromInventory();
    }


}
