using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatZoneController : MonoBehaviour
{
    [Header("Boundaries")]
    public GameObject left, right;
    private int enemies = 1000;

    [Header("Main Camera")]
    public CameraController mainCamera;
    public float boundariesOffset;

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GetComponent<BoxCollider>().enabled = false;
            EnableBoundaries();
            gameObject.GetComponent<EnemySpawnerController>().StartSpawnEnemies();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemies-=1;
            Debug.Log("ENEMIES: " + enemies);
        }
    }

    public void EnableBoundaries()
    {
        left.SetActive(true);
        right.SetActive(true);
        float min = left.transform.position.x + boundariesOffset;
        float max = right.transform.position.x + boundariesOffset;
        mainCamera.SetBoundariesX(min, max);
    }

    public void DisableBoundaries()
    {
        left.SetActive(false);
        right.SetActive(false);
        mainCamera.SetDefaultBoundaries();
    }

    public void SetNumEnemies(int enemies)
    {
        this.enemies = enemies;
    }
}
