using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour
{
    #region Main Methods
    //Set default value in Awake Function
    void Awake()
    {
        m_speed = 31.25f;
        m_isReady = false;
    }

    // Use this for initialization
    void Start()
    {

    }

    //Function to set the bullet's direction
    public void SetDirection(Vector2 direction)
    {
        //Set the direction normalized, to get a unit vector
        m_direction = direction.normalized;
        m_isReady = true; //Set the flag to true
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

            //Destroy the bullet that are outside of the screen
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); //This is the bottom-left point of the screen
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); //This is ths top-right point of the screen

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
        if ((Col.tag == "PlayerShipTag"))
        {
            Destroy(gameObject); //Destroy the player ship
        }
    } 
    #endregion

    #region Private && Protected Variables
    private float m_speed; //Speed of the bullet
    private Vector2 m_direction; //Direction of the bullet
    private bool m_isReady; //To know when the bullet direction is set 
    #endregion
}
