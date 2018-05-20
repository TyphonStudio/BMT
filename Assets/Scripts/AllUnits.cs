using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AllUnits : MonoBehaviour {

    public static AllUnits Instance { get; private set; }

    public List<Unit> allUnits;
    private List<Unit> currentSuspects;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        allUnits = new List<Unit>();
    }

    public void Add(Unit unit)
    {
        if(!allUnits.Contains(unit))
        {
            allUnits.Add(unit);
            unit.transform.SetParent(transform);
            unit.deathAction += Remove;
        }
    }

    public void Remove(Unit unit)
    {
        if(allUnits.Contains(unit))
        {
            allUnits.Remove(unit);
        }
    }

    public Unit ClosestEnemyInRange(Unit unit, float range)
    {
        currentSuspects = new List<Unit>(allUnits);
        currentSuspects.Remove(unit);
        currentSuspects.RemoveAll(item => item.team == unit.team);
        if (currentSuspects.Count > 0)
        {
            var closest = currentSuspects.OrderBy(t => (t.transform.position - unit.transform.position).sqrMagnitude).First();

            if ((closest.transform.position - unit.transform.position).magnitude < range)
                return closest;
        }

        return null;
    }
}
