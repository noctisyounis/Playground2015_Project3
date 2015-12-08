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

    public void Start()
    {
        OpenInventory();
        OpenMiniGameWindow();
        OpenLabo();
    }

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

        Debug.Log("Number of the childrens : " + transform.childCount);

        /* foreach (Transform children in transform)
         {
             children.gameObject.SetActive(true);
         }
         */

        m_labo.SetActiveRecursively(true);
        if (m_isClose == true)
        {
            m_labo.SetActive(true);
            m_isClose = false;
        }
        else
        {
            m_labo.SetActive(false);
            m_isClose = true;
        }
    }

    public void ActivateAllChildren( Transform elem )
    {
        if(elem.childCount > 0)
        {
            foreach ( Transform child in elem )
            {
                child.gameObject.SetActive(true);
                ActivateAllChildren(child);
            }
        }
    }

    #endregion

    #region PrivateAndProtected

    #endregion
}
