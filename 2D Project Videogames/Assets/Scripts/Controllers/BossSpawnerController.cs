using UnityEngine;

public class BossSpawnerController : MonoBehaviour
{
    [Header("Enemies to spawn")]
    public GameObject[] enemies;

    [Header("Range")]
    public Transform player;
    public float offset = 0;
    private float x,y,z;

    [Header("Boss detection")]
    public DemonBossController bossController;
    
    private void Start()
    {
        StartSpawnEnemies();
    }

    private void Update()
    {
        x = player.position.x;
        y = player.position.y;
        z = player.position.z;  
        
        
        if(!bossController.isAlive)
            CancelInvoke();
        
    }

    public void StartSpawnEnemies()
    {
        InvokeRepeating("Spawn",1f,4f);
        InvokeRepeating("Spawn",4.5f,3.5f);
    }

    private void Spawn()
    {
        Instantiate(RandomEnemy(), RandomPosition(), Quaternion.identity);
    }

    private GameObject RandomEnemy()
    {
        int random = Random.Range(0, enemies.Length);
        return enemies[random];
    }

    private Vector3 RandomPosition()
    {
        Vector3 position = new Vector3(Random.Range(x-offset, x+offset), y, Random.Range(z-offset, z+offset));
        return position;
    }
}
