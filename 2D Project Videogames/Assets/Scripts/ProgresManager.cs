using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class ProgresManager : MonoBehaviour
{
    public void save()
    {
        SaveObject saveObject = new SaveObject {
            playerPosition = CheckpointDetection.lastCheckpoint,
            playerHealth = PlayerManager.instance.player.GetComponent<HealthSystem>().GetHealth(),
            InventoryList = Inventory.instance.items,
        };
        string json = JsonUtility.ToJson(saveObject);

        File.WriteAllText(Application.dataPath+"/save.txt",json);
        Debug.Log("File Successfully Saved");
    }

    public void Load()
    {
            string saveString = File.ReadAllText(Application.dataPath+"/save.txt");

            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);

            PlayerManager.instance.player.transform.position= new Vector3 (saveObject.playerPosition.x,saveObject.playerPosition.y,saveObject.playerPosition.z);
            PlayerManager.instance.player.GetComponent<HealthSystem>().SetHealth(saveObject.playerHealth);
            Inventory.instance.items=saveObject.InventoryList;
    }
    

    private class SaveObject
    {
        public Vector3 playerPosition;
        public int playerHealth;
        public List<Item> InventoryList = new List<Item>();
    
    }

    
}
