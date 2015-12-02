using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour
{
    #region Public Variables || Properties
    public GameObject m_explosion; 
    #endregion

    #region Main Methods
    // Use this for initialization
    void Start()
    {
        m_speed = 4f;
        m_scoreUIText = GameObject.FindGameObjectWithTag("ScoreTextTag");
    }

    // Update is called once per frame
    void Update()
    {
        //Get Enemy position
        Vector2 position = transform.position;

        //Compute the Enemy position
        position = new Vector2(position.x - m_speed * Time.deltaTime, position.y);

        //Update Enemy position
        transform.position = position;

        //This is the bottom-left of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //Destroy if the Enemy went out of the screen
        if (transform.position.x < min.x)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Detect collision of the Enemy with Player Mob or player's bullet
        if ((col.tag == "PlayerMobTag") || (col.tag == "PlayerBulletTag"))
        {
            PlayExplosion();

            //Add 100 points to the score
            m_scoreUIText.GetComponent<GameScore>().score += 100;

            //Destroy enemy
            Destroy(gameObject); 
        }
    }

    void PlayExplosion()
    {
        //Function to initiate an explosion
        GameObject explosion = (GameObject)Instantiate(m_explosion);

        //Set the explosion position
        explosion.transform.position = transform.position;
    } 
    #endregion

    #region Private && Protected Variables
    private float m_speed;
    private GameObject m_scoreUIText;
    #endregion
}
