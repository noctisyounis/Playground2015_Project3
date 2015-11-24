using UnityEngine;
using System.Collections;

public class StarGenerator : MonoBehaviour
{
    #region Public Variables || Properties
    public GameObject m_star; //Refer to our starGO
    public int m_maxStars; //Maximun of stars 
    #endregion

    #region Main Methods
    // Use this for initialization
    void Start()
    {
        //This is the bottom-left point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //This is the top-right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //Loop to create Stars
        for (int i = 0; i < m_maxStars; i++)
        {
            GameObject star = (GameObject)Instantiate(m_star);

            //Set the stars color
            m_star.GetComponent<SpriteRenderer>().color = m_starColor[i % m_starColor.Length];

            //Set the position of the star (randomly)
            m_star.transform.position = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));

            //Set a random speed of the star
            m_star.GetComponent<Star>().m_speed = -(1f * Random.value + 0.5f);

            //Make the star a chikd of the StarGenerator
            star.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {

    } 
    #endregion

    #region Private && Protected Variables
    //Arry of color
    private Color[] m_starColor =
    {
        new Color(0.5f,0.5f,1f), //Blue
        new Color(0,1f,1f), //Green
        new Color(1f,0,0), //Yellow
        new Color(1f,0,0) //Red
    };
    #endregion
}
