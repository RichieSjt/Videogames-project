﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script attached to checkpoints
public class CheckpointController : MonoBehaviour
{
    private Vector3 checkpoint;
    private bool checkedpoint = false;
    
    private void Update()
    {
        /*if(checkedpoint)
            Destroy(gameObject);*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            checkpoint = other.transform.position;
            other.GetComponent<CheckpointDetection>().SetLastCheckpoint(checkpoint);
            checkedpoint = true;
            gameObject.GetComponent<ProgressManager>().Save();
            //SceneManager.GetActiveScene().buildIndex;
        }
    }
}
