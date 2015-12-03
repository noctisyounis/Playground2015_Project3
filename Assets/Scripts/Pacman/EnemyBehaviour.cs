using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyBehaviour : MonoBehaviour {

    #region Public Variable
    public Vector2[] m_waypoints;
    public Vector2 m_startPosition;
    public Vector2 m_first;
    public GameObject m_door;
    public float m_speed;
    public float m_time;
    public float m_minTime = 1.0f;
    public float m_maxTime = 3.0f;
    public bool m_isOut;
    public int m_current;
    #endregion

    #region Main Methodes

    void Start()
    {
        m_rgb2D = GetComponent<Rigidbody2D>();
        transform.position = m_startPosition;
        m_time = Random.Range(m_minTime, m_maxTime);
        m_isOut = false;
        m_current = 0;
    }

    void FixedUpdate()
    {
        if(m_time <= 0)
        {
            if(m_isOut == false)
            {
                m_door.SetActive(false);
                Vector2 position = Vector2.MoveTowards(transform.position, m_first, m_speed);
                m_rgb2D.MovePosition(position);

                if ((Vector2)transform.position == m_first)
                {
                    m_isOut = true;
                    m_door.SetActive(true);
                }
            }
            else
            {
                Vector2 position = Vector2.MoveTowards(transform.position, m_waypoints[m_current], m_speed);
                m_rgb2D.MovePosition(position);

                if((Vector2) transform.position == m_waypoints[m_current])
                {
                    m_current += 1;

                    if(m_current >= m_waypoints.Length)
                    {
                        m_current = 0;
                    }
                }
            }
        }
        else
        {
            m_time -= Time.fixedDeltaTime;
        }
    }
    #endregion

    #region Utils

    #endregion

    #region Private & Protected Variables
    Rigidbody2D m_rgb2D;
    #endregion
}
