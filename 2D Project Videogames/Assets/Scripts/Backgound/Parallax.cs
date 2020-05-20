﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float lenght, startpos,inicialz;
    public GameObject cam;
    public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        startpos=transform.position.x;
        inicialz=transform.position.z;
        lenght=GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp =(cam.transform.position.x*(1-parallaxEffect));
        float dist =(cam.transform.position.x*parallaxEffect);

        transform.position= new Vector3(startpos+dist,4,inicialz);

        if(temp>startpos+lenght)startpos+=lenght;
        else if (temp<startpos-lenght)startpos-=lenght;
    }
}
