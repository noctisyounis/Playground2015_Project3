using UnityEngine;
using System.Collections;

public class LunchWindows : MonoBehaviour {

    #region PublicVariable

    public bool m_isClose;
    public GameObject m_miniGame;
    public GameObject m_inventory;
    public GameObject m_labo;

    #endregion

    #region MainMethod

    public void OpenMiniGameWindow()
    {
        if (m_isClose == true)
        {
            m_miniGame.SetActive(true);
            m_isClose = false;
        }
        else
        {
            m_miniGame.SetActive(false);
            m_isClose = true;
        }
        
    }

    public void CloseMiniGameWindow()
    {

        m_miniGame.SetActive(false);
    }

    public void OpenInventory()
    {
        if (m_isClose == true)
        {
            m_inventory.SetActive(true);
            m_isClose = false;
        }
        else
        {
            m_inventory.SetActive(false);
            m_isClose = true;
        }
    }

    public void OpenLabo()
    {
        m_labo.SetActive(true);
    }

    #endregion

    #region PrivateAndProtected

    #endregion
}
