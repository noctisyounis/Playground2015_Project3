using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class SlotGame : MonoBehaviour
{
    public string m_levelToLoad;
    public string m_GameName;
    
    public void Awake()
    {
        Text text = GetComponentInChildren<Text>();
        text.text = m_GameName;

    }

    public void OnClick()
    {
        Application.LoadLevel(m_levelToLoad);
    }


}
