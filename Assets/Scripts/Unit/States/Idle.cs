using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : UnitState
{
    public Idle(Unit unit) : base(unit)
    {
        animator.SetBool("isMoving", false);
    }

    public override void OnLeaveState()
    {
        //
    }

    public override void Tick()
    {
        CheckForEnemies();
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
