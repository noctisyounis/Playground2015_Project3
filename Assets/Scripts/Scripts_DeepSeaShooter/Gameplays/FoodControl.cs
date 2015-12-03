using UnityEngine;
using System.Collections;

public class FoodControl : MonoBehaviour
{
    #region Public Variables || Properties
    #endregion


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
        //Detect collision of the food with player
        if (col.tag == "PlayerMobTag")
        {
            GetComponent<AudioSource>().Play(); //<---------BUG A CORRIGER-------->

            //<-------------------Add the Chem to playerpref for mainScene----------------------->

            //Destroy food
            Destroy(gameObject);
        }
    }
    #endregion

    #region Private && Protected Variables
    private float m_speed;
    #endregion
}
