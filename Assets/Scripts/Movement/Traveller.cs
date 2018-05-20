using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traveller : MonoBehaviour
{
    public HexGrid hexGrid;

    public float travelSpeed;
    public float TravelSpeed
    {
        get
        {
            return travelSpeed;
        }

        set
        {
            travelSpeed = value;
            if (travelSpeed < 0)
                travelSpeed = 0;
        }
    }

    //public List<HexCell> currentPath;

    public delegate void CurrentCellChangedAction(HexCell previousCell);
    public event CurrentCellChangedAction OnCurrentCellChanged;

    public delegate void TravellingOverAction();
    public event TravellingOverAction OnTravelOver;

    public HexCell CurrentCell
    {
        get;
        private set;
    }

    public void SetCurrentCell(HexCell value)
    {
        if (CurrentCell != value)
        {
            var previousCell = CurrentCell;
            if (previousCell != null)
                previousCell.TerrainType.OnExit(this);

            CurrentCell = value;
            CurrentCell.TerrainType.OnEnter(this);
            OnCurrentCellChanged?.Invoke(previousCell);
        }
    }

    void Awake()
    {
        hexGrid = FindObjectOfType<HexGrid>();
    }

    void Start()
    {
        ValidateCurrentCell();
    }

    void ValidateCurrentCell()
    {
        var cellUnder = hexGrid.GetCell(transform.position);
        if (CurrentCell != cellUnder)
        {
            SetCurrentCell(cellUnder);
        }
    }

    public void TravelVectorPath(Vector3Path pathToTravel)
    {
        path = pathToTravel;
        currentWayPointID = 0;
    }

    public Vector3Path path;

    public int currentWayPointID = 0;
    public float rotationSpeed;
    private float reachDistance = 1.0f;

    public void Step()
    {
        ValidateCurrentCell();

        if (path == null || path.points.Count == 0)
            return;

        float distance = Vector3.Distance(path.points[currentWayPointID], transform.position);
        transform.position = Vector3.MoveTowards(transform.position, path.points[currentWayPointID], Time.deltaTime * TravelSpeed);

        // rotation?
        //var rotation = Quaternion.LookRotation(path.points[currentWayPointID] - transform.position);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);

        if (distance <= reachDistance)
        {
            currentWayPointID++;
        }

        if (currentWayPointID >= path.points.Count)
        {
            path = null;
            currentWayPointID = 0;
            OnTravelOver?.Invoke();
        }
    }
}