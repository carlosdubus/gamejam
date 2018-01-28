using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

    static public string state = "Init";
    public float initTime = 5f;
    static float timeInState = 0f;

	// Use this for initialization
	void Start () {
        timeInState = 0f;
	}
	
	// Update is called once per frame
	void Update () {

        if(state == "Init" && timeInState > initTime)
        {
            ChangeState("Running");
        }

        timeInState += Time.deltaTime;
	}

    public static bool ChangeState(string newState)
    {
        if(newState == state)
        {
            return false;
        }
        state = newState;
        timeInState = 0f;
        return true;
    }
}
