using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MagicController : MonoBehaviour
{
    public static int currentMagic;
    public static int numberOfMagicAttacks = 0;

    public ManaBarColor manaBarColor;

    [Header("Magic attack settings")]
    public GameObject fireballPrefab;
    public GameObject slashPrefab;
    public GameObject electricityPrefab;
    public ManaSystem playerMS;

    [Header("Animator")]
    public Animator playerAnim;
    
    [Header("Fire magic settings")]
    public int fireballDamage = 30;
    public int fireballManaPerAttack = 40;

    [Header("Air magic settings")]
    public int airSlashDamage = 20;
    public int airSlashManaPerAttack = 20;

    [Header("Electricity magic settings")]
    public int electricityDamage = 20;
    public int electricityManaPerAttack = 20;

    private void Start()
    {
        currentMagic = 0;
        Load();
        playerMS = PlayerManager.instance.player.GetComponent<ManaSystem>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(currentMagic == 0)
                currentMagic = 0;
            else
            {
                if(currentMagic < numberOfMagicAttacks)
                currentMagic += 1;
                else
                    currentMagic = 1;
                Debug.Log("Current magic index: " + currentMagic);
            }
            manaBarColor.ChangeBarColor(currentMagic);
        }
    }
    public void InstantiateMagicAttack(Vector3 shootDirection, Transform firepoint)
    {  
        if(numberOfMagicAttacks <= 0)
                return;

        //Instantiate fireball
        if(currentMagic == 1)
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
        else if(currentMagic == 2)
        {
            Debug.Log("Instantiating air magic");
            if(playerMS.mana >= airSlashManaPerAttack)
            {  
                playerAnim.SetTrigger("Attack");
                playerMS.ReduceMana(airSlashManaPerAttack);
                SoundManager.PlaySound("AirMagic", 1f);
                
                var rotationVector = transform.rotation.eulerAngles;

                //Rotation may depend on prefab
                if(shootDirection.x > 0)
                    rotationVector.z = 90;
                else
                    rotationVector.z = -90;
                
                GameObject airSlash = Instantiate(slashPrefab, firepoint.position, Quaternion.Euler(rotationVector));
                airSlash.GetComponent<AirSlash>().SetMagicDamage(fireballDamage);
                airSlash.GetComponent<AirSlash>().Setup(shootDirection);
            }
            
        }
        //Instantitate electricity
        else if(currentMagic == 3)
        {
            Debug.Log("Instantiating electricity magic");
            Debug.Log("Instantiating air magic");
            if(playerMS.mana >= electricityManaPerAttack)
            {  
                playerAnim.SetTrigger("Attack");
                playerMS.ReduceMana(electricityManaPerAttack);
                SoundManager.PlaySound("ElectricMagic", 1f);
                
                var rotationVector = transform.rotation.eulerAngles;

                //Rotation may depend on prefab
                if(shootDirection.x > 0)
                    rotationVector.z = 90;
                else
                    rotationVector.z = -90;
                
                GameObject electricity = Instantiate(electricityPrefab, firepoint.position, Quaternion.Euler(rotationVector));
                electricity.GetComponent<ElectricRay>().SetMagicDamage(electricityDamage);
                electricity.GetComponent<ElectricRay>().Setup(shootDirection);
            }
        }
    }

    #region ProgressManager
    public void Load()
    {
        if (System.IO.File.Exists(Application.dataPath+"/save.txt")){
            string saveString = File.ReadAllText(Application.dataPath+"/save.txt");
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
            
            currentMagic = saveObject.savedCurrentMagic;
            numberOfMagicAttacks = saveObject.savedMagicAttacks;
        }
    }
    #endregion
}