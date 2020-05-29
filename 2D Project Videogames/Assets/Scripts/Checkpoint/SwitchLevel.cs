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


    [Header("Scene index to change")]
    public int sceneIndex = 0;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Scene sceneToLoad = SceneManager.GetSceneByBuildIndex(sceneIndex);
            SceneManager.LoadScene(sceneIndex);
            //SceneManager.MoveGameObjectToScene(other.gameObject, sceneToLoad);
            Debug.Log("NEW SCENE");
        }
    }

    private void SetFixedPlayerPosition()
    {
        if (sceneIndex == 1)
        {

        }
        if (sceneIndex == 2)
        {
            playerPosition = new Vector3(-15.88f,-0.3299999f,0);
        }
        if (sceneIndex == 3)
        {

        }
    }

    #region ProgressManager
    public void Load()
    {
        if (System.IO.File.Exists(Application.dataPath+"/save.txt")){
            string saveString = File.ReadAllText(Application.dataPath+"/save.txt");
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);

        }
    }
    #endregion
}
