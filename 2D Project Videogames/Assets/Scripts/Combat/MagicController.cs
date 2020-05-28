using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicController : MonoBehaviour
{
    [Header("Animator")]
    public Animator playerAnim;
    
    [Header("Magic attack settings")]
    public static int currentMagic;
    private int numberOfMagicAttacks = 3;
    public GameObject fireballPrefab;
    public GameObject slashPrefab;
    public GameObject electricityPrefab;
    public ManaSystem playerMs;
    
    [Header("Fire magic settings")]
    public int fireballDamage = 30;
    public int fireballManaPerAttack = 40;

    [Header("Air magic settings")]
    public int airSlashDamage = 20;
    public int airSlashManaPerAttack = 20;

    [Header("Electricity magic settings")]
    public int electricityDamage = 20;
    public int electricPerAttack = 20;

    private void Awake()
    {
        currentMagic = 0;
        playerMS = PlayerManager.instance.player.GetComponent<ManaSystem>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(currentMagic < numberOfMagicAttacks)
                currentMagic += 1;
            else
                currentMagic = 0;
            
            Debug.Log("Current magic index: " + currentMagic);
        }
    }
    public void InstantiateMagicAttack(Vector3 shootDirection, Transform firepoint)
    {  
        //Instantiate fireball
        if(currentMagic == 0)
        {
            Debug.Log("Instantiating fire magic");

            if(playerMS.mana >= fireballManaPerAttack)
            {  
                playerAnim.SetTrigger("Attack");
                playerMS.ReduceMana(fireballManaPerAttack);
                SoundManager.PlaySound("FireBall", 1f);
                
                var rotationVector = transform.rotation.eulerAngles;

                if(shootDirection.x > 0)
                    rotationVector.z = 90;
                else
                    rotationVector.z = -90;
                
                GameObject fireball = Instantiate(fireballPrefab, firepoint.position, Quaternion.Euler(rotationVector));
                fireball.GetComponent<FireBall>().SetMagicDamage(fireballDamage);
                fireball.GetComponent<FireBall>().Setup(shootDirection);
            }
        }
        //Instantitate air slash
        else if(currentMagic == 1)
        {
            Debug.Log("Instantiating air magic");
            if(playerMS.mana >= airSlashManaPerAttack)
            {  
                playerAnim.SetTrigger("Attack");
                playerMS.ReduceMana(airSlashManaPerAttack);
                //SoundManager.PlaySound("FireBall", 1f);
                
                var rotationVector = transform.rotation.eulerAngles;

                //Rotation may depend on prefab
                if(shootDirection.x > 0)
                    rotationVector.z = 90;
                else
                    rotationVector.z = -90;
                
                GameObject airSlash = Instantiate(slashPrefab, firepoint.position, Quaternion.Euler(rotationVector));
                slashPrefab.GetComponent<AirSlash>().SetMagicDamage(fireballDamage);
                slashPrefab.GetComponent<AirSlash>().Setup(shootDirection);
            }
            
        }
        //Instantitate electricity
        else if(currentMagic == 2)
        {
            Debug.Log("Instantiating electricity magic");
        }
    }
}