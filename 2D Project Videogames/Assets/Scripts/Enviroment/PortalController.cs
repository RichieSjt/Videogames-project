using UnityEngine;

public class PortalController : Enemy
{
    public DemonBossController bossController;
    public GameObject portalPrefab;
    public GameObject airOrb;
    public GameObject key2;
    private bool once = false;

    private void Update()
    {
        if(!bossController.isAlive && !once)
        {
            //Spawn portal
            Instantiate(portalPrefab, new Vector3(-7.05f, -1.2f, 0), Quaternion.identity);
            //Spawn Air Orb
            Instantiate(airOrb, new Vector3(-2.56f, -2.75f, -0.47f), Quaternion.identity);
            //Spawn key 2
            Instantiate(key2, new Vector3(1.4f, -1.01f, -0.47f), Quaternion.identity);

            once = true;
        }
    }

}