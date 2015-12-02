using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Save : MonoBehaviour
{
    public Text m_xpUIText;


    public void SaveXp()
    {
        //int result = GetComponent<GameManager>().ConvertStringToInt(m_xpUIText.ToString());

        //PlayerPrefs.SetInt("SavedXp", result);

    }

    void OnGUI()
    {
        GUILayout.Button("content: " + m_xpUIText);
    }
}