using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abilities
{
    [CreateAssetMenu(menuName = "UnitAbilities/Cleave")]
    public class Cleave : UnitAbility
    {
        public override void Initialize(Unit unit)
        {
            // so whenever the unit attacks, spread xX percent of damage in AOE
        }

        public override void Cast()
        {
            Debug.Log("cleave");
        }
    }
}