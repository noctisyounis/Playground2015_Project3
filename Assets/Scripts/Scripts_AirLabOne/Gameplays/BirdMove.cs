using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BirdMove : MonoBehaviour {

    public float m_speed = 2f;
    public float m_force = 300;
    public int m_score;
    public int m_playerScore;
    public int m_pointPerChem;
    public float m_offSet;
    public Text m_scoreText;
    public AudioClip m_wingSound;

    public int m_numBlueChem;
    public int m_numPinkChem;
    public int m_numOrangeChem;
    public int m_numCerise;

    // Use this for initialization
    void Start ()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * m_speed;
        m_score = m_playerScore;
        m_scoreText.text = "Score" + m_score;
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * m_force);
            SoundManager.instance.RandomizeSfx(m_wingSound, m_wingSound);
            //Mathf.Clamp(GetComponent<Rigidbody2D>().velocity.x, 0,);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Chems")
        {
            m_score += m_pointPerChem;
            m_scoreText.text = "+" + m_pointPerChem + " " + "Score : " + m_score;
            col.gameObject.transform.position = new Vector3(col.gameObject.transform.position.x + m_offSet, col.gameObject.transform.position.y);
        }
    }

    void OnGUI()
    {
        GUILayout.Button(GetComponent<Rigidbody2D>().velocity + "");
    }
    
	}

