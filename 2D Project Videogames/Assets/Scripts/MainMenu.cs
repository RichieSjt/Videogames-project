using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour{

    public int sceneIndex;
    public void StartGame(){
        if (System.IO.File.Exists(Application.dataPath+"/save.txt")){
            File.Delete (Application.dataPath+"/save.txt");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }else{
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }

    public void Exit(){
        Application.Quit();
        Debug.Log("Exit");
    }

    #region ProgressManager
    public void Load()
    {
        if (System.IO.File.Exists(Application.dataPath+"/save.txt")){
            string saveString = File.ReadAllText(Application.dataPath+"/save.txt");
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
            
            sceneIndex = saveObject.currentScene;
            SceneManager.LoadScene(sceneIndex);
        }else{
            Debug.Log("No file Stored");
        }
    }
    #endregion
}
