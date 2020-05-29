using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysController : MonoBehaviour
{
    public static bool key1;
    public static bool key2;
    public static bool key3;

    private void Start() {
        key1 = false;
        key2 = false;
        key3 = false;
    }

    public static bool CheckKeys(){
        if(key1 && key2 && key3)
            return true;
        else
            return false;
    }
}
