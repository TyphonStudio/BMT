using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour {

    [SerializeField] private PlayerInput pi;
    [SerializeField] private Timer timer;

    public void SpawnInCell(HexCell cell)
    {
        var towerObject = TowerPool.Instance.GetFromPool();
        towerObject.transform.position = cell.Position;
    }

    void SpawnInCellUnderCursor()
    {
        SpawnInCell(pi.CellUnderCursor);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftShift))
        {
            SpawnInCellUnderCursor();
        }
    }
}