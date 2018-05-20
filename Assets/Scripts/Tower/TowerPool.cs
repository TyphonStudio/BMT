using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPool : MyPool {

    public static TowerPool Instance { get; private set; }

    protected override void Awake()
    {
        Instance = this;
        base.Awake();
    }
}
