using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public float destroyTime =0.2f;
    public Vector3 offset = new Vector3 (0,1,0);
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,destroyTime);
        transform.localPosition+=offset;
    }


}
