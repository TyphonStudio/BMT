using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerState
{
    public abstract void Tick();
    public abstract void Exit();

    public TowerState()
    {

    }
}
