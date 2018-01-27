using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject target;
    public float speed = 20f;
    public int charge;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(target != null) {
            transform.LookAt(target.transform);
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            if(Vector3.Distance(transform.position, target.transform.position) < 1f) {
                Destroy(gameObject);
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        var bullet = other.GetComponent<Bullet>();
        if(bullet != null && bullet.gun.charge == this.charge) {
            Destroy(gameObject);
            Destroy(bullet.gameObject);
        }
    }
}
