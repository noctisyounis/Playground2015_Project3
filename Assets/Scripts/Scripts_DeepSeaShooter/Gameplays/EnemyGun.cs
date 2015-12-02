using UnityEngine;
using System.Collections;

public class EnemyGun : MonoBehaviour
{
    #region Public Variables || Properties
    public GameObject m_enemyBullet; //Our enemy bullet prefab 
    #endregion

    #region Main Methods
    // Use this for initialization
    void Start()
    {
        //Fire en ennemy bullet after 2 second
        InvokeRepeating("FireEnemyBullet",0 , 2f);
    }

    //Function to fire an enemy bullet
    void FireEnemyBullet()
    {
        //Get a reference to the player's reference
        GameObject playerShip = GameObject.Find("Player");

        if (playerShip != null) //If the player isn't dead
        {
            //Instantiate an enemy bullet
            GameObject bullet = (GameObject)Instantiate(m_enemyBullet);

            //Set the bullet's initial position
            bullet.transform.position = transform.position;

            //Compute the bullet's direction toward the player's ship
            Vector2 direction = playerShip.transform.position - bullet.transform.position;

            //Set the bullet direction
            bullet.GetComponent<EnemyBullet>().SetDirection(direction);

            //Play the bubble sounds effect
            GetComponent<AudioSource>().Play();
        }
    }
    #endregion
}
