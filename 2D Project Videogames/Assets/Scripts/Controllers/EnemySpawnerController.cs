using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    [Header("Enemies to spawn")]
    public GameObject[] enemies;
    public int quantity;
    private int counter = 0;
    private GameObject[] temp;

    [Header("Range")]
    public Transform player;
    public float offset = 0;
    private float x,y,z;

    [Header("Fixed positions")]
    public bool activateFixed = false;
    public Vector3[] fixedPositions;

    
    private void Start()
    {
        temp = new GameObject[quantity];
    }

    private void Update()
    {
        x = player.position.x;
        y = player.position.y;
        z = player.position.z;

        if (counter == quantity)
        {
            CancelInvoke();
            //Destroy(gameObject);
        }    
    }

    public void StartSpawnEnemies()
    {
        InvokeRepeating("Spawn",2f,4f);
        InvokeRepeating("Spawn",4.5f,3f);
    }

    private void Spawn()
    {
        temp[counter] = Instantiate(RandomEnemy(), RandomPosition(), Quaternion.identity);
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
            Vector3 position = new Vector3(Random.Range(x-offset, x+offset), y, Random.Range(z-offset, z+offset));
            return position;
        } 
    }

    public bool CheckRemainingEnemies()
    {
        bool enemies = true;
        int counter = quantity;
        for (int i = 0; i < temp.Length; i++)
        {
            if (temp[i] == null)
                counter-=1;
        }

        if (counter == 0)
            enemies = false;
        return enemies;
    }
}
