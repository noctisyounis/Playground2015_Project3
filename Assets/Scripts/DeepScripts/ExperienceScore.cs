using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExperienceScore : MonoBehaviour
{
    #region Public Variables || Properties
    /*public int experience
    {
        get
        {
            return this.m_experience;
        }

        set
        {
            this.m_experience = value;
            UpdateExpTextUI();
        }
    }*/
    #endregion

    #region Main Methods
    // Use this for initialization
    void Start()
    {
        //Get TextUI componement of this gameobject
        m_expScoring = GetComponent<Text>();
        m_scoreUIText = GameObject.FindGameObjectWithTag("ScoreTextTag");

        UpdateExpTextUI();

    }

//Function to update exp text UI
public void UpdateExpTextUI()
    {
        //Compute Scoring to Experience
        int score = m_scoreUIText.GetComponent<GameScore>().score;
        int exp = score / 100;

        string expStr = string.Format("{0:0000000}", exp);
        m_expScoring.text = expStr;

        Debug.Log("Exp : " + expStr);
    }
    #endregion

    #region Private && Protected Variables
    private Text m_expScoring;
    private GameObject m_scoreUIText;
    //private int m_experience; 
    #endregion
}
