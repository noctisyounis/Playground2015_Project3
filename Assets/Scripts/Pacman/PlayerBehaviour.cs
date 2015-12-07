using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class PlayerBehaviour : MonoBehaviour {

    #region Public Variable
    public Vector2 m_startPosition;
    public float m_speed;
    public int m_xp;
    public int m_numbCerise;
    public int m_numbChem1;
    public int m_numbChem2;
    public int m_numbChem3;
    public bool m_isInvincible;
    public float m_maxInvinsible = 3.0f;
    public float m_time;
    public int m_enemyXp = 10;
    #endregion

    #region Main Methodes
    void Start()
    {
        animator = GetComponent<Animator>();
        transform.position = m_startPosition;
        m_destination = transform.position;
        m_xpUI = GameObject.Find("XP").GetComponent<Text>();
        m_rgb2D = GetComponent<Rigidbody2D>();
        color = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if(m_xpUI != null)
        {
            m_xpUI.text = m_xp.ToString();
        }

        bool xRight = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);
        bool xLeft = Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow);
        bool yUp = Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.UpArrow);
        bool yDown = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);

        Vector2 position = Vector2.MoveTowards(transform.position, m_destination, m_speed);
        m_rgb2D.MovePosition(position);

        Vector2 direction = Vector2.zero; 

        if((Vector2) transform.position == m_destination)
        {
            if (xRight && ValideDir(Vector2.right))
            {
                m_destination = (Vector2) transform.position + Vector2.right;
                direction = Vector2.right;
            }

            if (xLeft && ValideDir(Vector2.left))
            {
                m_destination = (Vector2)transform.position + Vector2.left;
                direction = Vector2.left;
            }

            if (yUp && ValideDir(Vector2.up))
            {
                m_destination = (Vector2)transform.position + Vector2.up;
                direction = Vector2.up;
            }

            if (yDown && ValideDir(Vector2.down))
            {
                m_destination = (Vector2)transform.position + Vector2.down;
                direction = Vector2.down;
            }
        }

        animator.SetFloat("DirX", direction.x);
        animator.SetFloat("DirY", direction.y);

        if(m_time > 0)
        {
            m_time -= Time.fixedDeltaTime;
        }
        else
        {
            m_isInvincible = false;
            color.color = new Color(1, 1, 1, 1);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherGO = other.gameObject;

       if (otherGO.tag == "Enemy")
        {
            if(m_isInvincible == false)
            {
                Instantiate(Resources.Load(@"Pacman/GetHit"));
                Destroy(gameObject);
            }
            else
            {
                Instantiate(Resources.Load(@"Pacman/EatEnnemy"));
                EnemyBehaviour enemy = otherGO.GetComponent<EnemyBehaviour>();
                otherGO.transform.position = enemy.m_startPosition;
                enemy.m_isOut = false;
                enemy.m_current = 0;
                enemy.m_time = Random.Range(enemy.m_minTime, enemy.m_maxTime);
                m_xp += m_enemyXp;
            }
        }
    }
    #endregion

    #region Utils
    /*
        layer n° 8 = Pacdot
        layer n°9 = Bonus
    */
    bool ValideDir(Vector2 dir)
    {
        Vector2 position = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(position + dir, position);
        return (hit.collider.tag == "Player" || 
                hit.collider.tag == "Enemy" ||
                hit.collider.gameObject.layer == 8 ||
                hit.collider.gameObject.layer == 9);
    }
    #endregion

    #region Private & Protected Variables
    Vector2 m_destination;
    Text m_xpUI;
    Animator animator;
    Rigidbody2D m_rgb2D;
    SpriteRenderer color;
    #endregion
}
