using UnityEngine;
using System.Collections;

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

    //Function to convert String to Int
    public static int ConvertStringToInt(string text)
    {
        //Convert Scrore to XP
        int result;
        bool isConvert = int.TryParse(text, out result);

        if (isConvert)
        {
            return result;
        }
        return -1;
    }

    #endregion

    //Empty
    #region Utils

    #endregion

    //Empty
    #region PrivateProtectedVariable

    #endregion 


}
