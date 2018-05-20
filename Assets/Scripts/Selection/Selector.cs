using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Selector<T> : MonoBehaviour where T : Component, ISelectable
{
    public Camera selectionCamera;
    public LayerMask selectionLayer;

    [SerializeField]
    [Range(1, 5)]
    int borderThickness;
    [SerializeField]
    Color borderColor;
    [SerializeField]
    Color boxColor;

    public GameObject selectionCirclePrefab;

    Vector3 dragOrigin = Vector3.zero;

    [SerializeField]
    float dragTreshold;
    [SerializeField]
    float dragDistance;

    [SerializeField]
    bool isDragging;

    [SerializeField]
    List<T> selectedObjects = new List<T>();

    public delegate void NewSelectionAciton(List<T> selectedObjects);
    public event NewSelectionAciton OnNewSelection;

    void Awake()
    {
        if (!selectionCamera)
            selectionCamera = Camera.main;
    }

    protected virtual void Update()
    {

        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            ClearCurrentSelection();

            dragOrigin = Input.mousePosition;
        }

        if (Input.GetMouseButton(0) && dragOrigin.magnitude > 0)
        {
            dragDistance = (Input.mousePosition - dragOrigin).magnitude;
            if (dragDistance >= dragTreshold)
            {
                isDragging = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (isDragging)
            {
                SelectAllInBounds();
            }
            else
            {
                SelectOneUnder(Input.mousePosition);
            }

            isDragging = false;
            dragOrigin = Vector3.zero;
        }
    }

    T GetComponentUnder(Vector3 screenPoint)
    {
        Ray ray = selectionCamera.ScreenPointToRay(screenPoint);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, selectionLayer))
        {
            T component = (T)hit.transform.GetComponent(typeof(T));
            if (component != null)
            {
                return component;
            }
        }
        return null;
    }

    void ClearCurrentSelection()
    {
        foreach (T selectableObject in FindObjectsOfType<T>())
        {
            Dehighlight(selectableObject);
        }

        selectedObjects.Clear();
    }

    void SelectOneUnder(Vector3 screenPos)
    {
        var selectableObject = GetComponentUnder(screenPos);
        if (selectableObject != null)
        {
            Select(selectableObject);
        }

        OnNewSelection?.Invoke(selectedObjects);
    }

    void SelectAllInBounds()
    {
        foreach (T selectableObject in FindObjectsOfType<T>())
        {
            if (IsWithinSelectionBounds(selectableObject.gameObject))
            {
                Select(selectableObject);
            }
        }

        OnNewSelection?.Invoke(selectedObjects);
    }

    protected virtual void Select(T selectable)
    {
        selectedObjects.Add(selectable);
        Highlight(selectable);
    }

    void CreateSelectionCircle(T selectableObject)
    {
        selectableObject.SelectionCircle = Instantiate(selectionCirclePrefab);
        selectableObject.SelectionCircle.transform.SetParent(selectableObject.transform, false);
    }

    void Highlight(T selectable)
    {
        if (selectable.SelectionCircle == null)
        {
            CreateSelectionCircle(selectable);
        }
    }

    void Dehighlight(T selectable)
    {
        if (selectable.SelectionCircle != null)
        {
            Destroy(selectable.SelectionCircle.gameObject);
            selectable.SelectionCircle = null;
        }
    }

    void OnGUI()
    {
        if (isDragging)
        {
            var rect = UtilitiesGUI.GetScreenRect(dragOrigin, Input.mousePosition);
            UtilitiesGUI.DrawScreenRect(rect, boxColor);
            UtilitiesGUI.DrawScreenRectBorder(rect, borderThickness, borderColor);
        }
    }

    public bool IsWithinSelectionBounds(GameObject gameObject)
    {
        var viewportBounds = UtilitiesGUI.GetViewportBounds(selectionCamera, dragOrigin, Input.mousePosition);

        return viewportBounds.Contains(selectionCamera.WorldToViewportPoint(gameObject.transform.position));
    }
}