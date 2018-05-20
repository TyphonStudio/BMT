using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelector : Selector<Unit>
{
    public KeyCode toggleTeam;
    public int team;

    protected override void Select(Unit selectable)
    {
        if(selectable.team == team)
        {
            base.Select(selectable);
        }
    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(toggleTeam))
        {
            switch (team)
            {
                case 0:
                    team = 1;
                    break;
                case 1:
                    team = 0;
                    break;
            }
        }
    }
}