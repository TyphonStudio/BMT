using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public UnitSelector unitSelector;
    public PathFinder pathFinder;

    public List<Unit> SelectedUnits { get { return selectedUnits; } }
    [SerializeField]
    List<Unit> selectedUnits = new List<Unit>();

    public delegate void PlayerUnitsChanged(List<Unit> newSelection);
    public event PlayerUnitsChanged OnPlayerUnitsChanged;

    public void ChangeSelection(List<Unit> newSelection)
    {
        selectedUnits = newSelection;
        OnPlayerUnitsChanged?.Invoke(newSelection);
        pathFinder.ChangeUnits(newSelection);
    }

    void OnEnable()
    {
        unitSelector.OnNewSelection += ChangeSelection;
    }

    void OnDisable()
    {
        unitSelector.OnNewSelection -= ChangeSelection;
    }
}
