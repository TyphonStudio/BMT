using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerIdle : TowerState
{
    public TowerIdle() : base()
    {
        //
    }

    public override void Tick()
    {
        Debug.Log("idling");
    }

    public override void Exit()
    {
        //
    }
}
