﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManagerALO : MonoBehaviour
{
    #region PublicVariables

    public GameObject m_playButton;
    public GameObject m_controlButton;
    public GameObject m_backButton;
    public GameObject m_hero;
    public GameObject m_obstacle;
    public GameObject m_gameOver;
    public GameObject m_opening;
    public Text m_scoreUIText;
    //public GameObject m_timeCounter;
    public GameObject m_titleGame;
    public GameObject m_experiencePanel;
    //public GameObject m_savedExp;

    public enum e_gameManagerState
    {
        Opening,
        Gameplay,
        GameOver,
        Scoring
    }
    #endregion

    #region MainMethods
    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.HasKey("life"))
        {
            if (PlayerPrefs.GetInt("life") <= 0)
            {
                Debug.Log("startbreak");
                //Debug.Break();
                GMState = e_gameManagerState.Opening;
            }
            else
            {
                m_opening.SetActive(false);
                GMState = e_gameManagerState.Gameplay;
                UpdateGameManagerState();
            }
        }
    }

    void OnGUI()
    {
        GUILayout.Button("exist" + PlayerPrefs.HasKey("life") + "\n value" + PlayerPrefs.GetInt("life"));
    }

    void UpdateGameManagerState()
    {
        switch (GMState)
        {
            case e_gameManagerState.Opening:

                //Hide GameOver
                m_gameOver.SetActive(false);

                //Hide ExpPanel
                m_experiencePanel.SetActive(false);

                //Hide Cloud && Flask
                m_obstacle.SetActive(false);

                //Display GameTitle
                m_titleGame.SetActive(true);

                //Set PlayButton to true
                m_playButton.SetActive(true);

                break;

            case e_gameManagerState.Gameplay:

                //Reset the score

                //Hide the play button on game play state
                m_playButton.SetActive(false);
                m_backButton.SetActive(false);
                m_controlButton.SetActive(false);

                //Hide the game title
                m_titleGame.SetActive(false);

                //Display Cloud && Flask
                m_obstacle.SetActive(true);

                //Set the player visible (active) and init player's lives
                m_hero.SetActive(true);
                
                //Start the time counter

                break;

            case e_gameManagerState.GameOver:

                //Stop the time counter

                //Hide Cloud && Flask
                m_obstacle.SetActive(false);

                //Display GameOver
                m_gameOver.SetActive(true);
                //Debug.Log("gameoverstate");
                //Debug.Break();
                //Change game manager state to scoring state after 5 secondes
                Invoke("ChangeToScoringState", 3f);

                break;

            case e_gameManagerState.Scoring:

                //Display Xp Counter
                m_experiencePanel.SetActive(true);
                Debug.Break();
                Debug.Log("scoringstate");
                //Compute xP

                break;

            default:
                break;
        }

    }

    //Function to set the game manager state
    public void SetGameManagerState(e_gameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }

    //Our play button will call this function
    //When the user click on the button
    public void StartGamePlay()
    {
        GMState = e_gameManagerState.Gameplay;
        UpdateGameManagerState();
    }

    //Function to change game manager state to opening state
    public void ChangeToOpeningState()
    {
        SetGameManagerState(e_gameManagerState.Opening);
    }

    //Function to change game manager state to scoring state
    public void ChangeToScoringState()
    {
        SetGameManagerState(e_gameManagerState.Scoring);
    }

    //Function to quit the minigame
    public void QuitMiniGame()
    {
        //Quit the mini game to go to main scene
        Application.LoadLevel("MainScene");
    }
    #endregion

    #region ProtectedAndPrivate
    public e_gameManagerState GMState;
    #endregion


}