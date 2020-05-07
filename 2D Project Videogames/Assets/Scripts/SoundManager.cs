using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip shootSound, enemyShoot, bigShootSound, normalHitSound, bigHitSound;
    static AudioSource audio;

    void Start(){
        shootSound = Resources.Load<AudioClip>("normalShoot");
        bigShootSound = Resources.Load<AudioClip>("bigShoot");
        enemyShoot = Resources.Load<AudioClip>("enemyShoot");
        normalHitSound = Resources.Load<AudioClip>("normalHit");
        bigHitSound = Resources.Load<AudioClip>("bigHit");

        audio = GetComponent<AudioSource>();
    }   

    public static void PlaySound(string clip){
        //To play a sound from another script just do this
        //SoundManagerScript.PlaySound("soundName");
        switch(clip){
            case "normalShoot":
                audio.PlayOneShot(shootSound);
                break;
            case "bigShoot":
                audio.PlayOneShot(bigShootSound);
                break;
            case "enemyShoot":
                audio.PlayOneShot(enemyShoot);
                break;
            case "normalHit":
                audio.PlayOneShot(normalHitSound);
                break;
            case "bigHit":
                audio.PlayOneShot(bigHitSound);
                break;
        }
    }
}
