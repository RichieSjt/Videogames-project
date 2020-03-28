using UnityEngine;

[CreateAssetMenu(fileName = "New Potion", menuName = "Inventory/Potion/HealthPotion")]
public class HealthPotion : Potion{
    
    [SerializeField]public int healAmount = 20;
    //GameObject player;

    private void Start() {
        //player = PlayerManager.instance.player;
    }

    public override void Use(){
        base.Use();
        //heal the player
        //player.GetComponent<HealthSystem>().Heal(healAmount);
        //Remove the potion from the inventory
        base.RemoveFromInventory();
    }


}
