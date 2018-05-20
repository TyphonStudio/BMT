using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PathFinder : MonoBehaviour
{
    public HexGrid hexGrid;
    public PathHighlighter pathHighlighter;
    public PathBuilder pathBuilder;

    [SerializeField]
    private bool highlightPass;
    [SerializeField]
    private bool showDistances;

    //HexCell underCursor;
    [SerializeField] PlayerInput playerInput;

    Dictionary<Unit, List<HexCell>> allThePaths = new Dictionary<Unit, List<HexCell>>();

    public void ChangeUnits(List<Unit> units)
    {
        if(allThePaths.Count > 0)
        {
            ClearAllPathsVisuals();
            UnsubscribeAllUnits();
            allThePaths.Clear();
        }

        foreach (Unit unit in units)
        {
            allThePaths.Add(unit, null);

            var traveller = unit.GetComponent<Traveller>();
            traveller.OnCurrentCellChanged += pathHighlighter.DehighlightCell;
        }
    }

    void UnsubscribeAllUnits()
    {
        foreach (var unit in allThePaths.Keys)
        {
            pathHighlighter.DehighlightCell(unit.Traveller.CurrentCell);
            unit.Traveller.OnCurrentCellChanged -= pathHighlighter.DehighlightCell;
        }
    }

    void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(1))
            {
                MoveAll();
            }
            else
            {
                DoPathFinding();
            }
        }
    }

    void MoveAll()
    {
        ClearAllPathsVisuals();

        foreach (Unit unit in allThePaths.Keys)
        {
            if (allThePaths[unit] != null && allThePaths[unit].Count > 0)
                //unit.PathTraveller.TravelNewPath(allThePaths[unit]);
                unit.Move(allThePaths[unit]);
        }
    }

    void DoPathFinding()
    {
        //UpdateHoverCell();

        ClearAllPathsVisuals();

        if (playerInput.CellUnderCursor)
        {
            FindPathForAll();
        }

    }

    void ClearAllPathsVisuals()
    {
        foreach (Unit unit in allThePaths.Keys)
        {
            ClearPathLabels(allThePaths[unit]);
            pathHighlighter.DehighlightCell(unit.Traveller.CurrentCell);
        }
    }

    void ClearPathLabels(List<HexCell> path)
    {
        if (path == null)
        {
            //Debug.Log("no path to clear visuals");
        }
        else
        {
            for (int i = 0; i < path.Count; i++)
            {
                path[i].SetLabel(null);
                path[i].DisableHighlight();
            }
        }
    }

    void FindPathForAll()
    {
        List<Unit> keys = new List<Unit>(allThePaths.Keys);

        foreach (Unit unit in keys)
        {
            //pathHighlighter.HighlightTravellerCell(traveller);

            bool pathExists = hexGrid.Search(unit.Traveller.CurrentCell, playerInput.CellUnderCursor);

            if (pathExists)
            {
                var path = allThePaths[unit] = pathBuilder.BuildPath(unit.Traveller.CurrentCell, playerInput.CellUnderCursor, showDistances);
                if(highlightPass) pathHighlighter.HighlightPath(path);
                pathHighlighter.HighlightCell(unit.Traveller.CurrentCell, Color.blue);
            }
        }
    }
}