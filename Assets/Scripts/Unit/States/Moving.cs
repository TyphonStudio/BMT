using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : UnitState
{
    public Moving(Unit unit, List<HexCell> pathToTravel) : base(unit)
    {
        Vector3Path vectorPath = Vector3Path.CreateFromHexPath(pathToTravel);

        unit.Traveller.TravelVectorPath(vectorPath);
        unit.Traveller.OnTravelOver += unit.Stop;

        CheckForSpriteFlip(unit, pathToTravel[pathToTravel.Count - 1].Position);
        animator.SetBool("isMoving", true);
    }

    public override void OnLeaveState()
    {
        
    }

    public override void Tick()
    {
        unit.Traveller.Step();
        CheckForEnemies();
    }

    void CheckForSpriteFlip(Unit unit, Vector3 destination)
    {
        if(unit.transform.position.x > destination.x)
        {
            unit.ToggleFlip(true);
        }
        else {
            unit.ToggleFlip(false);
        }
    }

    void CheckForEnemies()
    {
        var enemyInAttackRange = AllUnits.Instance.ClosestEnemyInRange(unit, unit.attackInRange);
        if (enemyInAttackRange != null)
        {
            unit.Attack(enemyInAttackRange);
        }
    }
}