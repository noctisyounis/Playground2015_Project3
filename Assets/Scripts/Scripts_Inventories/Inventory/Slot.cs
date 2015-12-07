using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System;

public class Slot : MonoBehaviour, IDropHandler
{
    public int m_id;
    public Inventory m_inventory;
  

    public void OnDrop(PointerEventData eventData)
    {
        ItemData itemDropped = eventData.pointerDrag.GetComponent<ItemData>();

        if (m_inventory.m_items[m_id].Id == -1)
        {
            m_inventory.m_items[itemDropped.m_slot] = new Item();
            m_inventory.m_items[m_id] = itemDropped.m_item;
            itemDropped.m_slot = m_id;
        }
        else if (itemDropped.m_slot != m_id)
        {
            Transform transformItem = this.transform.GetChild(0);

            if (transformItem)
            {
                transformItem.GetComponent<ItemData>().m_slot = itemDropped.m_slot;
                transformItem.transform.SetParent(m_inventory.m_slots[itemDropped.m_slot].transform);
                transformItem.transform.position = m_inventory.m_slots[itemDropped.m_slot].transform.position;

                itemDropped.m_slot = m_id;
                itemDropped.transform.SetParent(this.transform);
                itemDropped.transform.position = this.transform.position;

                m_inventory.m_items[itemDropped.m_slot] = transformItem.GetComponent<ItemData>().m_item;
                m_inventory.m_items[m_id] = itemDropped.m_item;
            }
            else
            {
                Toolbox.Break("item is null !!!!");
            }

        }

    }
    // Use this for initialization
    void Start()
    {
        m_inventory = GameObject.Find(m_TypeInventory[0]).GetComponent<Inventory>();
    }

    private enum TypeInv
    {
        Inventory,
        InventoryLab
    }

    private Dictionary<int, string> m_TypeInventory = new Dictionary<int, string>()
    {
        {0, "InventoryFridge"},
        {1, "InventoryLab"}
    };
}
