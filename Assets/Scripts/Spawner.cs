﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject player;
    public float rate = 2f;
    float cooldown = 0;
    public float spawnDistance;
    public float maxY = 4f;

    public List<GameObject> enemies = new List<GameObject>();


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(GameState.state != "Running")
        {
            return;
        }
        rate = Mathf.Lerp(rate, 3f, Time.deltaTime * 0.01f);
        cooldown -= Time.deltaTime;
        if (cooldown <= 0f) {
            Spawn();
            cooldown = rate;
        }
	}

    void Spawn(){
        var prefab = enemies[Random.Range(0, enemies.Count)];
        var pos = player.transform.position + Random.onUnitSphere * spawnDistance;
        pos.y = Mathf.Abs(pos.y);
        pos.y = Mathf.Clamp(pos.y, 0f, maxY);

        var enemy = Instantiate(prefab, pos, Quaternion.identity) as GameObject;
        enemy.GetComponent<Enemy>().target = player;
    }
}
