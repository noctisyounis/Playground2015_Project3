using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Creature : MonoBehaviour
{
    #region PublicVariable

    public string m_name;

    public int Life
    {
        get
        {
            return m_life;
        }

        set
        {
            m_life = Toolbox.Check(value, 0, LIFE_MAX);
        }
    }

    public int XpMax
    {
        get
        {
            return m_xpMax;
        }

        set
        {
            m_xpMax = Toolbox.CheckIfPositive(value, 100);
        }
    }

    public int Xp
    {
        get
        {
            return m_xp;
        }

        set
        {
            m_xp = Toolbox.Check(value, 0, m_xpMax);
        }
    }

    public int Karma
    {
        get
        {
            return m_karma;
        }

        set
        {
            m_karma = Toolbox.Check(value, 0, (int)e_karmaState.Max_Karma);
        }
    }

    public int Hunger
    {
        get
        {
            return m_hunger;
        }

        set
        {
            m_hunger = Toolbox.Check(value, 0, (int)e_hungerState.Max_Hunger);
        }
    }
    #endregion

    #region MainMethods

    /// <summary>
    /// Interaction with the creature in game.
    /// </summary>
    /// <param name="action">The different's actions on creature</param>
    /// <param name="percentage">percentage = value between 0 and 1, 1 correspond to 100 %</param>
    /// <param name="value">value is the intensity of action on creature</param>
    public void Interact(e_action action, float percentage, int value)
    {
        //TODO kr : Debug.Log(Mathf.FloorToInt(10.1f));
        Debug.Log("------- Enter in the function Interact -------");

        int tmpValue = Toolbox.RoundValueToInt(percentage * value);

        Debug.Log("action parameter : " + action.ToString());

        switch (action)
        {
            case e_action.Eat:
                ChangeHunger(tmpValue);
                Debug.Log("Interact Eat");
                break;

            case e_action.DrinkPotion:
                ChangeExperience(tmpValue);
                Debug.Log("Interact Drink");

                break;

            case e_action.BeingStroke:
                ChangeKarma(tmpValue);
                Debug.Log("Interact Stroke");

                break;

            case e_action.BeingHit:
                ChangeHunger(tmpValue);
                Debug.Log("Interact Hit");

                break;

            case e_action.BeingEvolve:
                ChangeHunger(tmpValue);
                Debug.Log("Interact Evolve");

                break;

            case e_action.BeingSick:
                ChangeHunger(tmpValue);
                Debug.Log("Interact Sick");

                break;
            default:
                break;
        }
    }

    void ChangeExperience(int xp)
    {
        int tmpXp = Xp + xp;
        Xp = Toolbox.Check(tmpXp, 0, XpMax);
    }

    void AppliedDamage(int dmg)
    {
        int tmpLife = Life - dmg;

        Life = Toolbox.Check(tmpLife, 0, LIFE_MAX);
    }

    void ChangeKarma(int karma)
    {
        int tmpKarma = karma + Karma;

        Karma = Toolbox.Check(tmpKarma, 0, (int)e_karmaState.Max_Karma);
    }

    void ChangeHunger(int intensity)
    {
        int tmpHunger = intensity + Hunger;

        Hunger = Toolbox.Check(tmpHunger, 0, (int)e_hungerState.Max_Hunger);
    }

    public Creature(string name)
    {
        m_name = name;
    }

    public Creature()
    {

    }

    void Start()
    {
        Life = 100;
        XpMax = 100;
        Xp = 0;

        Karma = (int)e_karmaState.Neutral;
        Hunger = (int)e_hungerState.Neutral;
    }
    #endregion

    #region Utils
  
    #endregion

    #region PrivateProtectedVariable
    int m_penaltyKarma;
    int m_bonusKarma;
    const int LIFE_MAX = 100;
    int m_life;
    int m_xpMax;
    int m_xp;
    int m_karma;
    int m_hunger;
    float m_weight;
    #endregion
}
