using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Terrain/TerrainType")]
[System.Serializable]
public class TerrainType : ScriptableObject
{
    [SerializeField]
    float fixedSpeedModifier;

    public void OnEnter(Traveller traveller)
    {
        traveller.TravelSpeed += fixedSpeedModifier;
    }

    public void OnExit(Traveller traveller)
    {
        traveller.TravelSpeed -= fixedSpeedModifier;
    }
}