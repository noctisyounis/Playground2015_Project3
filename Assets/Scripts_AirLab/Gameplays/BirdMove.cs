using UnityEngine;
using System.Collections;

public class BirdMove : MonoBehaviour {

    public float m_speed = 2f;

    public float m_force = 300;


	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * m_speed;
	
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * m_force);
            //Mathf.Clamp(GetComponent<Rigidbody2D>().velocity.x, 0,);
        }
    }

    void OnGUI()
    {
        GUILayout.Button(GetComponent<Rigidbody2D>().velocity + "");
    }
    
	}

