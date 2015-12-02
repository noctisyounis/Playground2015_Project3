using UnityEngine;
using System.Collections;

public class FoodSpawner : MonoBehaviour
{
    #region Public Variables || Properties
    //This is the food prefab
    public GameObject[] m_foods;
    #endregion

    #region Main Methods
    void SpawnFood()
    {
        //Instantiate a random Food at the random x and max y position
        GameObject aFood = (GameObject)Instantiate(m_foods[Random.Range(0, m_foods.Length)]);

        float halfSizeX = aFood.GetComponent<SpriteRenderer>().sprite.bounds.extents.x * aFood.transform.localScale.x;
        float halfSizeY = aFood.GetComponent<SpriteRenderer>().sprite.bounds.extents.y * aFood.transform.localScale.y;

        //This is the bottom-left point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //This is the top-right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        min.x = min.x + halfSizeX; //substract the Food sprite half width
        min.y = min.y + halfSizeY; //add the Food sprite half width

        max.x = max.x - halfSizeX; // substract the Food sprite half height
        max.y = max.y - halfSizeY; //add the Food sprite half height

        aFood.transform.position = new Vector2(max.x, Random.Range(min.y, max.y));

        //Schedule when to spawn a Food
        ScheduleNextFoodSpawn();
    }

    void ScheduleNextFoodSpawn()
    {
        Invoke("SpawnFood", 15);
    }

    //Function to start the food spawner
    public void ScheduleFoodSpawner()
    {
        //Set Max spawn rate
        m_maxSpawnRateInSeconds = 15f;

        Invoke("SpawnFood", m_maxSpawnRateInSeconds);
    }

    //Function to stop the Food Spawner
    public void UnscheduleFoodSpawner()
    {
        CancelInvoke("SpawnFood");
    }
    #endregion

    #region Private && Protected Variables
    private float m_maxSpawnRateInSeconds;
    #endregion
}
