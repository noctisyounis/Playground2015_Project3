using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameScore : MonoBehaviour
{
    #region Public Variables || Properties
    public int score
    {
        get
        {
            return this.m_score;
        }

        set
        {
            this.m_score = value;
            UpdateScoreTextUI();
        }
    }
    #endregion
    
    #region Main Methods
    // Use this for initialization
    void Start()
    {
        //Get TextUI componement of this gameobject
        m_scoreTextUI = GetComponent<Text>();
    }

    //Function to update the score text UI
    public void UpdateScoreTextUI()
    {
        string scoreStr = string.Format("{0:0000000}", m_score);
        m_scoreTextUI.text = scoreStr;
    } 
    #endregion

    #region Private && Protected Variables
    private Text m_scoreTextUI;
    private int m_score;
    #endregion
}
