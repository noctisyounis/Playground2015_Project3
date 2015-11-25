using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Inventory : MonoBehaviour
{

    #region PublicVariable
    public List<Item> m_inventory = new List<Item>();
    public List<Item> m_slots = new List<Item>();
    public int m_slotX, m_slotY;
    public GUISkin m_skin;
    public GameObject m_avatar;
    #endregion

    #region MainMethods

    void Start()
    {
        m_avatar = GameObject.FindGameObjectWithTag("Avatar");
        m_inventorySize = new Rect(m_slotX, m_slotY, 200, 200);
        m_slotSize = (m_slotX * m_slotY);

        for (int i = 0; i < m_slotSize; i++)
        {
            m_slots.Add(new Item());
            m_inventory.Add(new Item());
        }

        GameObject inventoryManagerTmp = GameObject.FindGameObjectWithTag("InventoryManager");
        m_inventoryManager = inventoryManagerTmp.GetComponent<InventoryManager>();

        // Add the item, it's the inventoryManager what attributes the model of item.
        AddItem(0);
        AddItem(1);
        AddItem(2);
        AddItem(3);
    }

    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            m_showInventory = !m_showInventory;
        }
    }

    void OnGUI()
    {
        GUI.skin = m_skin;
        m_tooltip = "";

        if (m_showInventory)
        {
            DrawInventory();

            if (m_showTooltip)
            {
                float rectPositionX = Event.current.mousePosition.x;
                float rectPositionY = Event.current.mousePosition.y;


                Rect rectBox = new Rect(rectPositionX + 15f, rectPositionY, 200, 200);

                GUI.Box(rectBox, m_tooltip, m_skin.GetStyle("Tooltip"));
            }

            if (m_draggingItem)
            {
                float rectPositionX = Event.current.mousePosition.x;
                float rectPositionY = Event.current.mousePosition.y;

                Rect recDrawText = new Rect(rectPositionX, rectPositionY, 50, 50);

                GUI.DrawTexture(recDrawText, m_draggedItem.m_itemIcon);
            }

        }
    }

    private void DrawInventory()
    {
        Event currentEvent = Event.current;
        int i = 0;

        Rect currentRect = new Rect(m_inventorySize.x, m_inventorySize.y, m_slotSize, m_slotSize);

        for (int y = 0; y < m_slotX; y++)
        {
            for (int x = 0; x < m_slotY; x++)
            {
                m_inventorySize.width = (m_slotSize + m_slotPadding) * m_slotY + m_slotPadding;
                m_inventorySize.height = (m_slotSize + m_slotPadding) * m_slotX + m_slotPadding;

                currentRect.x = m_slotPadding + m_inventorySize.x + x * (m_slotSize + m_slotPadding);
                currentRect.y = m_slotPadding + m_inventorySize.y + y * (m_slotSize + m_slotPadding);

                m_slots[i] = m_inventory[i];
                Item item = m_slots[i];

                GUI.Box(currentRect, "", m_skin.GetStyle("Slot"));

                if (m_slots[i].m_itemName != null)
                {
                    GUI.DrawTexture(currentRect, m_inventory[i].m_itemIcon);

                    if (currentRect.Contains(Event.current.mousePosition))
                    {
                        if (currentEvent.isMouse
                            && currentEvent.type == EventType.MouseDrag
                            && currentEvent.button == 0
                            && !m_draggingItem)
                        {
                            m_draggingItem = true;
                            m_draggedItem = item;
                            m_inventory[i] = new Item();
                            m_draggedIndex = i;
                        }

                        if (currentEvent.isMouse
                            && currentEvent.type == EventType.MouseUp
                            && m_draggingItem)
                        {
                            print("Should've placed " + m_draggedItem.m_itemName + " at " + i);
                            m_inventory[m_draggedIndex] = item;
                            m_inventory[i] = m_draggedItem;
                            m_draggingItem = false;
                            m_draggedItem = null;
                        }

                        if (!m_draggingItem)
                        {
                            m_tooltip = GenerateTooltip(m_inventory[i]);
                            m_showTooltip = true;
                        }

                        if (currentEvent.isMouse
                            && currentEvent.type == EventType.MouseDown
                            && currentEvent.button == 1)
                        {
                            //print("Clicked " + i);

                            switch (item.m_typeItem)
                            {
                                case e_itemType.INVALID:
                                    print("never used");
                                    break;

                                case e_itemType.POTION:
                                    print("use potion");
                                    break;

                                case e_itemType.FOOD:
                                    print("use food");
                                    break;

                                default:
                                    break;
                            }
                        }
                    }

                    if (m_tooltip == "")
                    {
                        m_showTooltip = false;
                    }

                }
                // If the slot where the mouse is doesn't contain an item
                else
                {
                    if (currentEvent.isMouse && currentEvent.type == EventType.MouseUp && m_draggingItem)
                    {
                        if (currentRect.Contains(currentEvent.mousePosition))
                        {
                            print("Should've placed " + m_draggedItem.m_itemName + " at " + i);
                            m_slots[m_draggedIndex] = item;
                            m_inventory[i] = m_draggedItem;
                            m_draggingItem = false;
                            m_draggedItem = null;
                        }
                    }
                }

                i++;
            }
        }

    }

    private string CreateTooltip(Item item)
    {
        string nameTmp = null;
        string message = "";

        if (item != null && !string.IsNullOrEmpty(item.m_itemName) && item.Intensity != 0)
        {
            message += "<color=#ffffff>" + nameTmp + "</color>\n";
            message += "<color=#90C3D4>" + item.m_itemDescription + ".</color>";
            message += "\nEfficacité : <color=#006600> + " + item.Intensity + " Points. </Color>";
        }
        else if (item.Intensity == 0)
        {
            message += "<color=#ffffff>" + nameTmp + "</color>\n";
            message += "<color=#90C3D4>" + item.m_itemDescription + ".</color>";
        }

        return message;

    }

    private bool InventoryContains(int id)
    {
        bool isContained = false;

        for (int i = 0; i < m_inventory.Count; i++)
        {
            isContained = (m_inventory[id].m_itemID == id);

            if (isContained)
            {
                break;
            }
        }

        return isContained;
    }

    public void RemoveItem(int id)
    {
        for (int i = 0; i < m_inventory.Count; i++)
        {
            if (m_inventory[i].m_itemID == id)
            {
                Item itemSearch = m_inventory[i];
                m_inventory.Remove(itemSearch);
            }
        }
    }

    // TODO ed : maybe a Problem of break here;
    public void AddItem(int itemId)
    {
        Debug.Log("itemId = " + itemId);
        Debug.Log("Taille inventory : " + m_inventory.Count);

        for (int i = 0; i < m_inventory.Count; i++)
        {
            if (m_inventory[i].m_itemName == null)
            {
                for (int j = 0; j < m_inventoryManager.m_listItems.Count; j++)
                {
                    if (m_inventoryManager.m_listItems[j].m_itemID == itemId)
                    {
                        m_inventory[i] = m_inventoryManager.m_listItems[j];
                    }
                }

                break;
            }
        }
    }

    private void DrawTooltip()
    {
        float dynamicsSize = m_skin.box.CalcHeight(new GUIContent(m_tooltip), 200);
        GUI.Box(new Rect(Event.current.mousePosition.x + 10, Event.current.mousePosition.y, 200, dynamicsSize), m_tooltip, m_skin.GetStyle("Tooltip"));
    }

    public string GenerateTooltip(Item item)
    {
        m_tooltip = "";
        m_tooltip += "<color=#ffffff>" + item.m_itemName + "</color>\n" +
                    "<color=#90C3D4>" + item.m_itemDescription + ".</color>" +
                    "\nEfficacité : <color=#006600> + " + item.Intensity + " Points. </Color>";
        return m_tooltip;
    }

    private void UseConsummable(Item item, int slot, bool isDeleted)
    {
        m_avatar.GetComponent<Creature>().Interact(e_action.Eat, item);
    }

    #endregion

    #region Utils

    #endregion

    #region PrivateProtectedVariable
    private InventoryManager m_inventoryManager;
    private bool m_showInventory;
    private bool m_showTooltip;
    private string m_tooltip;
    private bool m_draggingItem;
    private Item m_draggedItem;
    private int m_prevIndex;
    private Rect m_inventorySize;
    private int m_slotSize;
    private int m_slotPadding;
    private int m_draggedIndex;
    #endregion
}
