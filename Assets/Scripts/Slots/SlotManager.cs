using UnityEngine;
using System.Collections;

public class SlotManager : MonoBehaviour
{

    #region Public_Variable

    public int m_colsCount = 0;
    public int m_rowCount = 0;
    public GameObject m_slotPrefab;
    public Vector3 m_defautSlotPosition;
    public int m_slotOffset = 110;
    public Vector3 m_slotPosition;

    #endregion

    #region Main_Method

    //Create all slots in the scene
    public void CreateSlots()
    {
        if (m_slotPrefab == null) Debug.LogError("slotPrefab can't be null");

        for (int i = 0; i < m_colsCount; i++)
        {
            for (int j = 0; j < m_rowCount; j++)
            {
                GameObject currentSlot = Instantiate(m_slotPrefab, new Vector3(m_slotPosition.x + i * m_slotOffset, m_slotPosition.y - j * m_slotOffset), Quaternion.identity) as GameObject;
                currentSlot.transform.SetParent(transform, false);
                //currentSlot.transform.localScale = Vector3.one;
            }
        }

        //int slotCount = 1;

        //for (int i = 0; i < m_colsCount; i++)
        //{
        //    for (int j = 0; j < m_rowCount; j++)
        //    {
        //        //createSlot.

        //        GameObject currentSlot = Instantiate(m_slotPrefab, new Vector3(m_slotPosition.x, m_slotPosition.y, 0), Quaternion.identity) as GameObject;
        //        currentSlot.transform.parent = transform;
        //        currentSlot.name = "Slot" + slotCount;
        //        //Update Position

                
        //        RectTransform rectTransform = currentSlot.GetComponent<RectTransform>();
        //        currentSlot.transform.localScale = Vector3.one;
        //        currentSlot.transform.localPosition = new Vector3(m_slotPosition.x, m_slotPosition.y);

        //        //Add offset position on slotX
        //        m_defautSlotPosition.x += m_slotOffset;

        //        if (slotCount > 1 && slotCount % m_rowCount -1 == 0)
        //        {
        //            Debug.Log("toto");
        //            m_slotPosition.y -= m_slotOffset;
        //            m_slotPosition.x = m_defautSlotPosition.x;
        //            currentSlot.transform.position = m_slotPosition;
        //        }

        //        slotCount++;

        //    } 
        //}
    }

    void Awake()
    {

        m_slotPosition = m_defautSlotPosition;
    }

    // Use this for initialization
    void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    #endregion

    #region PrivateAndProtected

    

    #endregion


}
