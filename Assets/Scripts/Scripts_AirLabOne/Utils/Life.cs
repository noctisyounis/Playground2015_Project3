using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class Life : MonoBehaviour
{
    #region PublicVariable
    public GameObject m_gameManager;
    public int m_startLife = 100;
    public int m_currentLife;
    public int m_damageOnCol = 20;
    public Slider m_lifeSlider;
    public Image m_damageImage;
    public Color m_flashColor = new Color(1f, 0f, 0f, 0.1f);
    public GameObject m_Opening;
    
    
    #endregion

    #region MainMethod

    void Awake()
    {
        m_currentLife = m_startLife;
    }


     // Use this for initialization
    void Start ()
    {
        if (PlayerPrefs.HasKey("life"))
        {
            if( PlayerPrefs.GetInt("life") <= 0)
            {
                PlayerPrefs.DeleteKey("life");
                return;
            }
            m_currentLife = PlayerPrefs.GetInt("life");
            m_Opening.SetActive(false);
            
            m_lifeSlider.value = m_currentLife;
        }  
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (m_damageImage != null)
        {
            if (m_damaged)
            {
                m_damageImage.color = m_flashColor;
            }            
            m_damaged = false;
        }
	}

    void TakeDamage()
    {
        m_damaged = true;
        m_currentLife -= m_damageOnCol;
        PlayerPrefs.SetInt("life", m_currentLife);

        int xpInt = GetComponent<BirdMove>().m_score;

        m_lifeSlider.value = m_currentLife;

        if (m_damaged  && m_currentLife > 0)
        {
            if (PlayerPrefs.HasKey("SCORE"))
            {
                int oldXp = PlayerPrefs.GetInt("SCORE");

                PlayerPrefs.SetInt("SCORE", xpInt + oldXp);
            }
            else
            {
                PlayerPrefs.SetInt("SCORE", xpInt);
            }

            PlayerPrefs.SetInt("life", m_currentLife);
            Application.LoadLevel("AirLabOne");            
        }        
        else if (m_currentLife <= 0 && !m_isDead)
        {
            if (PlayerPrefs.HasKey("SCORE"))
            {
                int oldXp = PlayerPrefs.GetInt("SCORE");

                PlayerPrefs.SetInt("SCORE", xpInt + oldXp);
            }
            else
            {
                PlayerPrefs.SetInt("SCORE", xpInt);
            }
            Death();
        }      
    }

    void OnCollisionEnter2D()
    {
        TakeDamage();
    }

    void Death()
    {
        m_isDead = false;
        //Hide the player's bird
        gameObject.SetActive(false);
        //Change the GameManager state to GameOver
        m_gameManager.GetComponent<GameManagerALO>().SetGameManagerState(GameManagerALO.e_gameManagerState.GameOver);
    }

    #endregion

    #region PrivateAndProtected

    bool m_damaged;
    static bool m_isDead;
    #endregion


}
