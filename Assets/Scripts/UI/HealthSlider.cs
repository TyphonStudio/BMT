using UnityEngine;

public class HealthSlider : Slider {

    [SerializeField] protected Transform transformToFollow;
    [SerializeField] private Vector3 worldOffset;

    public void AssignToUnit(Unit unit)
    {
        transformToFollow = unit.transform;
        MatchUnitPosition();
        unit.healthSlider = this;

        unit.onStatsChanged += DeployStats;
    }

    private void Update()
    {
        if (transformToFollow)
            MatchUnitPosition();
    }

    void MatchUnitPosition()
    {   
        transform.position = Camera.main.WorldToScreenPoint(transformToFollow.position + worldOffset);
    }

    void DeployStats(UnitStats stats)
    {
        SetSlider(stats.Health / stats.MaxHealth);
    }
}