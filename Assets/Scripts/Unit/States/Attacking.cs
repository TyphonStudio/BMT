using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : UnitState
{
    Unit myTarget;

    float attackCooldown;
    float timeBeforeAttack;

    public Attacking(Unit self, Unit target) : base(self)
    {
        myTarget = target;
        animator.SetBool("isAttacking", true);

        attackCooldown = unit.Stats.AttackCooldown;
        timeBeforeAttack = attackCooldown;
    }

    public override void OnLeaveState()
    {
        animator.SetBool("isAttacking", false);
    }

    public override void Tick()
    {
        if(myTarget != null)
        {
            timeBeforeAttack -= Time.deltaTime;

            if (timeBeforeAttack <= 0)
            {
                PerformAttack();
            }
        }
        else
        {
            unit.Stop();
        } 
    }

    void PerformAttack()
    {
        timeBeforeAttack = attackCooldown;
        myTarget.ModifyHealth(unit.Stats.Damage);
    }
}