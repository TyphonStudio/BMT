using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitSpawner : UnitSpawner {

    public PlayerInput playerInput;
    public SpawnUnitsPanel typeSelectionPanel;

    public KeyCode spawnKey;

    private void Update()
    {
        if(Input.GetKeyDown(spawnKey))
        {
            if(typeSelectionPanel.SelectedCard != null)
                SpawnInCell(playerInput.CellUnderCursor, typeSelectionPanel.SelectedCard.Type);
        }
    }
}