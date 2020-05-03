using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;
    
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of inventory found!");
            return;
        }
        instance = this;
    }
    #endregion
    
    //A delegate is an event to which you can subscribe
    //different methods to. When you trigger the event all
    //the subscribed methods will be called.

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public List<Item> items = new List<Item>();
    public int space = 10;

    public bool Add(Item item)
    {
        if(!item.isDefaultItem)
        {
            
            if(items.Count >= space)
            {
                Debug.Log("Not enough room to fit more items");
                return false;
            }

            items.Add(item);
            //Whenever the inventory changes we trigger onItemChangedCallback
            if(onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        if(onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
    }
    
}
