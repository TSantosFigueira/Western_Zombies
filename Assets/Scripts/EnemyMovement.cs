using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//! Responsible for moving the enemy towards the player
public class EnemyMovement : MonoBehaviour {

    private float movementSpeed; 
    private Transform player;

	void Start () {
        movementSpeed = Random.Range(1.5f, 2.5f);
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
