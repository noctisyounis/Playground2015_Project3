using UnityEngine;
using System.Collections;
using System.Collections.Generic; //For Queue

public class BubbleController : MonoBehaviour
{
    #region Public Variables || Properties
    public GameObject[] Bubbles; //An array of bubble prefabs
    #endregion

    #region Main Methods
    // Use this for initialization
    void Start()
    {
        //Add bubble to the Queue(Enqueue them)
        for (int i = 0; i < Bubbles.Length; i++)
        {
            m_availableBubbles.Enqueue(Bubbles[i]);
        }
                
        //Call the MovePlanetDown function every 7 seconds
        InvokeRepeating("MoveBubbleUp", 0, 7f);
    }

    //Function to dequeue a bubble, and set its isMoving flage to true
    //So that the bubble starts scrolling up the screen
    void MoveBubbleUp()
    {
        EnqueueBubbles();

        //If the queue is empty, then return
        if (m_availableBubbles.Count == 0)
            return;

        //Get a bubble from the queue
        GameObject aBubble = m_availableBubbles.Dequeue();

        //Set the planet isMoving flag to true
        aBubble.GetComponent<Bubble>().m_isMoving = true;
    }

    //Function to Enqueue bubble that are below the screen and are not moving
    void EnqueueBubbles()
    {
        foreach (GameObject aBubble in Bubbles)
        {
            //If the bubble is out of the top of the screen, and the bubble is not moving
            if ((aBubble.transform.position.y > 0) && (!aBubble.GetComponent<Bubble>().m_isMoving))
            {
                //Reset the bubble position
                aBubble.GetComponent<Bubble>().ResetPosition();

                //Enqueue the bubble
                m_availableBubbles.Enqueue(aBubble);
            }
        }
    }
    #endregion

    #region Private && Protected Variables
    private Queue<GameObject> m_availableBubbles = new Queue<GameObject>();
    #endregion
}
