using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropHandler : MonoBehaviour, IDropHandler
{
    public PlayerInput playerInput;
    public PlayerUnitSpawner playerUnitSpawner;

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            var cell = playerInput.GetCellUnder(Input.mousePosition);
            var type = eventData.pointerDrag.GetComponent<UnitTypeCard>().Type;

            if (cell != null)
            {
                playerUnitSpawner.SpawnInCell(cell, type);
            }
        }
    }
}