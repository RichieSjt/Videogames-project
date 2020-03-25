using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject follow;
    private Vector3 velocity;
    [SerializeField] private Vector3 minPos, maxPos;
    [SerializeField] private float smoothTime;
    
    void FixedUpdate()
    {
        float x = Mathf.SmoothDamp(transform.position.x,
            follow.transform.position.x,
            ref velocity.x,
            smoothTime);
        float z = Mathf.SmoothDamp(transform.position.z,
            follow.transform.position.z,
            ref velocity.z,
            smoothTime);

        transform.position = new Vector3(
            Mathf.Clamp(x, minPos.x, maxPos.x),
            transform.position.y,
            Mathf.Clamp(z, minPos.z, maxPos.z));
    }
}
