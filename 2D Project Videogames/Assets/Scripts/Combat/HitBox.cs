using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    private BoxCollider hitBox;
    private Collider hitEnemies;
    private Collider hitPlayer;

    private void Start()
    {
        hitBox = GetComponent<BoxCollider>();
        DisableHitBox(0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
            hitEnemies = other;

        if (other.gameObject.tag == "Player")
            hitPlayer = other;
    }

    public Collider GetHittedObject(string name)
    {
        if (name == "Enemy")
        {
            Collider enemy = hitEnemies;
            hitEnemies = null;
            return enemy;
        }
        if (name == "Player")
        {
            Collider player = hitPlayer;
            hitPlayer = null;
            return player;
        }
        else
            return null; 
    }

    public void EnableHitBox()
    {
        hitBox.enabled = true;
    }

    public void DisableHitBox(float time)
    {
        StartCoroutine(DisableAfterTime(time));
    }

    IEnumerator DisableAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        hitBox.enabled = false;
    }
}
