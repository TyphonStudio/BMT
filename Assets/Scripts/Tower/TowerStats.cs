using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct TowerStats
{
    public System.Action<TowerStats> onAnyStatChanged;

    public float Health
    {
        get { return health; }
        set
        {
            health = value;
            onAnyStatChanged?.Invoke(this);
         }
    }

    float health;
}