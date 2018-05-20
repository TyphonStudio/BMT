using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public HexGrid hexGrid;

    public HexCell CellUnderCursor
    {
        get
        {
            UpdateHoverCell();
            return cellUnderCursor;
        }
    }
    HexCell cellUnderCursor;

    void UpdateHoverCell()
    {
        HexCell cell =
            GetCellUnder(Input.mousePosition);
        if (cell != cellUnderCursor)
        {
            cellUnderCursor = cell;
        }
    }

    public HexCell GetCellUnder(Vector3 screenPos)
    {
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(inputRay, out hit))
        {
            return hexGrid.GetCell(hit.point);
        }
        return null;
    }
}