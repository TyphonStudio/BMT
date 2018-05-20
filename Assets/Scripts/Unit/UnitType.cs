using UnityEngine;
//using UnityEditor.Animations;
using System.Collections.Generic;
using Abilities;

[CreateAssetMenu(menuName = "Unit/UnitType")]
public class UnitType : ScriptableObject {

    public AnimatorOverrideController animatorOverride;

    public Sprite icon;
    public UnitStats defaultStats;
    public List<UnitAbility> defaultAbilities;
}