using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour {
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public GameObject leftWing;
    public GameObject rightWing;

    // Use this for initialization
    void Start () {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
	
	// Update is called once per frame
	void Update () {
        if (birdIsAlive && (transform.position.y < -20 || transform.position.y > 50)) {
            die();
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && birdIsAlive) {
            leftWing.GetComponent<Animator>().SetTrigger("FlapTrigger");
            rightWing.GetComponent<Animator>().SetTrigger("FlapTrigger");

            myRigidbody.velocity = Vector2.up * flapStrength;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (birdIsAlive) {
            die();
        }
    }

    private void die() {
        birdIsAlive = false;
        logic.gameOver();
    }
}
