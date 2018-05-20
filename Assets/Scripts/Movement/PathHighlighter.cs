using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Movement/PathHighlighter")]
public class PathHighlighter : ScriptableObject
{
    public void HighlightPath(List<HexCell> path)
    {
        foreach (HexCell cell in path)
        {
            cell.EnableHighlight(Color.white);
        }
    }

    public void HighlightCell(HexCell cell, Color color)
    {
        cell.EnableHighlight(color);
    }

    public void DehighlightCell(HexCell cell)
    {
        if (cell)
            cell.DisableHighlight();
    }
}
