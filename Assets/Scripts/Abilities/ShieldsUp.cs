using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abilities
{
    [CreateAssetMenu(menuName = "UnitAbilities/ShieldsUp")]
    public class ShieldsUp : UnitAbility
    {
        public override void Initialize(Unit unit)
        {
            // whenever the unit performs an attack, apply it in aoe too?
        }

        public override void Cast()
        {
            //
        }
    }
}