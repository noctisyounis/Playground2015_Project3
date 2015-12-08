using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class InventoryLab : MonoBehaviour {

    #region PublicVariable
    public int m_slotAmount;
    public List<Item> m_items;
    public List<GameObject> m_slots;
    public GameObject m_inventorySlot;
    public GameObject m_inventoryItem;
    #endregion

    #region MainMethods

    void Start()
    {
        m_slotAmount = 18;

        m_itemManager = GetComponent<ItemManager>();
        m_items = new List<Item>();
        m_slots = new List<GameObject>();


        m_inventoryPanel = GameObject.Find("InventoryLabPanel");
        m_inventoryPanel.SetActive(false);
        m_slotPanel = m_inventoryPanel.transform.FindChild("BaseSlotPanel").gameObject;

        InitialiseInventary(m_slotAmount);

        AddItem(0);
        AddItem(1);
        AddItem(1);
        AddItem(2);

    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Labo"))
        {
            m_showInventory = !m_showInventory;
        }
    }

    void OnGUI()
    {
        if (m_showInventory)
        {
            m_inventoryPanel.SetActive(true);
        }
        else if (m_showInventory == false)
        {
            m_inventoryPanel.SetActive(false);
        }
    }

    public void AddItem(int id)
    {
        Item itemToAdded = m_itemManager.SearchById(id);

        bool isCheckedInventory = CheckedInInventory(itemToAdded);

        if (itemToAdded.IsStackable && isCheckedInventory)
        {
            for (int i = 0; i < m_items.Count; i++)
            {
                if (m_items[i].Id == id)
                {
                    /*
                        If the item is same in the slot, 
                        the value of amount is incremantable
                    */
                    ItemData data = m_slots[i].transform.GetChild(0).GetComponent<ItemData>();

                    if (string.IsNullOrEmpty(data.transform.GetChild(0).GetComponent<Text>().text))
                    {
                        data.transform.GetChild(0).GetComponent<Text>().text = "1";
                        data.m_amount = int.Parse(data.transform.GetChild(0).GetComponent<Text>().text);
                    }

                    data.m_amount++;
                    data.transform.GetChild(0).GetComponent<Text>().text = data.m_amount.ToString();

                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < m_items.Count; i++)
            {
                /*
                    this condition serve at do the different 
                    into the empty item and the not empty item
                */
                if (m_items[i].Id == -1)
                {
                    m_items[i] = itemToAdded;
                    GameObject inventoryItemTmp = m_inventoryItem;
                    GameObject itemToObj = Instantiate(inventoryItemTmp);
                    itemToObj.GetComponent<ItemData>().m_item = itemToAdded;
                    itemToObj.GetComponent<ItemData>().m_slot = i;

                    itemToObj.transform.position = Vector2.zero;
                    itemToObj.GetComponent<Image>().sprite = itemToAdded.Sprite;
                    itemToObj.transform.SetParent(m_slots[i].transform, false);
                    itemToObj.name = itemToAdded.Name;

                    break;
                }
            }
        }
    }

    /// <summary>
    /// Check if the item is in the list of item (m_items)
    /// </summary>
    /// <param name="itemToSearched">this item what is checked or not</param>
    /// <returns>Return true if check or false if not checked</returns>
    private bool CheckedInInventory(Item itemToSearched)
    {
        bool isChecked = false;

        for (int i = 0; i < m_items.Count; i++)
        {

            if (itemToSearched.Id == m_items[i].Id)
            {
                isChecked = true;
            }
        }

        return isChecked;
    }

    #endregion

    #region Utils
    private void InitialiseInventary(int nbSlotToInventory)
    {
        for (int i = 0; i < nbSlotToInventory; i++)
        {
            GameObject slotToInstanciedTmp = Instantiate(m_inventorySlot);
            m_slots.Add(slotToInstanciedTmp);

            m_items.Add(new Item());

            m_slots[i].GetComponent<Slot>().m_id = i;
            m_slots[i].transform.position = Vector2.zero;
            m_slots[i].transform.SetParent(m_slotPanel.transform, false);
        }
    }
    #endregion

    #region PrivateProtectedVariable
    private GameObject m_inventoryPanel;
    private GameObject m_slotPanel;
    private ItemManager m_itemManager;
    private bool m_showInventory;
    #endregion
}
