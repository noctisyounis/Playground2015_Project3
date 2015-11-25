using UnityEngine;
using System.Collections;
using System.Collections.Generic; //For Queue

public class BubbleController : MonoBehaviour
{
    #region Public Variables || Properties
    public GameObject[] Bubbles; //An array of Planet prefabs
    #endregion

    #region Main Methods
    // Use this for initialization
    void Start()
    {
        //Add planets to the Queue (Enqueue them)
        m_availableBubbles.Enqueue(Bubbles[0]);
        m_availableBubbles.Enqueue(Bubbles[1]);
        m_availableBubbles.Enqueue(Bubbles[2]);

        //Call the MovePlanetDown function every 20 seconds
        InvokeRepeating("MoveBubbleUp", 0, 5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Function to dequeue a planet, and set its isMoving flage to true
    //So that the planet starts scrolling down the screen
    void MoveBubbleUp()
    {
        EnqueueBubbles();

        //If the queue is empty, then return
        if (m_availableBubbles.Count == 0)
            return;

        //Get a planet from the queue
        GameObject aBubble = m_availableBubbles.Dequeue();

        //Set the planet isMoving flag to true
        aBubble.GetComponent<Bubble>().m_isMoving = true;
    }

    //Function to Enqueue planet that are below the screen and are not moving
    void EnqueueBubbles()
    {
        foreach (GameObject aBubble in Bubbles)
        {
            //If the planet is below the screen, and the planet is not moving
            if ((aBubble.transform.position.x < 0) && (!aBubble.GetComponent<Bubble>().m_isMoving))
            {
                //Reset the planet position
                aBubble.GetComponent<Bubble>().ResetPosition();

                //Enqueue the planet
                m_availableBubbles.Enqueue(aBubble);
            }
        }
    }
    #endregion

    #region Private && Protected Variables
    private Queue<GameObject> m_availableBubbles = new Queue<GameObject>();
    #endregion
}
