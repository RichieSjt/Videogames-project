using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterBoss : MonoBehaviour
{
    public void onCollisionEnter(Collision Collision)
    {
        
    }
    public void EnterBossScene()
    {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
