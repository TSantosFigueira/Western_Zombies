﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//! Manages shooting
public class Weapon : MonoBehaviour {

    public GameObject projectile;  //!< The bullet that will be shot from this weapon

    [Range(1, 20)]
    public int damage;             //!< Bullet damage will cause to player and other objects
    [Range(1, 20)]
    public int velocity;           //!< Bullet velocity at start

    [Range(1, 5)]
    public float delayTime;        //<! Time between every shot
    private float timer;           //<! Internal timer controller

    private Vector3 sizeX;

    void Start()
    {
        // Get bullet size to ensure they are shot from the right point, not right above the player's sprite
        // This division by 2, ensures the behaviour is more believable and bullets are not spawned far from the player
        sizeX.x = projectile.GetComponent<SpriteRenderer>().size.x / 2;
        sizeX.y = sizeX.z = 0;
    }

    void Update () {
        timer -= Time.deltaTime;
	}

    public void Shoot()
    {
        if (timer <= 0f)
        {
            timer = delayTime;
            if (GetComponentInParent<PlayerMovement>().isFacingRight)
            {
                GameObject bullet = Instantiate(projectile, transform.position + sizeX, Quaternion.Euler(Vector3.zero));
                bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(velocity, 0), ForceMode2D.Impulse);
            }
            else
            {
                GameObject bullet = Instantiate(projectile, transform.position - sizeX, Quaternion.Euler(new Vector2(0, 180)));
                bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(-velocity, 0), ForceMode2D.Impulse);
            }
        }
    }
}
