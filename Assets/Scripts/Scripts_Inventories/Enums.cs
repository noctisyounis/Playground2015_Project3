using UnityEngine;
using System.Collections;



#region PublicVariable
public enum e_action
{
    None,
    Eat,
    DrinkPotion,
    BeingStroke,
    BeingHit,
    BeingEvolve,
    BeingSick
}
public enum e_karmaState
{
    Invalid = -1,
    MinKarma = 0,
    Neutral = 50,
    Max_Karma = 100

}

public enum e_hungerState
{
    Invalid = -1,
    Penalty_Life = 10,
    BonusLife = 90,
    Neutral = 50,
    Max_Hunger = 100
}
public enum e_itemRarity
{
    None, Normal, Unusual, Rare, Epic
}

public enum e_itemType
{
    NONE, POTION, FOOD, POTION_EVOLVE, POTION_POISON, BISCUIT
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

#endregion

//Empty
#region MainMethods
#endregion

//Empty
#region Utils
#endregion

//Empty
#region PrivateProtectedVariable
#endregion