using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointDetection : MonoBehaviour
{
    private Vector3 lastCheckpoint;

    public void SetLastCheckpoint(Vector3 checkpoint)
    {
        lastCheckpoint = checkpoint;
        //Debug.Log("Checkpoint");
    }

    public void ReturnToLastCheckpoint()
    {
        transform.position = lastCheckpoint;
    }
}
