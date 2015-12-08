using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManagerDSS : MonoBehaviour
{
    #region Public Variables || Properties
    //Reference to our gameobject
    public GameObject m_playerShip;
    public GameObject m_enemySpawner;
    public GameObject m_chemSpawner;
    public GameObject m_foodSpawner;
    public GameObject m_gameOver;
    public GameObject m_scoreUIText;
    public GameObject m_timeCounter;
    public GameObject m_gameTitle;
    public GameObject m_experiencePanel;
    public GameObject m_savedExp;

    public enum e_gameManagerState
    {
        Opening,
        GamePlay,
        GameOver,
        Scoring
    }
    #endregion

    #region Main Methods
    // Use this for initialization
    void Start()
    {
        GMState = e_gameManagerState.Opening;
    }

    //Function to update the gamemanager state
    private void UpdateGameManagerState()
    {
        switch (GMState)
        {
            case e_gameManagerState.Opening:

                //Hide GameOver
                m_gameOver.SetActive(false);

                //Hide ExpPanel
                m_experiencePanel.SetActive(false);

                //Display the game title
                m_gameTitle.SetActive(true);

                break;

            case e_gameManagerState.GamePlay:

                //Reset the score
                m_scoreUIText.GetComponent<GameScore>().score = 0;
                
                //Hide the game title
                m_gameTitle.SetActive(false);

                //Set the player visible (active) and init player's lives
                m_playerShip.GetComponent<PlayerControl>().Init();

                //Start enemy spawner
                m_enemySpawner.GetComponent<EnemySpawner>().ScheduleEnemySpawner();

                //Start chem spawner
                m_chemSpawner.GetComponent<ChemSpawner>().ScheduleChemSpawner();

                //Start food spawner
                m_foodSpawner.GetComponent<FoodSpawner>().ScheduleFoodSpawner();

                //Start the time counter
                m_timeCounter.GetComponent<TimeCounter>().StartTimeCounter();

                break;

            case e_gameManagerState.GameOver:

                //Stop the time counter
                m_timeCounter.GetComponent<TimeCounter>().StopTimeCounter();

                //Stop Enemy spawner
                m_enemySpawner.GetComponent<EnemySpawner>().UnscheduleEnemySpawner();

                //Stop Chem spawner
                m_chemSpawner.GetComponent<ChemSpawner>().UnscheduleChemSpawner();

                //Stop Food spawner
                m_foodSpawner.GetComponent<FoodSpawner>().UnscheduleFoodSpawner();

                //Display GameOver
                m_gameOver.SetActive(true);

                //Change game manager state to scoring state after 5 secondes
                Invoke("ChangeToScoringState", 3f);

                break;

            case e_gameManagerState.Scoring:

                //Display Xp Counter
                m_experiencePanel.SetActive(true);

                m_savedExp.GetComponent<ExperienceScore>().UpdateExpTextUI();
                
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
    //when the user clicks on the button
    public void StartGamePlay()
    {
        GMState = e_gameManagerState.GamePlay;
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

    //Function to quit the mini-game
    public void QuitMiniGame()
    {
        //Quit the mini-game to go to MainScene
        Application.LoadLevel("MainScene");
    }
    #endregion

    #region Private && Protected Variables
    private e_gameManagerState GMState; 
    #endregion
}
