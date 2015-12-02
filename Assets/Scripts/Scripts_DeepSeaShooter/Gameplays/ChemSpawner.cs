using UnityEngine;
using System.Collections;

public class ChemSpawner : MonoBehaviour
{
    #region Public Variables || Properties
    //This is the chem prefab
    public GameObject[] m_chems;
    #endregion

    #region Main Methods
    void SpawnChem()
    {
        //Instantiate a random Chem at the random x and max y position
        GameObject aChem = (GameObject)Instantiate(m_chems[Random.Range(0, m_chems.Length)]);

        float halfSizeX = aChem.GetComponent<SpriteRenderer>().sprite.bounds.extents.x * aChem.transform.localScale.x;
        float halfSizeY = aChem.GetComponent<SpriteRenderer>().sprite.bounds.extents.y * aChem.transform.localScale.y;

        //This is the bottom-left point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //This is the top-right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        min.x = min.x + halfSizeX; //substract the chem sprite half width
        min.y = min.y + halfSizeY; //add the chem sprite half width

        max.x = max.x - halfSizeX; // substract the chem sprite half height
        max.y = max.y - halfSizeY; //add the chem sprite half height

        aChem.transform.position = new Vector2(max.x, Random.Range(min.y, max.y));

        //Schedule when to spawn a chem
        ScheduleNextChemSpawn();
    }

    void ScheduleNextChemSpawn()
    {
         Invoke("SpawnChem", 20);
    }

    //Function to start the chem spawner
    public void ScheduleChemSpawner()
    {
        //Set Max spawn rate
        m_maxSpawnRateInSeconds = 30f;

        Invoke("SpawnChem", m_maxSpawnRateInSeconds);
    }

    //Function to stop the Chem Spawner
    public void UnscheduleChemSpawner()
    {
        CancelInvoke("SpawnChem");
    }
    #endregion

    #region Privated && Protected Variables
    private float m_maxSpawnRateInSeconds;
    #endregion
}
