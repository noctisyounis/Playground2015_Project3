using UnityEngine;
using System.Collections.Generic;

public class Level : MonoBehaviour
{
    #region Public Variable
    public int m_level;
    public int m_maxLevel = 4;
    public float m_maxTime = 2.0f;
    public float m_minTime = 1.0f;
    #endregion

    #region Main Methodes
    void Start()
    {
        switch (m_level)
        {
            case 1:
                m_map = LevelsMap.m_level1;
                m_lenght = LevelsMap.m_level1Lenght;
                break;

            case 2:
                m_map = LevelsMap.m_level2;
                m_lenght = LevelsMap.m_level2Lenght;
                break;

            case 3:
                m_map = LevelsMap.m_level3;
                m_lenght = LevelsMap.m_level3Lenght;
                break;

            case 4:
                m_map = LevelsMap.m_level4;
                m_lenght = LevelsMap.m_level4Lenght;
                break;
        }

        Levelgenerator();

        m_isFinish = false;
        m_time = m_maxTime;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        for(int i = 0; i < enemies.Length; ++i)
        {
            EnemyBehaviour enemy = enemies[i].GetComponent<EnemyBehaviour>();
            initEnemyDoor(enemy);
        }
    }

    void Update()
    {
        m_time -= Time.deltaTime;

        GameObject[] Pacdots = GameObject.FindGameObjectsWithTag("Pacdot");
        List<GameObject> Bonus = Toolbox.getItemInLayer(9);
        GameObject playerGO = GameObject.FindGameObjectWithTag("Player");

       if(playerGO == null && m_isFinish == false)
        {
            m_isFinish = true;
            PlayerPrefs.SetInt("LEVEL", m_level);
            Application.LoadLevel("GameOver");
        }


        if (Pacdots.Length == 0 && m_isFinish == false)
        {
            m_level = Toolbox.Check(m_level + 1, 1, m_maxLevel);

            PlayerPrefs.SetInt("LEVEL", m_level);

            PlayerBehaviour player = playerGO.GetComponent<PlayerBehaviour>();
            int xp = PlayerPrefs.GetInt("XP") + player.m_xp;
            int numbCerise = PlayerPrefs.GetInt("CERISE") + player.m_numbCerise;
            int numbChem1 = PlayerPrefs.GetInt("BLUECHEMS") + player.m_numbChem1;
            int numbChem2 = PlayerPrefs.GetInt("PINKCHEMS") + player.m_numbChem2;
            int numbChem3 = PlayerPrefs.GetInt("ORANGECHEMS") + player.m_numbChem3;

            PlayerPrefs.SetInt("XP", xp);
            Debug.Log("Xp set : " + PlayerPrefs.GetInt("XP"));
            PlayerPrefs.SetInt("CERISE", numbCerise);
            PlayerPrefs.SetInt("BLUECHEMS", numbChem1);
            PlayerPrefs.SetInt("PINKCHEMS", numbChem2);
            PlayerPrefs.SetInt("ORANGECHEMS", numbChem3);

            Application.LoadLevel("EndLevel");

            m_isFinish = true;
        }
        else
        {
            if(Bonus.Count == 0 && m_time <= 0)
            {
                BonusSpawn();
            }
        }
    }

    #endregion

    #region Utils
    public void Levelgenerator()
    {
        GameObject tmp;
        m_positionBonus = new List<Vector2>();

        for (int i = 0; i < m_map.Length; ++i)
        {
            int x = (i % (int)m_lenght.x);
            int y = (i / (int)m_lenght.x * (-1));

            float fX = x - (m_lenght.x / 2) + 0.5f;
            float fY = y + (m_lenght.y / 2) - 0.5f;

            switch (m_map[i])
            {
                case 1:
                    tmp = (GameObject) Instantiate(Resources.Load("CornerTopLeft"));
                    tmp.transform.position = new Vector2(fX, fY);
                    break;

                case 2:
                    tmp = (GameObject) Instantiate(Resources.Load("CornerTopRight"));
                    tmp.transform.position = new Vector2(fX, fY);
                    break;

                case 3:
                    tmp = (GameObject) Instantiate(Resources.Load("CornerDownLeft"));
                    tmp.transform.position = new Vector2(fX, fY);
                    break;

                case 4:
                    tmp = (GameObject) Instantiate(Resources.Load("CornerDownRight"));
                    tmp.transform.position = new Vector2(fX, fY);
                    break;

                case 5:
                    tmp = (GameObject) Instantiate(Resources.Load("HorizontalWall"));
                    tmp.transform.position = new Vector2(fX, fY);
                    break;

                case 6:
                    tmp = (GameObject) Instantiate(Resources.Load("VerticalWall"));
                    tmp.transform.position = new Vector2(fX, fY);
                    break;

                case 7:
                    tmp = (GameObject) Instantiate(Resources.Load("ClosedDoorHorizontal"));
                    tmp.transform.position = new Vector2(fX, fY);
                    break;

                case 8:
                    tmp = (GameObject) Instantiate(Resources.Load("ClosedDoorVertical"));
                    tmp.transform.position = new Vector2(fX, fY);
                    break;

                case 9:
                    tmp = (GameObject) Instantiate(Resources.Load("Pacdot"));
                    Vector2 position = new Vector2(fX, fY);
                    tmp.transform.position = position;
                    m_positionBonus.Add(position);
                    break;
            }
        }
    }

    void initEnemyDoor(EnemyBehaviour enemy)
    {
        List<GameObject> doors = Toolbox.getItemInLayer(10);
        int index = 0;
        Vector2 enemyPos = enemy.gameObject.transform.position;

        for (int i = 0; i < doors.Count; ++i)
        {
            Vector2 doorPos = doors[i].transform.position;
            Vector2 minDoorPos = doors[index].transform.position;

            float distPlayerMinDoor = Vector2.Distance(enemyPos, minDoorPos);
            float distPlayerDoor = Vector2.Distance(enemyPos, doorPos);

            if (distPlayerDoor < distPlayerMinDoor)
            {
                index = i;
            }
        }

        enemy.m_door = doors[index];
    }

    void BonusSpawn()
    {
        m_time = Random.Range(m_minTime, m_maxTime);
        int random = Random.Range(0, m_positionBonus.Count);

        GameObject tmp = null;

        int rand1 = Random.Range(1, 4);
        int rand2 = Random.Range(1, 4);

        int sum = rand1 + rand2;

        switch (sum)
        {
            case 3:
            case 4:
            case 5:
                tmp = (GameObject)Instantiate(Resources.Load("Cerise"));
                break;

            case 2:
            case 6:
                int RandChem = Random.Range(1, 4);

                switch (RandChem)
                {
                    case 1:
                        tmp = (GameObject)Instantiate(Resources.Load("Chem1"));
                        break;

                    case 2:
                        tmp = (GameObject)Instantiate(Resources.Load("Chem2"));
                        break;

                    case 3:
                        tmp = (GameObject)Instantiate(Resources.Load("Chem3"));
                        break;
                }
                break;
        }

        tmp.transform.position = m_positionBonus[random];
    }
    #endregion

    #region Private & Protected Variables
    Vector2 m_lenght;
    int[] m_map;
    List<Vector2> m_positionBonus;
    bool m_isFinish;
    float m_time;
    GameObject m_xpGO;
    #endregion
}
