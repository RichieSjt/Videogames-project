using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchLevel : MonoBehaviour
{
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
}
