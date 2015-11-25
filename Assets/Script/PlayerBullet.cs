﻿using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour
{
    #region Main Methods
    // Use this for initialization
    void Start()
    {
        m_speed = 50f;
    }

    // Update is called once per frame
    void Update()
    {
        //Get the bullet position
        Vector2 position = transform.position;

        //Compute the bullet's new position
        position = new Vector2(position.x + m_speed * Time.deltaTime, position.y);

        //Update bullet position

        transform.position = position;

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); //this is the top-right of the screen

        if (transform.position.x > max.x) //Destroy the bullet that go outside of the screen
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D Col)
    {
        //Detect collision of player bullet with enemy ship
        if ((Col.tag == "EnemyShipTag"))
        {
            //Destroy enemy ship
            Destroy(gameObject);
        }
    } 
    #endregion

    #region Private && Protected Variables
    private float m_speed;
    #endregion
}
