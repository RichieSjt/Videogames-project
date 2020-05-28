using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicController : MonoBehaviour
{
    [Header("Animator")]
    public Animator playerAnim;

    public static int currentMagic;
    public GameObject fireballPrefab;
    public GameObject slashPrefab;
    public GameObject electricityPrefab;

    private void Awake()
    {
        currentMagic = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(currentMagic < 4)
            {
                currentMagic += 1;
            }
            else
            {
                currentMagic = 0;
            }
        }
    }
    public void InstantiateMagicAttack()
    {
        if(currentMagic == 0)
        {
            //Return fireball
            int magicDamage = 30;
            int manaPerAttack = 40;
            float magicAttackRate = 1f;
            float nextMagicTime = 0f;

            ManaSystem playerMS = PlayerManager.instance.player.GetComponent<ManaSystem>();

            if(playerMS.mana >= manaPerAttack)
            {  
                playerAnim.SetTrigger("Attack");
                playerMS.ReduceMana(manaPerAttack);
                //Vector3 shootDirection = (firepointEnd.position - firepoint.position).normalized;
                SoundManager.PlaySound("FireBall", 1f);
                
                var rotationVector = transform.rotation.eulerAngles;

                //if(shootDirection.x > 0)
                    rotationVector.z = 90;
                //else
                    rotationVector.z = -90;
                
                //GameObject fireball = Instantiate(fireBallPrefab, firepoint.position, Quaternion.Euler(rotationVector));
                //fireball.GetComponent<FireBall>().SetMagicDamage(magicDamage);
                //fireball.GetComponent<FireBall>().Setup(shootDirection);
            }
        }
        else if(currentMagic == 1)
        {
            //Return air magic
        }
        else if(currentMagic == 2)
        {
            //Return electricity magic
        }
    }
}