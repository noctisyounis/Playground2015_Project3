using UnityEngine;
using System.Collections;

public class Bubble : MonoBehaviour
{
    #region Public Variables || Properties
    public float m_speed;
    //Flag to make the bubble scroll down the screen
    public bool m_isMoving; 
    #endregion

    #region Main Methods
    void Awake()
    {
        m_isMoving = false;

        m_min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        m_max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //Compute the half size of the sprite with his tranformation
        float halfSize = GetComponent<SpriteRenderer>().sprite.bounds.extents.y * transform.localScale.y;

        //Add the bubble sprite to the half height to max y
        m_max.y = m_max.y + halfSize;

        //Substract the bubble half height to min y
        m_min.y = m_min.y - halfSize;
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!m_isMoving)
            return;

        //Get the current position of the bubble
        Vector2 position = transform.position;

        //Compute the bubble's new position
        position = new Vector2(position.x, position.y + m_speed * Time.deltaTime);

        //Update the planet's position
        transform.position = position;

        //If the bubble gets to the minimun y position
        //Then stop movinge the bubble
        if (transform.position.y > m_max.y)
        {
            m_isMoving = false;
        }
    }

    //Function to reset bubble's position
    public void ResetPosition()
    {
        //Reset the position of the bubble to min y, and random x
        transform.position = new Vector2(Random.Range(m_min.x, m_max.x), m_min.y);
    }
    #endregion

    #region Privates && Protected Variables
    //this is the bottom-left point of the screen
    private Vector2 m_min; 

    //this is the top-left point of the screen
    private Vector2 m_max; 
    #endregion
}
