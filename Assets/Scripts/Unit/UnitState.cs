using UnityEngine;

public abstract class UnitState
{
    protected Unit unit;
    protected Animator animator;

    public abstract void Tick();
    public abstract void OnLeaveState();

    public UnitState(Unit unit)
    {
        this.unit = unit;
        animator = unit.GetComponentInChildren<Animator>();
    }
}