using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExperienceScore : MonoBehaviour
{
    #region Public Variables || Properties
    public GameObject m_scoreUIText;
    public int m_xpDivisor;
    public int exp
    {
        get
        {
            return this.m_exp;
        }
        set
        {
            this.m_exp = value;
        }
    }
    #endregion

    #region Main Methods
    //Function to update exp text UI
    public void UpdateExpTextUI()
    {
        //Get TextUI componement of this gameobject
        m_expScoring = GetComponent<Text>();

        //Compute Scoring to Experience
        int score = m_scoreUIText.GetComponent<GameScore>().score;

        m_exp = score / m_xpDivisor;

        string expStr = string.Format("{0:0000000}", m_exp);

        m_expScoring.text = expStr;

        //Save the current Xp
        GetComponent<Save>().SaveXp();
    }
    #endregion
    void OnGUI()
    {
        GUILayout.Button("xp: " + m_exp);
    }

    #region Private && Protected Variables
    private Text m_expScoring;
    private int m_exp;
    #endregion
}
