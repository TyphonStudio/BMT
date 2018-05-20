using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Movement/PathBuilder")]
public class PathBuilder : ScriptableObject
{
    public PathHighlighter pathHiglighter;

    public List<HexCell> BuildPath(HexCell from, HexCell to, bool showDistances)
    {
        List<HexCell> path = new List<HexCell>();

        HexCell current = to;
        while (current != from)
        {
            if (showDistances)
                current.SetLabel(current.Distance.ToString());
            //current.EnableHighlight(Color.white);
            path.Add(current);
            current = current.PathFrom;
        }
        path.Reverse();

        return path;
    }
}