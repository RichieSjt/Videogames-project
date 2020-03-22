using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public GameObject follow;
    public Vector2 minPos, maxPos;
    public float smoothTime;
    private Vector2 velocity;

    void Start() {
        
    }

    void FixedUpdate() {
        float x = Mathf.SmoothDamp(transform.position.x,
            follow.transform.position.x,
            ref velocity.x,
            smoothTime);
        float y = Mathf.SmoothDamp(transform.position.y,
            follow.transform.position.y,
            ref velocity.y,
            smoothTime);

        transform.position = new Vector3(
            Mathf.Clamp(x, minPos.x, maxPos.x),
            Mathf.Clamp(y, minPos.y, maxPos.y),
            transform.position.z);
    }
}
