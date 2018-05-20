using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSliderCreator : MonoBehaviour {

    [SerializeField] private GameObject sliderPrefab;

    public Color[] teamColors;

    public void CreateSliderFor(Unit unit)
    {
        HealthSlider slider = Instantiate(sliderPrefab, transform).GetComponent<HealthSlider>();
        slider.AssignToUnit(unit);
        slider.SetColor(teamColors[unit.team]);
    }
}