using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]

public class Item : ScriptableObject
{
    public Sprite icon = null;

    new public string name = "New Item";
    public bool isDefaultItem = false;

    public virtual void Use()
    {
        //Use the item
        //This method must be overwritten depending on what the picked up object does
        
        Debug.Log("Using " + name);
    }
}
