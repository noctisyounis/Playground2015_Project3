using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

    public GameObject m_subPanel;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if (Input.GetButton("Start"))      	
	}

    public void OpenPanel()
    {
        m_subPanel.SetActive(true);
    }

    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        Application.LoadLevel("MainScene");
    }

    public void Continue()
    {
        Application.LoadLevel("MainScene");
    }
}
