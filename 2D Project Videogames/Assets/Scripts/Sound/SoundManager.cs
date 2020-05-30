using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip SlimeMove,SpiderAttack,SpiderDie,SpiderHurt,SpiderMove,SlimeDie,FireBall,SwordSlashSkeleton,SwordSlashPlayer,SkeletonDie,SkeletonHurt,PlayerHurt,BossFire,AirMagic,CastleTheme,ElectricMagic,HoundGrowl,MainMenuTheme,PickUpKey,UseEndGameChest,UseOrb;
    static AudioSource audioSource;

    void Start(){

        SlimeMove = Resources.Load<AudioClip>("SlimeMove");
        SlimeDie = Resources.Load<AudioClip>("SlimeDie");
        FireBall = Resources.Load<AudioClip>("FireBall");
        SwordSlashPlayer = Resources.Load<AudioClip>("SwordSlashPlayer");
        SwordSlashSkeleton = Resources.Load<AudioClip>("SwordSlashSkeleton");
        SkeletonDie = Resources.Load<AudioClip>("SkeletonDie");
        SkeletonHurt = Resources.Load<AudioClip>("SkeletonHurt");
        PlayerHurt = Resources.Load<AudioClip>("PlayerHurt");
        BossFire = Resources.Load<AudioClip>("BossFire");
        SpiderMove = Resources.Load<AudioClip>("SpiderMove");
        SpiderAttack = Resources.Load<AudioClip>("SpiderAttack");
        SpiderDie = Resources.Load<AudioClip>("SpiderDie");
        SpiderHurt = Resources.Load<AudioClip>("SpiderHurt");
        AirMagic = Resources.Load<AudioClip>("AirMagic");
        ElectricMagic = Resources.Load<AudioClip>("ElectricMagic");
        HoundGrowl = Resources.Load<AudioClip>("HoundGrowl");
        PickUpKey = Resources.Load<AudioClip>("PickUpKey");
        UseEndGameChest = Resources.Load<AudioClip>("UseEndGameChest");
        UseOrb = Resources.Load<AudioClip>("UseOrb");
        

        

        audioSource = GetComponent<AudioSource>();
    }   

    public static void PlaySound(string clip, float volume){
        //To play a sound from another script just do this
        //SoundManager.PlaySound("soundName");
        switch(clip){
            case "SlimeMove":
                audioSource.PlayOneShot(SlimeMove);
                audioSource.volume = volume;
                break;
            case "SlimeDie":
                audioSource.PlayOneShot(SlimeDie);
                audioSource.volume = volume;
                break;
            case "FireBall":
                audioSource.PlayOneShot(FireBall);
                audioSource.volume = volume;
                break;
            case "SwordSlashPlayer":
                audioSource.PlayOneShot(SwordSlashPlayer);
                audioSource.volume = volume;
                break;
            case "SwordSlashSkeleton":
                audioSource.PlayOneShot(SwordSlashSkeleton);
                audioSource.volume = volume;
                break;
            case "SkeletonDie":
                audioSource.PlayOneShot(SkeletonDie);
                audioSource.volume = volume;
                break;
            case "SkeletonHurt":
                audioSource.PlayOneShot(SkeletonHurt);
                audioSource.volume = volume;
                break;
            case "PlayerHurt":
                audioSource.PlayOneShot(PlayerHurt);
                audioSource.volume = volume;
                break;
            case "BossFire":
                audioSource.PlayOneShot(BossFire);
                audioSource.volume = volume;
                break;
            case "SpiderMove":
                audioSource.PlayOneShot(SpiderMove);
                audioSource.volume = volume;
                break;
            case "SpiderAttack":
                audioSource.PlayOneShot(SpiderAttack);
                audioSource.volume = volume;
                break;
            case "SpiderDie":
                audioSource.PlayOneShot(SpiderDie);
                audioSource.volume = volume;
                break;
            case "SpiderHurt":
                audioSource.PlayOneShot(SpiderHurt);
                audioSource.volume = volume;
                break;
            case "AirMagic":
                audioSource.PlayOneShot(AirMagic);
                audioSource.volume = volume;
                break;
            case "ElectricMagic":
                audioSource.PlayOneShot(ElectricMagic);
                audioSource.volume = volume;
                break;
            case "HoundGrowl":
                audioSource.PlayOneShot(HoundGrowl);
                audioSource.volume = volume;
                break;
            case "PickUpKey":
                audioSource.PlayOneShot(PickUpKey);
                audioSource.volume = volume;
                break;
            case "UseEndGameChest":
                audioSource.PlayOneShot(UseEndGameChest);
                audioSource.volume = volume;
                break;
            case "UseOrb":
                audioSource.PlayOneShot(UseOrb);
                audioSource.volume = volume;
                break;
        }
    }
}
