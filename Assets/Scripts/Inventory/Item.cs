using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Item
{
    #region PublicVariable
    public e_itemType m_typeItem;
    public string m_itemName;
    public int m_itemID;
    public string m_itemDescription;
    public Texture2D m_itemIcon;
    public e_element m_elementType;

    public int Intensity
    {
        get
        {
            return m_intensity;
        }
    }

    public int Percentage
    {
        get
        {
            return Toolbox.RoundValueToInt(m_percentage * m_intensity);
        }
    }

    #endregion

    #region MainMethods
    public Item(string name, int id, string description, int intensity, e_itemType itemType, e_element elementType)
    {
        m_itemName = name;
        m_itemID = id;
        m_itemDescription = description;
        m_intensity = intensity;
        m_typeItem = itemType;
        m_itemIcon = AssignResources(itemType);
        m_elementType = elementType;
    }

    public Item()
    {
    }

    private Texture2D AssignResources(e_itemType itemType)
    {
        Texture2D textureRef = null;

        switch (itemType)
        {
            case e_itemType.INVALID:
                textureRef = Resources.Load<Texture2D>(m_dictionaryResources[(int)e_itemType.INVALID]);
                break;

            case e_itemType.POTION:
                textureRef = Resources.Load<Texture2D>(m_dictionaryResources[(int)e_itemType.POTION]);
                break;

            case e_itemType.FOOD:
                textureRef = Resources.Load<Texture2D>(m_dictionaryResources[(int)e_itemType.FOOD]);
                break;

            default:
                break;
        }

        return textureRef;
    }
    #endregion

    #region Utils

    #endregion

    #region PrivateProtectedVariable
    private float m_percentage;
    private int m_intensity;
    private Dictionary<int, string> m_dictionaryResources = new Dictionary<int, string>()
    {
        {0,  "IconsItem/None"},
        {1,  "IconsItem/Potion"},
        {2,  "IconsItem/Food"},
    };
    #endregion
}
