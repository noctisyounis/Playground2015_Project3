using UnityEngine;
using System.Collections;

public class Plancton : MonoBehaviour
{
    #region Public Variables || Properties
    public float m_speed; //Speed of the Plancton 
    #endregion

    #region Main Methods
    // Update is called once per frame
    void Update()
    {
        //Get the current position of the Plancton
        Vector2 position = transform.position;

        //Compute the Plancton new position
        position = new Vector2(position.x + m_speed * Time.deltaTime, position.y);

        //Update the Plancton position
        transform.position = position;

        //This is the bottom-left point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //This is ths the top-right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //If the Plancton goes outside of the left of the screen
        //then position the Plancton on the right edge of the screen
        //and randomly between top and bottom side of the screen
        if (transform.position.x < min.x)
        {
            transform.position = new Vector2(max.x, Random.Range(min.y, max.y));
        }
    } 
    #endregion
}
