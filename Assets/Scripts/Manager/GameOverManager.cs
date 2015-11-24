using UnityEngine.UI;
using UnityEngine;
using System.Collections;



public class GameOverManager : MonoBehaviour
{

    #region Public_Members
    
    public HungryScript m_CurrentHunger;
    public float m_restartDelay = 5f;

    #endregion


    #region Main_Methods

    void Awake()
    {
        m_anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if (HungryScript.m_CurrentHungry <= 0)
        {
            HungryScript.Death();
            m_restartTimer += Time.deltaTime;

            if (m_restartTimer >= m_restartDelay)
            {
                Application.LoadLevel("title");
            }
            
        }

    } 

    #endregion

    #region Private_And_Protected

    Animator m_anim;
    float m_restartTimer;

    #endregion
}
