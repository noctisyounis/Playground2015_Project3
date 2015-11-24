using UnityEngine;
using System.Collections;

public class HUDManager : MonoBehaviour {

    public static SlotManager m_slotManager;

	// Use this for initialization
	void Start ()
    {
        m_slotManager.CreateSlots();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
