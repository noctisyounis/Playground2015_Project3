using UnityEngine;
using System.Collections;

public class PlayerPrefDemo : MonoBehaviour
{
    public int life;
    void OnGUI()
    {
        if (GUILayout.Button("setPlayerPref"))
        {
            life += 10;
            PlayerPrefs.SetInt("life", life);
        }

        if (GUILayout.Button("GetPlayerPref"))
        {
            PlayerPrefs.HasKey("life");
            Debug.Log(PlayerPrefs.GetInt("life"));
        }
    }
	
}
