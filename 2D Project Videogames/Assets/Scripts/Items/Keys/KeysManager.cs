using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class KeysManager : MonoBehaviour
{
    public static bool key1;
    public static bool key2;
    public static bool key3;

    private void Start() {
        key1 = false;
        key2 = false;
        key3 = false;

        Load();
    }

    public static bool CheckKeys(){
        if(key1 && key2 && key3)
            return true;
        else
            return false;
    }

    #region ProgressManager
    public void Load()
    {
        if (System.IO.File.Exists(Application.dataPath+"/save.txt")){
            string saveString = File.ReadAllText(Application.dataPath+"/save.txt");
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
            
            key1 = saveObject.savedKey1;
            key2 = saveObject.savedKey2;
            key3 = saveObject.savedKey3;
        }
    }
    #endregion
}
