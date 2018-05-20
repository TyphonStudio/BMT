using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abilities
{
    public abstract class UnitAbility : ScriptableObject
    {
        public string aDescription = "description";
        public Sprite aIcon;

        public bool isActive;

        public abstract void Initialize(Unit unit);
        public abstract void Cast();
    }
}
