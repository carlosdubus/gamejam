﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public GameObject bullet;
    public float bulletSpeed = 10f;
    public OVRInput.Button fireButton;
    public int charge;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(OVRInput.GetDown(fireButton)) {
            Fire();
        }
	}

    void Fire() {
        var bullet = (Instantiate(this.bullet, transform.position, Quaternion.identity) as GameObject).GetComponent<Bullet>();
        
        bullet.speed = bulletSpeed;
        bullet.direction = -transform.up;
        bullet.gun = this;
    }
}
