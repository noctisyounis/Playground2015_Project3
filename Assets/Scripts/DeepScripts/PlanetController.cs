using UnityEngine;
using System.Collections;
using System.Collections.Generic; //For Queue

public class PlanetController : MonoBehaviour
{
    #region Public Variables || Properties
    public GameObject[] Planets; //An array of Planet prefabs
    #endregion

    #region Main Methods
    // Use this for initialization
    void Start()
    {
        //Add planets to the Queue (Enqueue them)
        m_availablePlanets.Enqueue(Planets[0]);
        m_availablePlanets.Enqueue(Planets[1]);
        m_availablePlanets.Enqueue(Planets[2]);

        //Call the MovePlanetDown function every 20 seconds
        InvokeRepeating("MovePlanetDown", 0, 20f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Function to dequeue a planet, and set its isMoving flage to true
    //So that the planet starts scrolling down the screen
    void MovePlanetDown()
    {
        EnqueuePlanets();

        //If the queue is empty, then return
        if (m_availablePlanets.Count == 0)
            return;

        //Get a planet from the queue
        GameObject aPlanet = m_availablePlanets.Dequeue();

        //Set the planet isMoving flag to true
        aPlanet.GetComponent<Planet>().m_isMoving = true;
    }

    //Function to Enqueue planet that are below the screen and are not moving
    void EnqueuePlanets()
    {
        foreach (GameObject aPlanet in Planets)
        {
            //If the planet is below the screen, and the planet is not moving
            if ((aPlanet.transform.position.x < 0) && (!aPlanet.GetComponent<Planet>().m_isMoving))
            {
                //Reset the planet position
                aPlanet.GetComponent<Planet>().ResetPosition();

                //Enqueue the planet
                m_availablePlanets.Enqueue(aPlanet);
            }
        }
    }
    #endregion

    #region Private && Protected Variables
    private Queue<GameObject> m_availablePlanets = new Queue<GameObject>();
    #endregion
}
