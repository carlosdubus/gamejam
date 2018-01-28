using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockText : MonoBehaviour {


    public TextMesh textMesh;
    public float time = 3 * 60;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        time = Mathf.Clamp(time, 0f, 20f);

        var minutes = Mathf.Floor(time / 60f);
        var seconds = (int)time % 60;

        textMesh.text = string.Format("{0}:{1:00}", minutes, seconds);
        time -= Time.deltaTime;

        if (time <= 0f) {
            Debug.Log("WIN");
        }
	}
}
