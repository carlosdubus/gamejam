using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForceField : MonoBehaviour {

    public Material material;
    public Color initialColor;
    float distortStregth = 0f;
    float intensity = 0f;
    float targetIntensity = 0f;
    float intensitySpeed = 0.5f;
    Color color;
    public List<GameObject> hearts = new List<GameObject>();
    public OculusHaptics Lhaptics;
    public OculusHaptics Rhaptics;

    // Use this for initialization
    void Start () {
        color = initialColor;
        intensity = 3f;
	}
	
	// Update is called once per frame
	void Update () {

        material.SetFloat("_DistortStrength", distortStregth);
        material.SetFloat("_IntersectPower", intensity);
        material.SetColor("_Color", color);

        distortStregth = Mathf.Lerp(distortStregth, 0f, Time.deltaTime * 5f);
        intensity = Mathf.Lerp(intensity, targetIntensity, Time.deltaTime * 0.5f);
        color = Color.Lerp(color, initialColor, Time.deltaTime * intensitySpeed);

        if(hearts.Count == 0) {
            GameState.ChangeState("Dead");
            intensitySpeed = 0.5f;
            targetIntensity = 3f;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
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
            RemoveHeart();
            StartCoroutine(Lhaptics.VibrateTime(VibrationForce.Hard, 1));
            StartCoroutine(Rhaptics.VibrateTime(VibrationForce.Hard, 1));
        }
    }

    void RemoveHeart()
    {
        if(hearts.Count == 0)
        {
            return;
        }
        var heart = hearts[hearts.Count - 1];
        heart.SetActive(false);
        hearts.Remove(heart);
    }
}
