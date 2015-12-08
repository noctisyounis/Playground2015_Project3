using UnityEngine.UI;
using UnityEngine;
using System.Collections;



public class GameOverManager : MonoBehaviour
{

    #region Public_Members
    
    public HungryScript m_CurrentHunger;
    public float m_restartDelay = 5f;
    public HungryScript m_hungryScript;
    #endregion


    #region Main_Methods

    void Awake()
    {
        m_anim = GetComponent<Animator>();
        m_hungryScript = GameObject.Find("Hugh_Jackman").GetComponent<HungryScript>();
    }


    // Update is called once per frame
    void Update()
    {
        if (m_hungryScript.m_CurrentHungry <= 0)
        {
            m_hungryScript.Death();
            m_restartTimer += Time.deltaTime;

            if (m_restartTimer >= m_restartDelay)
            {
                Application.LoadLevel("MainTitle");
            }
            
        }

    } 

    #endregion

    #region Private_And_Protected

    Animator m_anim;
    float m_restartTimer;

    #endregion
}
