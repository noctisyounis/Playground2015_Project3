using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Save : MonoBehaviour
{
    public void SaveXp()
    {
        int xpInt = GetComponent<ExperienceScore>().exp;

        Debug.Log("xpINT = " + xpInt);

        if (PlayerPrefs.HasKey("SavedXp"))
        {
            int oldXp = PlayerPrefs.GetInt("SavedXp");

            Debug.Log("OldXp = " + oldXp);

            PlayerPrefs.SetInt("SavedXp", xpInt + oldXp);
        }
        else
        {
            PlayerPrefs.SetInt("SavedXp", xpInt);
        }

        Debug.Log("playerPref" + PlayerPrefs.GetInt("SavedXp"));
    }


}