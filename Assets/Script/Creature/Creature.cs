using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Creature : MonoBehaviour
{
    //kb To DO : change array to collection for creature type
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
            m_karma = Toolbox.Check(value, 0, (int)e_karmaState.MaxKarma);
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
            m_hunger = Toolbox.Check(value, 0, (int)e_hungerState.MaxHunger);
        }
    }
    public e_element[] m_typeCreature;
    #endregion

    #region Utils

    /// <summary>
    /// Interaction with the creature in game.
    /// </summary>
    /// <param name="action">The different's actions on creature</param>
    /// <param name="percentage">percentage = value between 0 and 1, 1 correspond to 100 %</param>
    /// <param name="value">value is the intensity of action on creature</param>
    public void Interact(e_action action, Item item)
    {
        //TODO kr : Debug.Log(Mathf.FloorToInt(10.1f));
        int tmpValue = item.Intensity;

        switch (action)
        {
            case e_action.Eat:
                //verify if the item is really food
                if(item.m_typeItem == e_itemType.FOOD)
                {
                    //if creature type is normal or food is normal, no problem
                    //idem if creature and food type are compatible
                    //if not, ...
                    if(m_typeCreature[0] == e_element.Normal || item.m_elementType == e_element.Normal)
                    {
                        ChangeHunger(tmpValue);
                    }
                    else
                    {
                        bool isGood = false;

                        for(int i = 0; i < m_typeCreature.Length; ++i)
                        {
                            if(m_typeCreature[i] == item.m_elementType)
                            {
                                isGood = true;
                                break;
                            }
                        }

                        if(isGood)
                        {
                            ChangeHunger(tmpValue);
                        }
                        else
                        {
                            //do something if the food is not of the same type
                        }
                    }
                }
                break;

            case e_action.DrinkPotion:
                switch (item.m_typeItem)
                {
                    case e_itemType.POTION:
                        ChangeHunger(tmpValue);
                        break;

                    case e_itemType.POTION_EVOLVE:
                        if (m_typeCreature[0] == e_element.Normal)
                        {
                            m_typeCreature[0] = item.m_elementType;
                        }
                        else
                        {
                            e_element[] tmpTypeCreature = new e_element[m_typeCreature.Length + 1];
                            for(int i = 0; i < m_typeCreature.Length; ++i)
                            {
                                tmpTypeCreature[i] = m_typeCreature[i];
                            }

                            tmpTypeCreature[tmpTypeCreature.Length - 1] = item.m_elementType;          
                        }
                        break;

                    case e_itemType.POTION_POISON:
                        ChangeHunger(tmpValue);
                        int xpToRemove = Toolbox.RoundValueToInt(XpMax * -0.2f);
                        ChangeExperience(xpToRemove);
                        break;

                    default:
                        break;
                }
                break;

            case e_action.BeingStroke:
                ChangeKarma(tmpValue);
                break;

            case e_action.BeingHit:
                ChangeHunger(tmpValue);
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

        Karma = Toolbox.Check(tmpKarma, 0, (int)e_karmaState.MaxKarma);
    }

    void ChangeHunger(int intensity)
    {
        int tmpHunger = intensity + Hunger;

        Hunger = Toolbox.Check(tmpHunger, 0, (int)e_hungerState.MaxHunger);
    }

    public Creature(string name)
    {
        m_name = name;
    }


    public Creature()
    {

    }
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
