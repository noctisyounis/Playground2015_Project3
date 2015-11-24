using UnityEngine;
using System.Collections;

public class SlotGame : MonoBehaviour
{
    public string m_levelToLoad;
    
    public void OnClick()
    {
        Application.LoadLevel(m_levelToLoad);
    }
}
