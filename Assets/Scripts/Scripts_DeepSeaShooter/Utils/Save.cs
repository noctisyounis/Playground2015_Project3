using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Save : MonoBehaviour
{
    public PlayerControl player;

    public void SaveXp()
    {
        int xpInt = GetComponent<ExperienceScore>().exp;

        //<---------------------Add xp to playerpref for mainScene---------------------->

        if (PlayerPrefs.HasKey("XP"))
        {
            int oldXp = PlayerPrefs.GetInt("XP");

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
    }


}