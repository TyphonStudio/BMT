using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGrid : MonoBehaviour {

    public KeyCode toggleKey;

    public Material terrainMaterial;

    bool visible;

    void ShowGrid(bool show)
    {
        if (show)
        {
            terrainMaterial.EnableKeyword("GRID_ON");
        }
        else
        {
            terrainMaterial.DisableKeyword("GRID_ON");
        }
    }

    public void ToggleShowGrid()
    {
        visible = !visible;
        ShowGrid(visible);
    }

    private void Start()
    {
        ShowGrid(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(toggleKey))
        {
            ToggleShowGrid();
        }
    }
}
