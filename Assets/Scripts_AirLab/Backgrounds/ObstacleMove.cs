using UnityEngine;
using System.Collections;

public class ObstacleMove : MonoBehaviour {

    public float m_speed;
    
    //changement de direction par seconde
    public float m_switchTime = 2;


	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * m_speed;
        GetComponent<Rigidbody2D>().velocity = Vector2.down * m_speed;

        InvokeRepeating("Switch", 0, m_switchTime);
	}

    void Switch()
    {
        GetComponent<Rigidbody2D>().velocity *= -1;
    }
	
	// Update is called once per frame
	void Update ()
    {
       
	}
}
