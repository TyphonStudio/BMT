using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHaveStats
{
    UnitStats Stats { get; }

    float ModifyHealth(float amount);
}