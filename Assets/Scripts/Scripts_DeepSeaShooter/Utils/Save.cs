using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Save : MonoBehaviour
{
    public PlayerControl player;

    public void SaveXp()
    {
        int xpInt = GetComponent<ExperienceScore>().exp;

        Debug.Log("xpINT = " + xpInt);

        //<---------------------Add xp to playerpref for mainScene---------------------->

        if (PlayerPrefs.HasKey("XP"))
        {
            int oldXp = PlayerPrefs.GetInt("XP");

            Debug.Log("OldXp = " + oldXp);

            PlayerPrefs.SetInt("XP", xpInt + oldXp);
        }
        else
        {
            PlayerPrefs.SetInt("XP", xpInt);
        }

        if (PlayerPrefs.HasKey("BLUECHEMS"))
        {
            int oldChems = PlayerPrefs.GetInt("BLUECHEMS");
            PlayerPrefs.SetInt("BLUECHEMS", player.m_numBlueChem + oldChems);
        }
        else
        {
            PlayerPrefs.SetInt("BLUECHEMS", player.m_numBlueChem);
        }

        if (PlayerPrefs.HasKey("PINKCHEMS"))
        {
            int oldChems = PlayerPrefs.GetInt("PINKCHEMS");
            PlayerPrefs.SetInt("PINKCHEMS", player.m_numPinkChem + oldChems);
        }
        else
        {
            PlayerPrefs.SetInt("PINKCHEMS", player.m_numPinkChem);
        }

        if (PlayerPrefs.HasKey("ORANGECHEMS"))
        {
            int oldChems = PlayerPrefs.GetInt("ORANGECHEMS");
            PlayerPrefs.SetInt("ORANGECHEMS", player.m_numOrangeChem + oldChems);
        }
        else
        {
            PlayerPrefs.SetInt("ORANGECHEMS", player.m_numOrangeChem);
        }

        if (PlayerPrefs.HasKey("CERISE"))
        {
            int oldFood = PlayerPrefs.GetInt("CERISE");
            PlayerPrefs.SetInt("CERISE", player.m_numCerise + oldFood);
        }
        else
        {
            PlayerPrefs.SetInt("CERISE", player.m_numCerise);
        }

        Debug.Log("playerPref" + PlayerPrefs.GetInt("XP"));
    }

    public void ResetPlayerPref()
    {
        if (PlayerPrefs.HasKey("XP"))
        {
            PlayerPrefs.SetInt("XP", 0);
        }
        if (PlayerPrefs.HasKey("BLUECHEMS"))
        {
            PlayerPrefs.SetInt("BLUECHEMS", 0);
        }
        if (PlayerPrefs.HasKey("PINKCHEMS"))
        {
            PlayerPrefs.SetInt("PINKCHEMS", 0);
        }
        if (PlayerPrefs.HasKey("ORANGECHEMS"))
        {
            PlayerPrefs.SetInt("ORANGECHEMS", 0);
        }
        if (PlayerPrefs.HasKey("CERISE"))
        {
            PlayerPrefs.SetInt("CERISE", 0);
        }
        Debug.Log("Est passer dans le Init");
    }
}