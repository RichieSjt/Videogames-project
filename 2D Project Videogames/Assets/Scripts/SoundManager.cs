using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip SlimeMove, SlimeDie;
    static AudioSource audio;

    void Start(){
        SlimeMove = Resources.Load<AudioClip>("SlimeMove");
        SlimeDie = Resources.Load<AudioClip>("SlimeDie");
        
        /*shootSound = Resources.Load<AudioClip>("normalShoot");
        bigShootSound = Resources.Load<AudioClip>("bigShoot");
        enemyShoot = Resources.Load<AudioClip>("enemyShoot");
        normalHitSound = Resources.Load<AudioClip>("normalHit");
        bigHitSound = Resources.Load<AudioClip>("bigHit");*/

        audio = GetComponent<AudioSource>();
    }   

    public static void PlaySound(string clip, float volume, float pitch){
        //To play a sound from another script just do this
        //SoundManagerScript.PlaySound("soundName");
        switch(clip){
            case "SlimeMove":
                audio.PlayOneShot(SlimeMove);
                audio.volume = volume;
                audio.pitch = pitch;
                break;
            case "SlimeDie":
                audio.PlayOneShot(SlimeDie);
                audio.volume = volume;
                audio.pitch = pitch;
                break;
        }
    }
}
