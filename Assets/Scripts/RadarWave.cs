using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarWave : MonoBehaviour
{
    public float maxRadius = 50f;
    public float duration = 2f;
    public SphereCollider collider;
    public GameObject sound;

    Renderer renderer;   

    // Use this for initialization
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Color color = renderer.material.color;
        color.a -= 0.1f;
        color.a = Mathf.Clamp01(color.a);
        renderer.material.color = color;

        //Debug.Log(material.color);

        collider.radius += Time.deltaTime * (maxRadius / duration);
        collider.radius = Mathf.Clamp(collider.radius, 0.5f, maxRadius);
        if(collider.radius >= maxRadius) {
            Destroy(gameObject);
        }
        var scale = Mathf.Clamp(collider.radius - 1.7f, 0f, 100f);
        this.gameObject.transform.localScale = new Vector3(scale, scale, scale);
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
