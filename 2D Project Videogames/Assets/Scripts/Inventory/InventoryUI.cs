using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    Inventory inventory;
    InventorySlot[] slots;

    public Transform itemsParent;
    public GameObject inventoryUI;


    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();

        Load();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.I))
        {
            DisplayInventory();
        }
    }

    public void DisplayInventory(){
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }

    void UpdateUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

    #region ProgressManager
    public void Load()
    {
        if (System.IO.File.Exists(Application.dataPath+"/save.txt")){
            string saveString = File.ReadAllText(Application.dataPath+"/save.txt");
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);

            Inventory.instance.items = saveObject.InventoryList;

            UpdateUI();
        }
    }
    #endregion
}
