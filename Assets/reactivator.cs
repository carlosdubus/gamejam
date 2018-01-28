using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reactivator : MonoBehaviour {


    float rate = 0.2f;
    float cooldown = 0;
    bool state = false;

    Renderer renderer;
    public GameObject[] restarts;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown <= 0f)
        {
            state = !state;
            foreach(var go in restarts)
            {
                go.SetActive(state);
            }
            cooldown = rate;
        }
    }

    /*private bool once;
    public GameObject[] restarts;

    void Update () {
        if (once == false) { StartCoroutine("restart"); }
	}
	
	// Update is called once per frame
	IEnumerator restart()
    {
        Debug.Log("estamierdafunciona000");
        yield return new WaitForSeconds(0.3f);
        activate();
        yield return new WaitForSeconds(0.3f);
        deactivate();
    }

    void activate()
    {
        foreach (GameObject go in restarts)
        {
            go.gameObject.SetActive(false);
        }
    }

    void deactivate()
    {
        foreach (GameObject go in restarts)
        {
            go.gameObject.SetActive(true);
        }
    }*/

}
