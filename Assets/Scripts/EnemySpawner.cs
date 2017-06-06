using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//! Spawns the enemies, given the time between each spawn
public class EnemySpawner : MonoBehaviour {

    [Range(1, 5)]
    public int delayBetweenSpawns = 2;

    public Transform spawnedObject;
    public bool isFacingRight;

    private float timer;

	void Start () {
        timer = delayBetweenSpawns;      
    }
	
	void Update () {
        timer -= Time.deltaTime;

        if(timer <= 0 && !PauseManager.isPaused)
        {
            GameObject enemy = ObjectPoolingManager.Instance.GetObject(spawnedObject.name);
            enemy.transform.position = transform.position;

            if (!isFacingRight)
                enemy.transform.rotation = Quaternion.Euler(new Vector2(0, 180));
            else
                enemy.transform.rotation = Quaternion.identity;


            enemy.SetActive(true);

            timer = delayBetweenSpawns;
        }
	}
}
