using UnityEngine;
using System.Collections.Generic;

public static class Toolbox
{
    //Empty
    #region PublicVariable
    #endregion

    #region MainMethods
    public static int Check(int value, int minValue, int maxValue)
    {
        if (value > maxValue)
        {
            value = maxValue;
        }
        else if (value < minValue)
        {
            value = minValue;
        }

        return value;
    }

    public static int CheckIfPositive(int value, int defaultValue)
    {
        return (value < 0) ? defaultValue : value;
    }

    public static int RoundValueToInt(float value)
    {
        value = Mathf.Round(value * 10) / 10;

        int iValue = Mathf.FloorToInt(value);

        float tmpValue = value - iValue;

        if (tmpValue >= 0.5)
        {
            iValue += 1;
        }

        return iValue;
    }

    public static List<GameObject> getItemInLayer(int layer)
    {
        GameObject[] objects = GameObject.FindObjectsOfType<GameObject>();
        List<GameObject> items = new List<GameObject>();

        for (int i = 0; i < objects.Length; ++i)
        {
            if(objects[i].layer == layer)
            {
                items.Add(objects[i]);
            }
        }

        return items;
    }
    public static void  Break(string description)
    {
        Debug.Log(description);
        Debug.Break();
    }
    #endregion

    //Empty
    #region Utils

    #endregion

    //Empty
    #region PrivateProtectedVariable

    #endregion 


}
