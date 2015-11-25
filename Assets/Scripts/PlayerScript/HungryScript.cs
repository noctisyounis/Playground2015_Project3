using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HungryScript : MonoBehaviour
{

    #region Public_Variable

    public int m_StartingHungry = 100;
    public static int m_CurrentHungry;
    public Slider m_HungrySlider;
    public Image m_DamageImage;
    public static AudioClip m_DeathClip;
    public float m_FlashSpeed = 5f;
    public Color m_FlashColor = new Color(1f, 0f, 0f, 0.1f);

    #endregion

    #region Main_Methods

    void Awake()
    {
        m_CurrentHungry = m_StartingHungry;
    }

    void Start()
    {
        //m_anim = GameObject.Find("HUDCanvas").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_DamageImage != null)
        {
            if (m_damaged)
            {
                m_DamageImage.color = m_FlashColor;
            }
            else
            {
                //m_DamageImage.color = Color.Lerp(m_DamageImage.color, Color.clear, m_FlashSpeed * Time.deltaTime);
            }
            m_damaged = false; 
        }
    }

    public void TakeDamage(int amount)
    {
        m_damaged = true;
        m_CurrentHungry -= amount;
        m_HungrySlider.value = m_CurrentHungry;
        //PlayerAudio.Play();

        if (m_CurrentHungry <= 0 && !m_isDead)
        {
            Death();
        }
    }

    static public void Death()
    {
        Debug.Log("ok");
        m_isDead = true;

        m_anim.SetBool("GameOver", true);

        //m_playerAudio.clip = m_DeathClip;
        //m_playerAudio.Play();



    }

    #endregion

    #region PrivateAndProtected

    static Animator m_anim;
    static AudioSource m_playerAudio;
    static bool m_isDead;
    bool m_damaged;
     
    #endregion


}
