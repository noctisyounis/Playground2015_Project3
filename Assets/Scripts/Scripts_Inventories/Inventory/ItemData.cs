using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    #region PublicVariable
    public Item m_item;
    public int m_amount = 1;
    public int m_slot;
    public int AmountMax = 10;

    public Vector2 Offset
    {
        get
        {
            return m_offset;
        }

        set
        {
            m_offset = value;
        }
    }

    public Inventory Inventory
    {
        get
        {
            return m_inventory;
        }

        set
        {
            m_inventory = value;
        }
    }

    public Tooltip Tooltip
    {
        get
        {
            return m_tooltip;
        }

        set
        {
            m_tooltip = value;
        }
    }

    #endregion

    #region MainMethods

    void Start()
    {
        Inventory = GameObject.Find("InventoryFridge").GetComponent<Inventory>();
        Tooltip = Inventory.GetComponent<Tooltip>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (m_item != null)
        {
            Offset = eventData.position - new Vector2(eventData.position.x, eventData.position.y);
            this.transform.SetParent(this.transform.parent.parent);
            this.transform.position = eventData.position - Offset;

            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (m_item != null)
        {
            this.transform.position = eventData.position - Offset;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(Inventory.m_slots[m_slot].transform);
        this.transform.position = Inventory.m_slots[m_slot].transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

   

    public void OnPointerDown(PointerEventData eventData)
    {
        if (m_item != null)
        {
            Offset = eventData.position - new Vector2(eventData.position.x, eventData.position.y);
        }

        if (Input.GetMouseButtonDown(1))
        {
            //int clickCount = eventData.clickCount;

            GameObject Avatar = GameObject.FindGameObjectWithTag("Avatar");
            Creature creatureStats = Avatar.GetComponent<Creature>();

            // Récupéré le item actuel.
            ItemData dataCurrent = gameObject.GetComponent<ItemData>();
            Item itemCurrent = dataCurrent.m_item;

            //Toolbox.Break("different size : " + different);

            if (dataCurrent.m_slot > 0 && dataCurrent.m_slot > 0)
            {
                dataCurrent.m_slot--; 


                e_action actionToPlayed = DetectActionToDo(itemCurrent.TypeItem);

                creatureStats.Interact(actionToPlayed, m_item);
            }
            else
            {
                //Toolbox.Break("Vous n'avez plus d'item");
            }
 
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Tooltip.Activate(m_item);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltip.Desactivate();
    }

    e_action DetectActionToDo(e_itemType typeItem)
    {
        e_action actionToDO = e_action.None;

        switch (typeItem)
        {
            case e_itemType.NONE:
                break;

            case e_itemType.POTION:
                actionToDO = e_action.DrinkPotion;
                break;

            case e_itemType.FOOD:
                actionToDO = e_action.Eat;
                break;

            case e_itemType.POTION_EVOLVE:
                actionToDO = e_action.BeingEvolve;
                break;

            case e_itemType.POTION_POISON:
                actionToDO = e_action.BeingSick;
                break;

            case e_itemType.BISCUIT:
                actionToDO = e_action.Eat;
                break;

            default:
                break;
        }

        Debug.Log("---> Result from function DetectActionToDo : " + actionToDO.ToString());

        return actionToDO;
    }

    #endregion

    #region Utils
    #endregion

    #region PrivateProtectedVariable
    private Vector2 m_offset;
    private Inventory m_inventory;
    private Tooltip m_tooltip;
    #endregion
}
