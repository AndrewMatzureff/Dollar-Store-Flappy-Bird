using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour {
    public GameObject pipe;
    public float spawnRate = 2;
    public float heightOffset = 10;
    private float spawnTimer = 0;
    private float challengeTime;

    // Use this for initialization
    void Start () {
        challengeTime = Time.time;
        spawnPipe();
	}
	
	// Update is called once per frame
	void Update () {
        float runtime = Time.time - challengeTime;


        if (spawnTimer < Mathf.Max(Random.Range(1f, 5f), spawnRate - runtime / 10)) {
            spawnTimer = spawnTimer + Time.deltaTime;
        } else {
            spawnPipe();
            spawnTimer = 0;
        }
	}

    void spawnPipe() {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
