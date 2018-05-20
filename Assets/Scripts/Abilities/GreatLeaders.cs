using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abilities
{
    [CreateAssetMenu(menuName = "UnitAbilities/GreatLeaders")]
    public class GreatLeaders : UnitAbility
    {
        public override void Initialize(Unit unit)
        {
            // get bonus from being in a squad with footmen
        }

        public override void Cast()
        {
            Debug.Log("great leaders");
        }
    }
}
