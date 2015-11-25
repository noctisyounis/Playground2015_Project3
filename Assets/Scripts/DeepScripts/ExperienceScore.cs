using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ExperienceScore : MonoBehaviour
{
    private Text m_expScoring;
    private int m_score;

    public int score
    {
        get
        {
            return this.m_score;
        }

        set
        {
            this.m_score = value;
            UpdateExpTextUI();
        }
    }

    // Use this for initialization
    void Start()
    {
        m_expScoring = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Function to update exp
    public void UpdateExpTextUI()
    {
        //Compute Scoring to Experience
        score = GetComponent<GameScore>().score;
        int exp = score / 100;

        string expScoring = string.Format("{0:0000000}", exp);
        m_expScoring.text = expScoring;
    }
}
