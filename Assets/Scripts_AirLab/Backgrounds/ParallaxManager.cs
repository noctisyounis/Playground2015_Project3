using UnityEngine;
using System.Collections;

public class ParallaxManager : MonoBehaviour
{
    /*
        TODO:
        definir une limite a gauche ( ou droite etc ) 
        definir une limite de respawn ( Vector2 )
        verifier a chaque frame si l'element depasse de cette limite en x 
        si on depasse deplacer l'element de l'autre coté
        lignes de debug en bonus ...     
    */
    #region PublicVariable
    public Vector3 m_cloud;
    public Vector2 m_speed;
    public Vector2 m_direction;
    public Vector2 m_hero;
    [Range (0, 1)]
    public float m_decreaseRatio;
    [Header("Debug And Settings")]
    public Vector3 m_verticalLineStart;
    public Vector3 m_verticalLineEnd;
    public float m_offSet;
    public float m_debugBarSize;
    public float m_respawn;


    #endregion

    #region MainMethod
    // Use this for initialization
    void Start ()
    {
        m_dynamicDestroyLine = new Vector3(Camera.main.transform.position.x - m_offSet,
                                    Camera.main.transform.position.y - m_debugBarSize / 2,
                                    Camera.main.transform.position.z);
    }
	
	// Update is called once per frame
	void Update ()
    {
        int i = 0;
        foreach ( Transform layer in transform )
        {
            foreach (Transform child in layer)
            {
                var speedX = 0f;
                var speedY = 0f;

                //child.position = new Vector3(child.position.x - 1, child.position.y, 0);

                speedX = m_speed.x * m_direction.x * (m_decreaseRatio * (i + 1f));
                var movement = new Vector2(speedX, speedY);
                //Translate( vector2 ou 3 );
                transform.Translate(movement * Time.deltaTime);

                if (child.position.x < m_dynamicDestroyLine.x)
                {
                    child.position = new Vector3(child.position.x + m_respawn, child.position.y, child.position.z);

                }
            }
            i++;
        }
	}

    
    #endregion

    #region UtilsAndDebug
    //void OnGUI()
    //{
    //    GUILayout.Button(m_speed.x * m_direction.x * (m_decreaseRatio * (1f)) + "  -- " + m_speed.x * m_direction.x * (m_decreaseRatio * (2f)));
    //}

    void OnDrawGizmos()
    {
        //VerticalLine
        Gizmos.color = Color.blue;
        m_dynamicDestroyLine = new Vector3(Camera.main.transform.position.x - m_offSet,
                                    Camera.main.transform.position.y - m_debugBarSize / 2,
                                    Camera.main.transform.position.z);
        Gizmos.DrawLine(m_dynamicDestroyLine,
                        
                       new Vector3(Camera.main.transform.position.x - m_offSet,
                                    Camera.main.transform.position.y + m_debugBarSize / 2, 
                                    Camera.main.transform.position.z));
    }
    #endregion

    #region ProtectedAndPrivate
    private Vector3 m_dynamicDestroyLine;
    #endregion



}