using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class myInteractCreature : MonoBehaviour
{
    public int m_currentKarma;
    public Slider m_karmaSlide;
    public Texture2D m_cursorHand;
    public Texture2D m_cursorGlove;
    public CursorMode m_cursorMode = CursorMode.Auto;
    public Vector2 m_hotSpot = Vector2.zero;
    public float m_delayBetweenTwoBonus = 3f;

    IEnumerator Wait()
    {
        m_canInteract = false;
        yield return new WaitForSeconds(m_delayBetweenTwoBonus);
        m_canInteract = true;
    }

    void Start()
    {
        m_canInteract = true;
        m_anim = GetComponent<Animator>();
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            if(m_canInteract)
            {
                Hug();
                StartCoroutine("Wait");
            }
        }

        if (Input.GetMouseButton(1))
        {
            if (m_canInteract)
            {
                Beat();
                StartCoroutine("Wait");
            }
        }

        if(Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            Release();
        }
     }

    void Hug()
    {
        Cursor.SetCursor(m_cursorHand, m_hotSpot, m_cursorMode);
        m_currentKarma += 1;
        m_karmaSlide.value = m_currentKarma;
        m_anim.SetFloat("Blend", 0.5f);
    }

    void Beat()
    {
        Cursor.SetCursor(m_cursorGlove, m_hotSpot, m_cursorMode);
        m_currentKarma -= 2;
        m_karmaSlide.value = m_currentKarma;
        m_anim.SetFloat("Blend", 0.666f);
    }

    void Release()
    {
        Cursor.SetCursor(null, m_hotSpot, m_cursorMode);
        m_anim.SetFloat("Blend", 0);
    }

    #region ProtectedAndPrivate

    bool m_canInteract = true;
    Animator m_anim;
    #endregion
}
