using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Abilities;

public class AbilityCard : MonoBehaviour {

    public Image icon;

    public TextMeshProUGUI nameText;

    public void Init(UnitAbility ability)
    {
        icon.sprite = ability.aIcon;

        nameText.text = ability.name;
    }
}