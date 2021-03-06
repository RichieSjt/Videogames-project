﻿using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressManager : MonoBehaviour
{
    public void Save()
    {
        SaveObject saveObject = new SaveObject {
            playerPosition = CheckpointDetection.lastCheckpoint,
            playerHealth = PlayerManager.instance.player.GetComponent<HealthSystem>().GetHealth(),
            savedCurrentMagic = MagicController.currentMagic,
            savedMagicAttacks = MagicController.numberOfMagicAttacks,
            InventoryList = Inventory.instance.items,
            currentScene = SceneManager.GetActiveScene().buildIndex,
            savedKey1 = KeysManager.key1,
            savedKey2 = KeysManager.key2,
            savedKey3 = KeysManager.key3,
        };
        string json = JsonUtility.ToJson(saveObject);

        File.WriteAllText(Application.dataPath+"/save.txt",json);

        #region DebugSaveObject
        /*Debug.Log("FILE SUCCESSFULLY SAVED");
        Debug.Log("Player position: " + saveObject.playerPosition);
        Debug.Log("Player health: " + saveObject.playerHealth);
        Debug.Log("Magic attacks: " + saveObject.savedMagicAttacks);
        Debug.Log("Current magic: " + saveObject.savedCurrentMagic);
        Debug.Log("Items: " + saveObject.InventoryList);
        Debug.Log("Scene index: " + saveObject.currentScene);
        Debug.Log("Key 1: " + saveObject.savedKey1);
        Debug.Log("Key 2: " + saveObject.savedKey2);
        Debug.Log("Key 3: " + saveObject.savedKey3);*/
        #endregion
    }

    public void Load()
    {
            /*string saveString = File.ReadAllText(Application.dataPath+"/save.txt");

            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
            PlayerManager.instance.player.GetComponent<HealthSystem>().SetHealth(saveObject.playerHealth);
            Inventory.instance.items=saveObject.InventoryList;*/
    }
    

    /*public class SaveObject
    {
        public Vector3 playerPosition;
        public int playerHealth;
        public int savedCurrentMagic;
        public int savedMagicAttacks;
        public List<Item> InventoryList = new List<Item>();
        public int currentScene;
    
    }*/
}
