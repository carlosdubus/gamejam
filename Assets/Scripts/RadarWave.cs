using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarWave : MonoBehaviour
{
    public float maxRadius = 50f;
    public float duration = 2f;
    public SphereCollider collider;
    public GameObject sound;

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
        this.gameObject.transform.localScale = new Vector3(collider.radius-1, collider.radius-1, collider.radius-1);
    }

    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.GetComponent<Enemy>();
        if(enemy != null) {
            CreateSoundOn(enemy.transform.position);
        }
    }

    void CreateSoundOn(Vector3 position)
    {
        var go = Instantiate<GameObject>(sound, position, Quaternion.identity);
        Destroy(go, 5f);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, collider.radius);
    }
}
