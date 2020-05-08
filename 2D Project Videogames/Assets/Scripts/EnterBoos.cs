using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterBoos : MonoBehaviour
{
    public void onCollision()
    {
        
    }
    public void EnterBossScene()
    {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
