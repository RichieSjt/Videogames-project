using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour{
    

    //To avoid the use of gameObjetct.Find("Name") to find the player transform
    //where we need it, instead we create a singleton. Like a static class so to speak.
    //This way we don´t have to iterate through all of the scene objects.

    //Region is just a way of hiding this part of the script.
    #region Singleton

    public static PlayerManager instance; 

    private void Awake() {
        instance = this;
    }

    #endregion

    public GameObject player;
    
}
