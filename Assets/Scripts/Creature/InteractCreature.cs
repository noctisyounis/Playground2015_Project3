using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InteractCreature : MonoBehaviour
{

    #region PublicVariable
    public int m_currentKarma;
    public Slider m_karmaSlide;
    public GameObject m_hugh;
    public Texture2D m_cursorHand;
    public Texture2D m_cursorGlove;
    public CursorMode m_cursorMode = CursorMode.Auto;
    public Vector2 m_hotSpot = Vector2.zero;
    public Animation m_happy;
    public Animator m_happyAnimation;


    #endregion

    #region MainMethod
    void Start()
    {
        OnMouseOver();
    }

    IEnumerator maCoroutine()
    {
        while( true )
        {
            if(Input.GetMouseButtonDown(0))
            {
                Cursor.SetCursor(m_cursorHand, m_hotSpot, m_cursorMode);
                m_currentKarma += 1;
                m_karmaSlide.value = m_currentKarma;
                GetComponent<Animator>().SetBool("ifHug", true);
                yield return new WaitForSeconds(3f);
            }
            
            if (Input.GetMouseButtonUp(0))
            {
                Cursor.SetCursor(null, m_hotSpot, m_cursorMode);
                GetComponent<Animator>().SetBool("ifHug", false);
            }

            if (Input.GetMouseButtonDown(1))
            {
                Cursor.SetCursor(m_cursorGlove, m_hotSpot, m_cursorMode);
                m_currentKarma -= 2;
                m_karmaSlide.value = m_currentKarma;
                GetComponent<Animator>().SetBool("ifBeat", true);
                yield return new WaitForSeconds(3f);
            }
           
            if (Input.GetMouseButtonUp(1))
            {
                Cursor.SetCursor(null, m_hotSpot, m_cursorMode);
                GetComponent<Animator>().SetBool("ifBeat", false);
            }
            yield return new WaitForSeconds(0);
        }
    }
    void OnMouseOver()
    {
       // StartCoroutine("maCoroutine");
    }
    //void OnMouseOver()
    //{
    //    if(Input.GetMouseButtonDown(0))
    //    {
    //        Cursor.SetCursor(m_cursorHand, m_hotSpot, m_cursorMode);
    //        m_currentKarma += 20;
    //        m_karmaSlide.value = m_currentKarma;
    //        GetComponent<Animator>().SetBool("ifHug",true);    
    //    }
    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        Cursor.SetCursor(null, m_hotSpot, m_cursorMode);
    //        GetComponent<Animator>().SetBool("ifHug", false);
    //    }

    //    if (Input.GetMouseButtonDown(1))
    //    {
    //        Cursor.SetCursor(m_cursorGlove, m_hotSpot, m_cursorMode);
    //        m_currentKarma -= 20;
    //        m_karmaSlide.value = m_currentKarma;
    //        GetComponent<Animator>().SetBool("ifBeat", true);
    //    }
    //    if (Input.GetMouseButtonUp(1))
    //    {
    //        Cursor.SetCursor(null, m_hotSpot, m_cursorMode);
    //        GetComponent<Animator>().SetBool("ifBeat", false);

    //    }
    //}


    void OnMouseExit()
    {
        Cursor.SetCursor(null, m_hotSpot, m_cursorMode);
    }

    #endregion

    #region ProtectedAndPrivate

    #endregion
    
}
