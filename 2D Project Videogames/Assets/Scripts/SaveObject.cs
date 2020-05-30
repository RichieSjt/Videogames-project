using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SaveObject
{
    public Vector3 playerPosition;
    public int playerHealth;
    public int savedCurrentMagic;
    public int savedMagicAttacks;
    public List<Item> InventoryList = new List<Item>();
    public int currentScene;
    public bool savedKey1;
    public bool savedKey2;
    public bool savedKey3;
}