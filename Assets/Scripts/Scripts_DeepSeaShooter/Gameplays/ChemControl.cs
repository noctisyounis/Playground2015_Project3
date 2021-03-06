﻿using UnityEngine;
using System.Collections;

public class ChemControl : MonoBehaviour
{
    #region Main Methods
    // Use this for initialization
    void Start()
    {
        m_speed = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        //Get a Chem position
        Vector2 position = transform.position;

        //Compute the Chem position
        position = new Vector2(position.x - m_speed * Time.deltaTime, position.y);

        //Update the Chem position
        transform.position = position;

        //This is the bottom-left of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //Destroy if the Chem went out of the screen
        if (transform.position.x < min.x)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        PlayerControl player = col.GetComponent<PlayerControl>();

        //Detect collision of the Chem with Player
        if (col.tag == "PlayerMobTag")
        {
            Instantiate(Resources.Load("SoundChemsDSS"));

            //<-------------------Add the Chem to playerpref for mainScene----------------------->
            if(tag == "BlueChem")
            {
                player.m_numBlueChem += 1;
            }
            else if(tag == "PinkChem")
            {
                player.m_numPinkChem += 1;
            }
            else if(tag == "OrangeChem")
            {
                player.m_numOrangeChem += 1;
            }
            //Destroy Chem
            Destroy(gameObject);
        }
    }
    #endregion

    #region Private || Protected Variables
    private float m_speed;
    #endregion
}
