using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject target;
    public float speed = 20f;
    public int charge;
    public float sinFrequency = 5f;
    public float sinMagnitude = 1f;
    public Vector3 sinAxis = Vector3.forward;
    public GameObject explodenemy;
    bool once = false;
    public GameObject child;
    public AudioSource locationSound;
    public GameObject portalPrefab;
    public float portalDistance = 10f;
    GameObject portal;
    float initDelay = 2f;
    public bool RL;

    Vector3 pos;

    bool dead = false;

    // Use this for initialization
    void Start()
    {
        pos = transform.position;
        child.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (target == null)
        {
            return;
        }
        transform.LookAt(target.transform);
        var direction = (target.transform.position - transform.position).normalized;
        if (portal == null)
        {
            portal = Instantiate<GameObject>(portalPrefab, transform.position + direction * portalDistance, Quaternion.identity);
        }
        
        initDelay -= Time.deltaTime;
        if (initDelay > 0f)
        {
            return;
        }
        child.SetActive(true);  
        
        if (dead)
        {
            //transform.localScale -= Vector3.one * Time.deltaTime;
            transform.localScale = Vector3.MoveTowards(transform.localScale, Vector3.zero, Time.deltaTime);
            return;
        }

        if (RL == true) { sinAxis = transform.right; } else { sinAxis = transform.up; }
        var oldPos = transform.position;
        pos += direction * speed * Time.deltaTime;
        transform.position = pos + (sinAxis * Mathf.Sin(Time.time * sinFrequency) * sinMagnitude);
       
        child.transform.rotation = Quaternion.LookRotation(transform.position - oldPos);

        //if(Vector3.Distance(transform.position, target.transform.position) < 1f) {
        //    Destroy(gameObject);
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        var bullet = other.GetComponent<Bullet>();
        if (bullet != null && bullet.gun.charge == this.charge)
        {
            Destroy(bullet.gameObject);
            Die();
            return;
        }
    }

    public void Die()
    {
        dead = true;
        var playerDirection = (target.transform.position - transform.position).normalized;
        var explosion = Instantiate(explodenemy, transform.position + playerDirection * 1f, Quaternion.identity) as GameObject;
        Destroy(explosion, 2f);
        StartCoroutine(DestroyGO());
    }

    IEnumerator DestroyGO()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
    }

    void OnDrawGizmos()
    {
        //return;
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 2f);
    }
}