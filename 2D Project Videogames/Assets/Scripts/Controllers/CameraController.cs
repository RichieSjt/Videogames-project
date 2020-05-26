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
    private float defaultMaxX, defaultMaxY, defaultMaxZ;
    private float minX, minY, minZ, maxX, maxY, maxZ;

    [Header("Smooth")]
    public bool enableSmooth = true;
    public float smoothSpeed = 3f;
    private Vector3 desiredPosition;

    private void Start()
    {
        minX = minPosition.x;
        minY = minPosition.y;
        minZ = minPosition.z;
        maxX = maxPosition.x;
        maxY = maxPosition.y;
        maxZ = maxPosition.z;
    }

    private void LateUpdate()
    {
        float x = Mathf.Clamp(follow.position.x, minX, maxX);
        float y = Mathf.Clamp(follow.position.y, minY, maxY);
        float z = Mathf.Clamp(follow.position.z, minZ, maxZ);

        desiredPosition = new Vector3(x,y,z) + offset;

        if (enableSmooth)
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);
        else
            transform.position = desiredPosition;
    }

    public void SetBoundariesX(float minX, float maxX)
    {
        Debug.Log("CHANGED "+minX+" "+maxX);
        this.minX = minX;
        this.maxX = maxX;
    }

    public void SetDefaultBoundaries()
    {
        maxX = defaultMaxX;
        maxY = defaultMaxY;
        maxZ = defaultMaxZ;
    }

    /*public GameObject follow;
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
    }*/
}
