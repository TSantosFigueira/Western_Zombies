using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//! Responsible for moving the enemy towards the player
public class EnemyMovement : MonoBehaviour {

    [Range(0, 2)]
    public float movementSpeed = .1f; // Enemy initial velocity

    private Transform player;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();       
	}
	
	void Update () {
        if (!PauseManager.isPaused)
        {
            float step = movementSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);
        }
	}
}
