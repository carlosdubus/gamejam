using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public GameObject bullet;
    public float bulletSpeed = 10f;
    public OVRInput.Button fireButton;
    public int charge;
    public int maxAmmo = 5;
    public float reloadTime = 1f;

    public int ammo;
    float cooldown = 0f;

	// Use this for initialization
	void Start () {
        ammo = maxAmmo;
	}
	
	// Update is called once per frame
	void Update () {
        
        cooldown -= Time.deltaTime;
        if (cooldown <= 0f) {
            ammo += 1;
            cooldown = reloadTime;
        }
        ammo = Mathf.Clamp(ammo, 0, maxAmmo);

        if(OVRInput.GetDown(fireButton) || Input.GetButtonDown("Fire1")) {
            Fire();
        }
	}

    void Fire() {
        if (ammo <= 0) {
            return;
        }
        cooldown = reloadTime;
        ammo -= 1;
        var bullet = (Instantiate(this.bullet, transform.position, Quaternion.identity) as GameObject).GetComponent<Bullet>();
        
        bullet.speed = bulletSpeed;
        bullet.direction = -transform.up;
        bullet.gun = this;
    }
}
