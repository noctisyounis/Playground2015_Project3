using UnityEngine;
using System.Collections;

public class PlanctonGenerator : MonoBehaviour
{
    #region Public Variables || Properties
    //Refer to our starGO
    public GameObject m_plancton;

    //Maximun of stars 
    public int m_maxPlancton;
    #endregion

    #region Main Methods
    // Use this for initialization
    void Start()
    {
        //This is the bottom-left point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //This is the top-right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //Loop to create Plancton
        for (int i = 0; i < m_maxPlancton; i++)
        {
            GameObject plancton = (GameObject)Instantiate(m_plancton);

            //Set the Plancton color
            m_plancton.GetComponent<SpriteRenderer>().color = m_planctonColor[i % m_planctonColor.Length];

            //Set the position of the Plancton (randomly)
            m_plancton.transform.position = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));

            //Set a random speed of the Plancton
            m_plancton.GetComponent<Plancton>().m_speed = -(1f * Random.value + 0.5f);

            //Make the Plancton a child of the PlanctonGenerator
            plancton.transform.parent = transform;
        }
    }
    #endregion

    #region Private && Protected Variables
    //Array of color
    private Color[] m_planctonColor =
    {
        //Blue
        new Color(0.5f, 0.5f, 1f),

        //DeepBlue
        new Color(0.02f, 0.275f, 0.431f),

        //Green
        new Color(0.059f, 0.333f, 0.118f),

        //DeepGreen
        new Color(0.098f, 0.647f, 0.392f),
    };
    #endregion
}
