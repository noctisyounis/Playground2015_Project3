using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    #region Public Variables || Properties
    //This is the enemy prefab
    public GameObject m_enemy;
    int count = 0;
    #endregion

    #region Main Methods
    //Function to spawn enemy
    void SpawnEnemy()
    {
        //Instantiate an enemy at the random x and max y position
        GameObject anEnemy = (GameObject)Instantiate(m_enemy);

        float halfSizeX = anEnemy.GetComponent<SpriteRenderer>().sprite.bounds.extents.x * anEnemy.transform.localScale.x;
        float halfSizeY = anEnemy.GetComponent<SpriteRenderer>().sprite.bounds.extents.y * anEnemy.transform.localScale.y;

        //This is the bottom-left point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //This is the top-right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        min.x = min.x + halfSizeX; //substract the enemy sprite half width
        min.y = min.y + halfSizeY; //add the enemy sprite half width

        max.x = max.x - halfSizeX; // substract the enemy sprite half height
        max.y = max.y - halfSizeY; //add the enemy sprite half height

        //Debug.Log("Min Enemy : " + min + " Max Enemy : " + max);

        m_enemy.transform.position = new Vector2(max.x, Random.Range(min.y, max.y));

        ++count;

        //Shedule when to spawn an enemy
        ScheduleNextEnemySpawn();
    }

    void ScheduleNextEnemySpawn()
    {
        float spawnInNSeconds;

        if (m_maxSpawnRateInSeconds > 0.5f)
        {
            //Pick a number between 1 and MaxSpawnRateInSeconds
            spawnInNSeconds = Random.Range(0.5f, m_maxSpawnRateInSeconds);
        }
        else
        {
            spawnInNSeconds = 0.2f;
        }

        Invoke("SpawnEnemy", spawnInNSeconds);
    }

    //Function to increase difficulty
    void IncreaseSpawnRate()
    {
        if (m_maxSpawnRateInSeconds > 0.5f)
        {
            m_maxSpawnRateInSeconds--;
        }

        if (m_maxSpawnRateInSeconds == 0.5f)
        {
            CancelInvoke("IncreaseSpawnRate");
        }
    }

    //Function to start the enemy spawner
    public void ScheduleEnemySpawner()
    {
        //Reset Max spawn rate
        m_maxSpawnRateInSeconds = 5f;

        Invoke("SpawnEnemy", m_maxSpawnRateInSeconds);

        //Increase SpawnRate every 30seconds
        InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
    }

    //Function to stop the enemy spawner
    public void UnscheduleEnemySpawner()
    {
        CancelInvoke("SpawnEnemy");
        CancelInvoke("IncreaseSpawnRate");
    }
    #endregion

    #region Private && Protected Variables
    private float m_maxSpawnRateInSeconds; 
    #endregion
}
