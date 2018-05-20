using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField] private GameObject unitPrefab;
    [SerializeField] HealthSliderCreator healthSliderCreator;

    bool isActive;

    public Unit SpawnInCell(HexCell cell, UnitType type)
    {
        var unit = Instantiate(unitPrefab).GetComponent<Unit>();
        unit.transform.position = cell.Position;
        AllUnits.Instance.Add(unit);

        unit.ApplyType(type);
        AssignHealthBar(unit);
        
        return unit;
    }

    void AssignHealthBar(Unit unit)
    {
        healthSliderCreator.CreateSliderFor(unit);
    }
}