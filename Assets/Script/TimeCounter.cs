﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeCounter : MonoBehaviour
{
    #region Public Variables || Properties

    #endregion

    #region Main Methods
    // Use this for initialization
    void Start()
    {
        m_startCounter = false;

        //Get the Text UI compronent from this gameObject
        m_timeUI = GetComponent<Text>();
    }

    //Function to start the time counter
    public void StartTimeCounter()
    {
        m_startTime = Time.time;
        m_startCounter = true;
    }

    //Function to stop the time counter
    public void StopTimeCounter()
    {
        m_startCounter = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_startCounter)
        {
            //Compute the ellapsed time
            m_ellapsedTime = Time.time - m_startTime;

            m_minutes = (int)m_ellapsedTime / 60; //Get the minutes
            m_seconds = (int)m_ellapsedTime % 60; //Get the seconds

            //Update the time counter UI Text
            m_timeUI.text = string.Format("{0:00}:{1:00}", m_minutes, m_seconds);
        }
    }
    #endregion

    #region Private && Protected Variables
    private Text m_timeUI; //Reference to the time counter UI Text
    private float m_startTime; //The time when the user clicks on play
    private float m_ellapsedTime; //The ellapsed time after the user clicks on play
    private bool m_startCounter; //The flag to start the counter
    private int m_minutes;
    private int m_seconds;
    #endregion
}
