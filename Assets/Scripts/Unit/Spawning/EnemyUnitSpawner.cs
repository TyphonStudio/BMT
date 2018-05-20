using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnitSpawner : UnitSpawner, IHaveCell {

    public HexGrid hexGrid;
    public UnitType defaultType;

    public bool isSpawning;

    public float spawnTimer;
    float timeLeft;

    public HexCell CurrentCell
    {
        get
        {
            return hexGrid.GetCell(transform.position);
        }
    }

    private void Start()
    {
        timeLeft = spawnTimer;
    }

    public void Update()
    {
        if(isSpawning)
        {
            timeLeft -= Time.deltaTime;
            if(timeLeft <= 0)
            {
                SpawnInCell(CurrentCell, defaultType);
                timeLeft = spawnTimer;
            }
        }
    }
}