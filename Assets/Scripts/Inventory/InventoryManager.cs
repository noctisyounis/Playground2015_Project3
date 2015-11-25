using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class InventoryManager : MonoBehaviour
{

    #region PublicVariable
    public List<Item> m_listItems = new List<Item>();
    #endregion

    #region MainMethods
    void Start()
    {
        // Base of Model's item.
        m_listItems.Add(new Item("Potion de pissenlit boullie", 0, "Permet au personnage de récupérer 1 points de vie", 8, e_itemType.POTION, e_element.Normal));
        m_listItems.Add(new Item("Potion d'evolution", 1, "Le résultat de l'évolution du personnage est incertain.", 0, e_itemType.POTION, e_element.Normal));
        m_listItems.Add(new Item("Pain de mie", 2, "Permet au personnage de récupérer 1 points de vie", 10, e_itemType.FOOD, e_element.Normal));
        m_listItems.Add(new Item("Gateau de riz", 3, "Permet au personnage de récupérer 1 points de vie", 10, e_itemType.FOOD, e_element.Normal));
    }
    #endregion

    #region Utils

    #endregion

    #region PrivateProtectedVariable
    #endregion
}
