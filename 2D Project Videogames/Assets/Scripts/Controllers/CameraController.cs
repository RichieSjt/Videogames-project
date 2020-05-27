using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Reference")]
    public Transform follow;

    [Header("Settings")]
    public Vector3 offset = new Vector3(0, 10, -10);
    public Vector3 minPosition = new Vector3(0, 0, 0);
    public Vector3 maxPosition = new Vector3(0, 0, 0);
    private Vector3 defaultMax;

    [Header("Smooth")]
    public bool enableSmooth = true;
    public float smoothSpeed = 3f;
    private Vector3 desiredPosition;

    private void Start()
    {
        defaultMax = maxPosition;
    }

    private void LateUpdate()
    {
        float x = Mathf.Clamp(follow.position.x, minPosition.x, maxPosition.x);
        float y = Mathf.Clamp(follow.position.y, minPosition.y, maxPosition.y);
        float z = Mathf.Clamp(follow.position.z, minPosition.z, maxPosition.z);

        desiredPosition = new Vector3(x,y,z) + offset;

        if (enableSmooth)
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);
        else
            transform.position = desiredPosition;
    }

    public void SetBoundariesX(float minX, float maxX)
    {
        minPosition = new Vector3(minX, minPosition.y, minPosition.z);
        maxPosition = new Vector3(maxX, maxPosition.y, maxPosition.z);
    }

    public void SetDefaultBoundaries()
    {
        maxPosition = defaultMax;
    }
}