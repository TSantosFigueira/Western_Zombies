using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//! Responsible for managing bullet effects like damage
public class Bullet : MonoBehaviour {

    [Range(1, 5)]
    public int duration;
    private Sounds manager;

	void Start () {
        manager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<Sounds>();
        manager.playSound("Shot", 0.5f);
        Destroy(gameObject, duration);
	}
	
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<ExplodePlayer>().Explosion();
            collision.gameObject.SetActive(false);
            manager.playSound("EnemyDeath", 0.5f);
            PlayerScore.localScore += 1;
            Destroy(gameObject);
        }
    }
}
