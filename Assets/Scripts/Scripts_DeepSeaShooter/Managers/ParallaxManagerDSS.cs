using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// <summary>
// Parallax manager.
// All Child of this object will be considered as the multiple layer ( empty gameobject )
// of the parallax effect. 
// </summary>
public class ParallaxManagerDSS : MonoBehaviour
{
    #region Public Variables
    public enum e_parallaxAxis
    {
        INVALID = -1,
        X,
        Y,
        XAndY
    }

    public enum e_parallaxMode
    {
        INVALID = -1,
        Continue,
        RelativeToObject
    }

    public bool m_enabled;
    public e_parallaxMode m_parallaxMode;
    public GameObject m_reference;

    [Header("System Scrolling")]
    public e_parallaxAxis m_axisAffected;

    [Range(0, 1f)]
    public float m_speedDecreaseByLayer;
    public Vector2 m_speed;
    public Vector2 m_direction;

    [Header("System Looping")]
    public Vector2 m_limits;
    public Vector2 m_respawn;


    [Header("Debug")]
    public bool m_showDebug;

    public Color m_limitsColor = Color.red;
    public Color m_respawnColor = Color.blue;
    #endregion

    #region Main Methods
    void Start()
    {
        m_referenceRB2D = m_reference.GetComponent<Rigidbody2D>();
        //Verify if while RelativeMode is enable, there is a rigidbody
        if (m_referenceRB2D == null && m_parallaxMode == e_parallaxMode.RelativeToObject)
        {
            Debug.LogError("Parallax Manager: the paralax mode is relative to object, but there is no Rigidbody2D component in m_reference!");
        }
    }

    void Update()
    {
        if (m_enabled)
        {
            m_debugString = "";
            int i = 1;

            //Foreach child in layer in transform set a speed and a direction in function of the enable mode (Continue or relative to object)
            foreach (Transform layer in transform)
            {
                m_debugString += "Layer: " + layer.name + " at speed " + m_speed.x * m_direction.x * (m_speedDecreaseByLayer * i) + "\n";

                foreach (Transform child in layer)
                {
                    float speedX = 0f;
                    float speedY = 0f;

                    if (m_parallaxMode == e_parallaxMode.Continue)
                    {
                        if (m_axisAffected == e_parallaxAxis.X || m_axisAffected == e_parallaxAxis.XAndY)
                        {
                            speedX = m_speed.x * m_direction.x * (m_speedDecreaseByLayer * (i + 1f));
                        }

                        if (m_axisAffected == e_parallaxAxis.Y || m_axisAffected == e_parallaxAxis.XAndY)
                        {
                            speedY = m_speed.y * m_direction.y * (m_speedDecreaseByLayer * (i + 1f));
                        }
                    }

                    if (m_parallaxMode == e_parallaxMode.RelativeToObject)
                    {
                        if (m_axisAffected == e_parallaxAxis.X || m_axisAffected == e_parallaxAxis.XAndY)
                        {
                            speedX = m_referenceRB2D.velocity.x * m_direction.x * (m_speedDecreaseByLayer * (i + 1f));
                        }

                        if (m_axisAffected == e_parallaxAxis.Y || m_axisAffected == e_parallaxAxis.XAndY)
                        {
                            speedY = m_referenceRB2D.velocity.y * m_direction.y * (m_speedDecreaseByLayer * (i + 1f));
                        }
                    }


                    Vector2 movement = new Vector2(speedX, speedY);
                    movement *= Time.deltaTime;

                    //Make the translation in space world ( for rotated element )
                    child.Translate(movement, Space.World);

                    //Reset the position of the sprites that are used to parallax 
                    if (isBehindBorder(child, m_limits.x, m_respawn.x, true))
                    {
                        child.position = new Vector2(m_respawn.x, child.position.y);
                    }

                    if (isBehindBorder(child, m_limits.y, m_respawn.y, false))
                    {
                        child.position = new Vector2(child.position.x, m_respawn.y);
                    }
                }
                i++;
            }
        }
    }
    #endregion

    #region Utils & Debug
    //Set debug line to see where is the border limit
    bool isBehindBorder(Transform item, float limit, float respawn, bool isHorizontal)
    {
        if (limit > respawn)
        {
            if (isHorizontal)
            {
                return (item.position.x > limit);
            }
            return (item.position.y > limit);
        }

        if (isHorizontal)
        {
            return (item.position.x < limit);
        }
        return (item.position.y < limit);
    }

    //Function to see where are the border limits
    void OnDrawGizmos()
    {
        if (m_showDebug)
        {
            Color previousColor = Gizmos.color;

            Gizmos.color = m_limitsColor;
            Gizmos.DrawLine(new Vector3(m_limits.x, -10f), new Vector3(m_limits.x, 10f));
            Gizmos.DrawLine(new Vector3(-10f, m_limits.y), new Vector3(10f, m_limits.y));

            Gizmos.color = m_respawnColor;
            Gizmos.DrawLine(new Vector3(m_respawn.x, -10f), new Vector3(m_respawn.x, 10f));
            Gizmos.DrawLine(new Vector3(-10f, m_respawn.y), new Vector3(10f, m_respawn.y));

            Gizmos.color = previousColor;
        }
    }

    //Function to show a debug button
    void OnGUI()
    {
        if (m_showDebug)
        {
            GUILayout.Button(m_debugString);
        }
    }
    #endregion

    #region Private & Protected Variables
    string m_debugString;
    Rigidbody2D m_referenceRB2D;
    #endregion
}
