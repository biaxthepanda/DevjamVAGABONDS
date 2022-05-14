using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Registry
{
    private const string LastLevelKey = "LastLevelKey";

    public static int LastLevelIndex
    {
        get => PlayerPrefs.GetInt(LastLevelKey, 0);
        set
        {
            if (value < 0) value = 0;
            PlayerPrefs.SetInt(LastLevelKey, value);   
        }
    }
}
