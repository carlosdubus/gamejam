using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject target;
    public float speed = 20f;
    public int charge;
    public float sinFrequency = 5f;
    public float sinMagnitude = 1f;
    public Vector3 sinAxis = Vector3.forward;

    Vector3 pos;

	// Use this for initialization
	void Start () {
        pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if(target == null) {
            return;
        }
        var direction = (target.transform.position - transform.position).normalized;
        var oldPos = transform.position;
        pos += direction * speed * Time.deltaTime;
        transform.position = pos + sinAxis * Mathf.Sin(Time.time * sinFrequency) * sinMagnitude;
        transform.forward = (transform.position - oldPos).normalized;

        if(Vector3.Distance(transform.position, target.transform.position) < 1f) {
            Destroy(gameObject);
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
