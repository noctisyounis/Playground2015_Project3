using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{

    public List<GameObject> m_ground;
    public GameObject m_hero;

    [Range(0.1f, 2f)]
    public float m_interval = 0.1f;
    public float m_spaceBetweenObstacles = 5f;
    public bool m_isTop;

    IEnumerator CheckVisibility(float interval)
    {
        int o = 0;
        while (true)
        {
            int i = 0;
            //int count = transform.GetChildCount();
            int count = transform.childCount;

            while ( i < count )
            {
                var go = transform.GetChild(i);

                if ( go != null && go.transform.position.x < m_hero.transform.position.x && !go.GetComponent<SpriteRenderer>().isVisible)
                {
                    o++;
                    m_isTop = !m_isTop;
                    Destroy( go.gameObject );
                    GameObject myInstance;
                    myInstance = Instantiate(Resources.Load("obstacle", typeof(GameObject)) as GameObject, /*position désirée*/ new Vector3(m_hero.transform.position.x + m_spaceBetweenObstacles, (m_isTop != true) ? m_spaceBetweenObstacles - 10f : m_spaceBetweenObstacles + 2f , 0f), Quaternion.identity ) as GameObject;
                    myInstance.transform.parent = transform;
                    myInstance.name = "columns" + o;
                    //m_Obstacle.Add(myInstance);
                }
                i++;
            }

            yield return new WaitForSeconds(interval);
        }
    }

	// Use this for initialization
	void Start () {
        StartCoroutine(CheckVisibility(m_interval));
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
