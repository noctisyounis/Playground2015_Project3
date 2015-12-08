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
            SpriteRenderer playerColor = other.GetComponent<SpriteRenderer>();

            if (tag == "Pacdot")
            {
                Instantiate(Resources.Load(@"Pacman/GetDot"));
                player.m_xp += m_xpPacdot;
            }
            else if (tag == "Cerise")
            {
                Instantiate(Resources.Load(@"Pacman/GetFood"));
                player.m_xp += m_xpBonus;
                player.m_numbCerise += 1;
                player.m_isInvincible = true;
                player.m_time = player.m_maxInvinsible;
                playerColor.color = new Color(1, 0, 0, 0.9f);
            }
            else if (tag == "Chem1")
            {
                Instantiate(Resources.Load(@"Pacman/GetChems"));
                player.m_xp += m_xpBonus;
                player.m_numbChem1 += 1;
                player.m_isInvincible = true;
                player.m_time = player.m_maxInvinsible;
                playerColor.color = new Color(1, 0, 0, 0.9f);
            }
            else if (tag == "Chem2")
            {
                Instantiate(Resources.Load(@"Pacman/GetChems"));
                player.m_xp += m_xpBonus;
                player.m_numbChem2 += 1;
                player.m_isInvincible = true;
                player.m_time = player.m_maxInvinsible;
                playerColor.color = new Color(1, 0, 0, 0.9f);
            }
            else if (tag == "Chem3")
            {
                Instantiate(Resources.Load(@"Pacman/GetChems"));
                player.m_xp += m_xpBonus;
                player.m_numbChem3 += 1;
                player.m_isInvincible = true;
                player.m_time = player.m_maxInvinsible;
                playerColor.color = new Color(1, 0, 0, 0.9f);
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
