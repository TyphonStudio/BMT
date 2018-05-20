using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Combat/AttackProcessor")]
public class AttackProcessor : ScriptableObject
{
    public void ProcessAttack(IHaveStats target, int amount)
    {
        target.ModifyHealth(amount);
    }
}