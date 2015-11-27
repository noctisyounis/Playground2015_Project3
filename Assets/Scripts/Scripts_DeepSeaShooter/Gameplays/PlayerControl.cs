using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    /*
    Public Variables || properties
    Main Methods
    Utils & Debug
    Private & Protected
    */
    #region Public Variables || Properties
    //Reference to our GameManager
    public GameObject m_gameManager;

    public GameObject m_playerBullet;
    public GameObject m_bulletPosition01;
    public GameObject m_bulletPosition02;
    public GameObject m_explosion;

    //Reference to the live ui text
    public Text m_livesUIText;

    public float m_speed;
    #endregion

    #region Main Methods

    public void Init()
    {
        m_lives = MAX_LIVES;

        //Update the live UI text
        m_livesUIText.text = m_lives.ToString();

        //Reset the player position to the center of the screen
        transform.position = new Vector2(-400, 0);

        //Set this plyer game object to active
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //Fire bullet when the spacebar is pressed
        if (Input.GetKeyDown("space"))
        {
            //Play the laser sounds effect
            GetComponent<AudioSource>().Play();

            //Instantiate the first bullet
            GameObject Bullet01 = (GameObject)Instantiate(m_playerBullet);

            Bullet01.transform.position = m_bulletPosition01.transform.position; //Set the first bullet to initiale position

            //Instantiate the second bullet
            GameObject Bullet02 = (GameObject)Instantiate(m_playerBullet);

            Bullet02.transform.position = m_bulletPosition02.transform.position; //Set the second bullet to initiale position
        }

        //These two lines get the input from keyboard with arrow or ZQSD

        //The value will be -1, 0, or 1 (for left, no value, right)
        float x = Input.GetAxisRaw("Horizontal");

        //The value will be -1, 0, or 1 (for down, no value, up)
        float y = Input.GetAxisRaw("Vertical");

        //Now base on the input we compute a direction vector, and we normalized it to get an unit vector
        Vector2 direction = new Vector2(x, y).normalized;

        //Now we call the function that compute and ste's the player position
        Move(direction);
    }

    void Move(Vector2 direction)
    {
        //Find the screen limits to the player's movement (left, right, top and bottom to the edge of the screen)

        //This is the bottom-left point (corner) of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //This is the top-right point (corner) of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //Compute the half size of the sprite with the transformation
        float halfSizeX = GetComponent<SpriteRenderer>().sprite.bounds.extents.x * transform.localScale.x;
        float halfSizeY = GetComponent<SpriteRenderer>().sprite.bounds.extents.y * transform.localScale.y;

        //Add the player sprite half width
        min.x = min.x + halfSizeX;

        //Add the player sprite half height
        min.y = min.y + halfSizeY;

        //Substract the player sprite half width
        max.x = max.x - halfSizeX;

        //Substract the player sprite half height
        max.y = max.y - halfSizeY;

        //Get player current position
        Vector2 position = transform.position;

        //Calculate the new position
        position += direction * m_speed * Time.deltaTime;

        //Make sure that the new position is not outside the screen
        position.x = Mathf.Clamp(position.x, min.x, max.x);
        position.y = Mathf.Clamp(position.y, min.y, max.y);

        //Update player position
        transform.position = position;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Detect collision of player ship with enemy ship or enemy bullet.
        if ((col.tag == "EnemyMobTag") || (col.tag == "EnemyBulletTag"))
        {
            PlayExplosion();

            //Substract one live
            m_lives--;

            //Update live UItext
            m_livesUIText.text = m_lives.ToString();

            //If our player is dead
            if (m_lives == 0)
            {
                //Change gamemanager state to gameover state
                m_gameManager.GetComponent<GameManager>().SetGameManagerState(GameManager.e_gameManagerState.GameOver);

                //Hide the player's ship 
                gameObject.SetActive(false);
            }
        }
    }

    //Function to instantiate an explosion
    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(m_explosion);

        //Set the explosion position
        explosion.transform.position = transform.position;
    } 
    #endregion

    #region Private && Protected Variables
    //Maximun player's live
    private const int MAX_LIVES = 3;

    //Current plyer live 
    private int m_lives;
    #endregion

}
