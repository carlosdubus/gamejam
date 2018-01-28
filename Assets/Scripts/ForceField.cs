using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour {

    public Material material;
    public Color initialColor;
    float distortStregth = 0f;
    float intensity = 0f;
    Color color;
    
	// Use this for initialization
	void Start () {
        color = initialColor;
	}
	
	// Update is called once per frame
	void Update () {
        material.SetFloat("_DistortStrength", distortStregth);
        material.SetFloat("_IntersectPower", intensity);
        material.SetColor("_Color", color);
        distortStregth = Mathf.Lerp(distortStregth, 0f, Time.deltaTime * 5f);
        intensity = Mathf.Lerp(intensity, 0f, Time.deltaTime * 0.5f);
        color = Color.Lerp(color, initialColor, Time.deltaTime * 0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.Die();
            intensity = 0.5f;
            distortStregth = 0.5f;
            color = Color.red;
        }
    }
}
