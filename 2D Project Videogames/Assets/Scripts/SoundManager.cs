using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip SlimeMove,SpiderAttack,SpiderDie,SpiderHurt,SpiderMove,SlimeDie,FireBall,SwordSlashSkeleton,SwordSlashPlayer,SkeletonDie,SkeletonHurt,PlayerHurt,BossFire;
    static AudioSource audio;

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
        

        audio = GetComponent<AudioSource>();
    }   

    public static void PlaySound(string clip, float volume){
        //To play a sound from another script just do this
        //SoundManager.PlaySound("soundName");
        switch(clip){
            case "SlimeMove":
                audio.PlayOneShot(SlimeMove);
                audio.volume = volume;
                break;
            case "SlimeDie":
                audio.PlayOneShot(SlimeDie);
                audio.volume = volume;
                break;
            case "FireBall":
                audio.PlayOneShot(FireBall);
                audio.volume = volume;
                break;
            case "SwordSlashPlayer":
                audio.PlayOneShot(SwordSlashPlayer);
                audio.volume = volume;
                break;
            case "SwordSlashSkeleton":
                audio.PlayOneShot(SwordSlashSkeleton);
                audio.volume = volume;
                break;
            case "SkeletonDie":
                audio.PlayOneShot(SkeletonDie);
                audio.volume = volume;
                break;
            case "SkeletonHurt":
                audio.PlayOneShot(SkeletonHurt);
                audio.volume = volume;
                break;
            case "PlayerHurt":
                audio.PlayOneShot(PlayerHurt);
                audio.volume = volume;
                break;
            case "BossFire":
                audio.PlayOneShot(BossFire);
                audio.volume = volume;
                break;
            case "SpiderMove":
                audio.PlayOneShot(SpiderMove);
                audio.volume = volume;
                break;
            case "SpiderAttack":
                audio.PlayOneShot(SpiderAttack);
                audio.volume = volume;
                break;
            case "SpiderDie":
                audio.PlayOneShot(SpiderDie);
                audio.volume = volume;
                break;
            case "SpiderHurt":
                audio.PlayOneShot(SpiderHurt);
                audio.volume = volume;
                break;

            
        }
    }
}
