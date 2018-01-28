using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinMove : MonoBehaviour
{
    public float sinFrequency = 5f;
    public float sinMagnitude = 1f;
    Vector3 sinAxis = Vector3.right;
    Vector3 pos;
    // Use this for initialization
    void Start()
    {
        pos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //var sinAxis = transform.lo
        transform.localPosition = pos + sinAxis * Mathf.Sin(Time.time * sinFrequency) * sinMagnitude;
    }
}
