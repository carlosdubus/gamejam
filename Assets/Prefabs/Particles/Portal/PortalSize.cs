using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSize : MonoBehaviour {

    Vector3 size = new Vector3(4, 4, 4);
    Vector3 velocity;
    public float speed;
    public float time;

    // Update is called once per frame

    private void Awake()
    {
        transform.localScale = Vector3.zero;
    }

    void Update()
    {

        if (time > 0f)
        {
            transform.localScale = Vector3.SmoothDamp(transform.localScale, size, ref velocity, Time.deltaTime * speed);
        }
        else
        {
            transform.localScale = Vector3.SmoothDamp(transform.localScale, Vector3.zero, ref velocity, Time.deltaTime * speed / 2);
        }

        time -= Time.deltaTime;
    }
}
