using UnityEngine;
using System.Collections;

public class HUDManager : MonoBehaviour
{

    public  SlotManager m_slotManager;
    public  SlotManager m_slotGame;

	// Use this for initialization
	void Start ()
    {
        m_slotManager.CreateSlots();
        m_slotGame.CreateSlots();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
