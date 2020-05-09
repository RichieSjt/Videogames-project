using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundtrackManager : MonoBehaviour
{
    public static AudioClip forest, castle, bossBattle;
    static AudioSource audio;

    [Header("Scenes positions")]
    public float forestStart;
    public float castleStart;
    public float bossStart1;

    void Start(){
        forest = Resources.Load<AudioClip>("SlimeMove");
        castle = Resources.Load<AudioClip>("SlimeDie");
        bossBattle = Resources.Load<AudioClip>("FireBall");
        audio = GetComponent<AudioSource>();
    }

    private void Update() {
        if (transform.position.x == forestStart)
        {
            audio.Pause();
            audio.clip = forest;
            audio.Play();
        }

        if (transform.position.x == castleStart)
        {
            audio.Pause();
            audio.clip = castle;
            audio.Play();
        }
             
        if (transform.position.x == bossStart1)
        {
            audio.Pause();
            audio.clip = bossBattle;
            audio.Play();
        }
    }
}