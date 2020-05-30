using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchLevel : MonoBehaviour
{
    [Header("Temporal values")]
    private Vector3 playerPosition;
    private int playerHealth;
    private int savedCurrentMagic;
    private int savedMagicAttacks;
    private List<Item> InventoryList = new List<Item>();
    private int currentScene;
    private bool savedKey1;
    private bool savedKey2;
    private bool savedKey3;


    [Header("Scene index to change")]
    public int sceneIndex = 0;


    private void Start() {
        SetFixedPlayerPosition();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Load();
            Invoke("Save", 0.2f);
            Invoke("ChangeScene", 0.5f);
        }
    }

    private void SetFixedPlayerPosition()
    {
        //Forest level
        if (sceneIndex == 1)
        {
            playerPosition = new Vector3(-72f,-0.33f,0);
        }
        //Village level
        if (sceneIndex == 2)
        {
            playerPosition = new Vector3(-15.88f,-0.3299999f,0);
        }
        //Castle level
        if (sceneIndex == 3)
        {
            playerPosition = new Vector3(-21f,-0.33f,0);
        }
        //Boss level
        if (sceneIndex == 4)
        {
            playerPosition = new Vector3(-11.36f,-3.760002f,0);
        }
        //Graveyard level
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    #region ProgressManager
    public void Save()
    {
        SaveObject saveObject = new SaveObject {
            playerPosition = this.playerPosition,
            playerHealth = this.playerHealth,
            savedCurrentMagic = this.savedCurrentMagic,
            savedMagicAttacks = this.savedMagicAttacks,
            InventoryList = this.InventoryList,
            currentScene = sceneIndex,
        };
        string json = JsonUtility.ToJson(saveObject);

        File.WriteAllText(Application.dataPath+"/save.txt",json);
    }
    public void Load()
    {
        if (System.IO.File.Exists(Application.dataPath+"/save.txt")){
            string saveString = File.ReadAllText(Application.dataPath+"/save.txt");
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);

            playerHealth = saveObject.playerHealth;
            savedCurrentMagic = saveObject.savedCurrentMagic;
            savedMagicAttacks = saveObject.savedMagicAttacks;
            InventoryList = saveObject.InventoryList;
        }
    }
    #endregion
}
