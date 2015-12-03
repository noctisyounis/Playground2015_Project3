using UnityEngine;
using System.Collections;

public class ItemPickup : MonoBehaviour {

    #region Public Variable

    #endregion

    #region Main Methodes
    void Start()
    {
        m_xpPacdot = 1;
        m_xpBonus = 5;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerBehaviour player = other.GetComponentInParent<PlayerBehaviour>();

            if (tag == "Pacdot")
            {
                Instantiate(Resources.Load("GetDot"));
                player.m_xp += m_xpPacdot;
            }
            else if (tag == "Cerise")
            {
                Instantiate(Resources.Load("GetFood"));
                player.m_xp += m_xpBonus;
                player.m_numbCerise += 1;
                player.m_isInvincible = true;
                player.m_time = player.m_maxInvinsible;
            }
            else if (tag == "Chem1")
            {
                Instantiate(Resources.Load("GetChems"));
                player.m_xp += m_xpBonus;
                player.m_numbChem1 += 1;
                player.m_isInvincible = true;
                player.m_time = player.m_maxInvinsible;
            }
            else if (tag == "Chem2")
            {
                Instantiate(Resources.Load("GetChems"));
                player.m_xp += m_xpBonus;
                player.m_numbChem2 += 1;
                player.m_isInvincible = true;
                player.m_time = player.m_maxInvinsible;
            }
            else if (tag == "Chem3")
            {
                Instantiate(Resources.Load("GetChems"));
                player.m_xp += m_xpBonus;
                player.m_numbChem3 += 1;
                player.m_isInvincible = true;
                player.m_time = player.m_maxInvinsible;
            }

            Destroy(gameObject);
        }
    }
    #endregion

    #region Utils

    #endregion

    #region Private & Protected Variables
    int m_xpPacdot;
    int m_xpBonus;
    #endregion
}
