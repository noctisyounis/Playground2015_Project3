using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour
{
    #region Main Methods
    //Set default value in Awake Function
    void Awake()
    {
        m_speed = 8f;
        m_isReady = false;
    }

    //Function to set the bullet's direction
    public void SetDirection(Vector2 direction)
    {
        //Set the direction normalized, to get a unit vector
        m_direction = direction.normalized;

        //Set the flag to true
        m_isReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isReady)
        {
            //Get the bullet's current position
            Vector2 position = transform.position;

            //Compute the bullet's new position
            position += m_direction * m_speed * Time.deltaTime;

            //Update the bullet position
            transform.position = position;

            //This is the bottom-left point of the screen
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

            //This is ths top-right point of the screen
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); 

            //Destroy the bullet that are outside of the screen
            if ((transform.position.x < min.x) || (transform.position.x > max.x)
                || (transform.position.y < min.y) || (transform.position.y > max.y))
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D Col)
    {
        //Detect the collision of Enemy bullet with the player ship
        if ((Col.tag == "PlayerMobTag"))
        {
            //Destroy the player ship
            Destroy(gameObject); 
        }
    } 
    #endregion

    #region Private && Protected Variables
    //Speed of the bullet
    private float m_speed;

    //Direction of the bullet
    private Vector2 m_direction;

    //To know when the bullet direction is set 
    private bool m_isReady;
    #endregion
}
