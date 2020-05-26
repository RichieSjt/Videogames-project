using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundtrackManager : MonoBehaviour
{
    public static AudioClip forest, castle, bossBattle;
    private AudioSource soundtrackAudio;

    [Header("Scenes positions")]
    public float forestStart;
    public float castleStart;
    public float bossStart1;

    void Start(){
        forest = Resources.Load<AudioClip>("Forest");
        castle = Resources.Load<AudioClip>("Castle");
        bossBattle = Resources.Load<AudioClip>("BossBattle");
        soundtrackAudio = GetComponent<AudioSource>();
    }

    private void Update() {
        float camPosX = transform.position.x;
        if (camPosX == forestStart)
        {
            //soundtrackAudio.Pause();
            soundtrackAudio.clip = castle;
            soundtrackAudio.Play();
            
        }

        /*if (camPosX == castleStart)
        {
            soundtrackAudio.Pause();
            soundtrackAudio.clip = castle;
            soundtrackAudio.Play();
        }
             
        if (camPosX == bossStart1)
        {
            soundtrackAudio.Pause();
            soundtrackAudio.clip = bossBattle;
            soundtrackAudio.Play();
        }*/
    }
}