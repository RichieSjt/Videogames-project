using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    [Header("Enemies to spawn")]
    public GameObject[] enemies;
    public int quantity;
    private int counter = 0;

    [Header("Range")]
    public Vector3 min;
    public Vector3 max;
    private float minX, minZ, maxX, maxZ, maxY;

    [Header("Fixed positions")]
    public bool activateFixed = false;
    public Vector3[] fixedPositions;

    
    private void Start()
    {
        minX = min.x;
        minZ = min.z;
        maxX = max.x;
        maxY = max.y;
        maxZ = max.z;
    }

    private void Update()
    {
        if (counter == quantity)
        {
            CancelInvoke();
            Destroy(gameObject);
        }
            
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<BoxCollider>().enabled = false;
            InvokeRepeating("Spawn",0f,4f);
            InvokeRepeating("Spawn",1.5f,2f);
        }
    }

    private void Spawn()
    {
        Instantiate(RandomEnemy(), RandomPosition(), Quaternion.identity);
        counter +=1;
    }

    private GameObject RandomEnemy()
    {
        int random = Random.Range(0, enemies.Length);
        return enemies[random];
    }

    private Vector3 RandomPosition()
    {
        if (activateFixed)
        {
            int random = Random.Range(0, fixedPositions.Length);
            return fixedPositions[random];
        }
        else
        {
            Vector3 position = new Vector3(Random.Range(minX, maxX), maxY, Random.Range(minZ, maxZ));
            return position;
        }
        
    }
}
