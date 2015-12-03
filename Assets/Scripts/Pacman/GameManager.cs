using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    #region Public Variable

    #endregion

    #region Main Methodes
    void Start()
    {
        PlayerPrefs.SetInt("XP", 0);
        PlayerPrefs.SetInt("CERISE", 0);
        PlayerPrefs.SetInt("CHEM1", 0);
        PlayerPrefs.SetInt("CHEM2", 0);
        PlayerPrefs.SetInt("CHEM3", 0);

        if (PlayerPrefs.HasKey("LEVEL"))
        {
            m_level = PlayerPrefs.GetInt("LEVEL");
        }
        else
        {
            m_level = 1;
        }
    }
    #endregion

    #region Utils
    public void onClickPlayTryNext()
    {
        switch(m_level)
        {
            case 1:
                PlayerPrefs.SetInt("LEVEL", 1);
                Application.LoadLevel("Level1");
                break;

            case 2:
                PlayerPrefs.SetInt("LEVEL", 2);
                Application.LoadLevel("Level2");
                break;

            case 3:
                PlayerPrefs.SetInt("LEVEL", 3);
                Application.LoadLevel("Level3");
                break;

            case 4:
                PlayerPrefs.SetInt("LEVEL", 4);
                Application.LoadLevel("Level4");
                break;
        }
    }

    public void onClickTuto()
    {
        Application.LoadLevel("Tutorial");
    }

    public void onClickQuit()
    {
        PlayerPrefs.Save();
        Application.LoadLevel("MainScene");
    }

    public void onClickRestart()
    {
        PlayerPrefs.SetInt("LEVEL", 1);
        Application.LoadLevel("Level1");
    }

    public void onClickReturnMenu()
    {
        Application.LoadLevel("MainMenu");
    }
    #endregion

    #region Private & Protected Variables
    int m_level;
    #endregion
}
