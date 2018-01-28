using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resize : MonoBehaviour {

    Vector3 size = new Vector3(4, 0.1f, 4);
    Vector3 velocity;
    public float speed;
    public float time = 4f;

	// Update is called once per frame
	void Update () {
        
        transform.Rotate(new Vector3(0,2,0));
        if (time > 0f)
        {
            transform.localScale = Vector3.SmoothDamp(transform.localScale, size, ref velocity, Time.deltaTime * speed);
        } else
        {
            transform.localScale = Vector3.SmoothDamp(transform.localScale, Vector3.zero, ref velocity, Time.deltaTime * speed /3);
        }

        time -= Time.deltaTime;
    }

}
