using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRadar : MonoBehaviour {

    public float rate = 2f;
    float cooldown = 0f;
    public GameObject wave;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GameState.state != "Running")
        {
            return;
        }
        cooldown -= Time.deltaTime;
        if (cooldown <= 0f) {
            Instantiate(wave, transform.position, Quaternion.identity);
            cooldown = rate;
        }
	}
}
