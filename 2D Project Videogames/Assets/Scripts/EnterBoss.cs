using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterBoss : MonoBehaviour
{
    public void onCollisionEnter(Collision collision)
    {
         if(collision.gameObject.tag=="Player"){ 
             EnterBossScene();
        }
        
    }
    public void EnterBossScene()
    {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
