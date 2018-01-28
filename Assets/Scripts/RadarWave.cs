using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarWave : MonoBehaviour
{
    public float maxRadius = 50f;
    public float duration = 2f;
    public SphereCollider collider;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        collider.radius += Time.deltaTime * (maxRadius / duration);
        collider.radius = Mathf.Clamp(collider.radius, 0.5f, maxRadius);
        if(collider.radius >= maxRadius) {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.GetComponent<Enemy>();
        if(enemy != null) {
            enemy.locationSound.Play();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, collider.radius);
    }
}
