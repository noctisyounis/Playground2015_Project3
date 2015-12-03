using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Item
{
    #region PublicVariable
    public string Name
    {
        get
        {
            return m_name;
        }

        set
        {
            m_name = value;
        }
    }

    public int Id
    {
        get
        {
            return m_id;
        }

        set
        {
            m_id = value;
        }
    }

    public string Description
    {
        get
        {
            return m_description;
        }

        set
        {
            m_description = value;
        }
    }

    public int Intensity
    {
        get
        {
            return m_intensity;
        }

        set
        {
            m_intensity = value;
        }
    }

    public e_itemType TypeItem
    {
        get
        {
            return m_typeItem;
        }

        set
        {
            m_typeItem = value;
        }
    }

    public e_element ElementTarget
    {
        get
        {
            return m_elementTarget;
        }

        set
        {
            m_elementTarget = value;
        }
    }

    public Dictionary<int, string> DictionaryResources
    {
        get
        {
            return m_dictionaryResources;
        }

        set
        {
            m_dictionaryResources = value;
        }
    }

    public bool IsStackable
    {
        get
        {
            return m_isStackable;
        }

        set
        {
            m_isStackable = value;
        }
    }

    public e_itemRarity LevelRarity
    {
        get
        {
            return m_levelRarity;
        }

        set
        {
            m_levelRarity = value;
        }
    }

    public Sprite Sprite
    {
        get
        {
            return m_sprite;
        }

        set
        {
            m_sprite = value;
        }
    }
    #endregion

    #region MainMethods

    public Item(int id, string name, string description, 
        int intensity, e_itemType type, e_element eltTarget)
    {
        Id = id;
        Name = name;
        Description = description;
        Intensity = intensity;
        TypeItem = type;
        ElementTarget = eltTarget;

        LevelRarity = e_itemRarity.Normal;
        IsStackable = false;

        Sprite = AssignResources(type);
    }

    public Item(int id, 
                string name, 
                string description, 
                int intensity, 
                e_itemType type, 
                e_element eltTarget, 
                e_itemRarity rarity, bool isStackable)
        : this(id, name, description, intensity, type, eltTarget)
    {
        LevelRarity = rarity;
        IsStackable = isStackable;
    }

    public Item()
    {
        Id = -1;
    }
    #endregion

    #region Utils
    public static Sprite AssignResources(e_itemType itemType)
    {
        Sprite textureRef = null;

        switch (itemType)
        {
            case e_itemType.NONE:
                textureRef = Resources.Load<Sprite>(m_dictionaryResources[(int)e_itemType.NONE]);
                break;

            case e_itemType.POTION:
                textureRef = Resources.Load<Sprite>(m_dictionaryResources[(int)e_itemType.POTION]);
                break;

            case e_itemType.FOOD:
                textureRef = Resources.Load<Sprite>(m_dictionaryResources[(int)e_itemType.FOOD]);

                break;
            case e_itemType.POTION_EVOLVE:
                textureRef = Resources.Load<Sprite>(m_dictionaryResources[(int)e_itemType.POTION_EVOLVE]);
                break;

            case e_itemType.POTION_POISON:
                textureRef = Resources.Load<Sprite>(m_dictionaryResources[(int)e_itemType.POTION_POISON]);
                break;

            case e_itemType.BISCUIT:
                textureRef = Resources.Load<Sprite>(m_dictionaryResources[(int)e_itemType.BISCUIT]);
                break;

            default:
                break;
        }

        return textureRef;
    }
    public static Sprite AssignResources(string pathSprite)
    {
        Sprite spriteTmp = null;

        spriteTmp = Resources.Load<Sprite>(pathSprite);

        return spriteTmp;
    }
    #endregion

    #region PrivateProtectedVariable
    private string m_name;
    private int m_id;
    private Sprite m_sprite;
    private string m_description;
    private int m_intensity;
    private e_itemType m_typeItem;
    private e_element m_elementTarget;
    private bool m_isStackable;
    private e_itemRarity m_levelRarity;
    private static Dictionary<int, string> m_dictionaryResources = new Dictionary<int, string>()
    {
        {0,  "Resources_Inventories/Items/None"},
        {1,  "Resources_Inventories/Items/potion-base"},
        {2,  "Resources_Inventories/Items/food-base"},
        {3,  "Resources_Inventories/Items/potion-evolve"},
        {4,  "Resources_Inventories/Items/potion-poison"},
        {5,  "Resources_Inventories/Items/biscuit-base"}
    };
    #endregion
}
