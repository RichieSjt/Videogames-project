using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundtrackManager : MonoBehaviour
{
    public static AudioClip forest, castle, bossBattle, graveyard, mainMenu;
    private AudioSource soundtrackAudio;

    [Header("Scenes positions")]
    public float forestStart;
    public float castleStart;
    public float bossStart1;
    public float graveyardStart;

    void Start(){
        mainMenu = Resources.Load<AudioClip>("MainMenu");
        forest = Resources.Load<AudioClip>("Forest");
        castle = Resources.Load<AudioClip>("Castle");
        graveyard = Resources.Load<AudioClip>("Graveyard");
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