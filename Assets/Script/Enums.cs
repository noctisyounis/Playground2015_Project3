using UnityEngine;
using System.Collections;


public enum e_action
{
    Eat,
    DrinkPotion,
    BeingStroke,
    BeingHit
}
public enum e_karmaState
{
    Invalid = -1,
    MinKarma = 0,
    Neutral = 50,
    MaxKarma = 100

}

public enum e_hungerState
{
    Invalid = -1,
    PenaltyLife = 10,
    BonusLife = 90,
    Neutral = 50,
    MaxHunger = 100
}

public enum e_itemType
{
    INVALID, POTION, FOOD, POTION_EVOLVE, POTION_POISON
}

public enum e_element
{
    Normal,
    Water,
    Flying,
    Fire,
    Earth,
    Plant,
    Insect
}
