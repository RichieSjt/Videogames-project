using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatZoneController : MonoBehaviour
{
    [Header("Boundaries")]
    public GameObject left, right;

    [Header("Main Camera")]
    public CameraController mainCamera;
    public float boundariesOffset;

    [Header("Check Enemines")]
    private bool remaining = true;

    private void Update()
    {
        if (remaining == false)
        {
            DisableBoundaries();
            CancelInvoke();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GetComponent<BoxCollider>().enabled = false;
            EnableBoundaries();
            gameObject.GetComponent<EnemySpawnerController>().StartSpawnEnemies();
            InvokeRepeating("RemainingEnemies",2f,1f);
        }
    }

    public void EnableBoundaries()
    {
        left.SetActive(true);
        right.SetActive(true);
        float min = left.transform.position.x + boundariesOffset;
        float max = right.transform.position.x - boundariesOffset;
        mainCamera.SetBoundariesX(min, max);
    }

    public void DisableBoundaries()
    {
        left.SetActive(false);
        right.SetActive(false);
        mainCamera.SetDefaultBoundaries();
    }

    public void RemainingEnemies()
    {
        remaining = gameObject.GetComponent<EnemySpawnerController>().CheckRemainingEnemies();
    }
}
