using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesInput : MonoBehaviour
{
    AbilitiesPanel abilitiesPanel;
    public SelectedUnitsPanel selectedUnitsPanel;

    public List<KeyCode> allHotkeys;
    public int availableHotkeys = 0;

    private void Awake()
    {
        abilitiesPanel = GetComponent<AbilitiesPanel>();

        selectedUnitsPanel.OnNewFocus += UnlockHotkeys;
        selectedUnitsPanel.OnLoseFocus += LockAllHotkeys;
    }

    private void LockAllHotkeys()
    {
        //
    }

    void UnlockHotkeys(Unit unit)
    {
        for (int i = 0; i < unit.Type.defaultAbilities.Count; i++)
        {
            availableHotkeys = unit.Type.defaultAbilities.Count;
        }
    }

    private void Update()
    {
        if (availableHotkeys == 0)
            return;
        else
        {
            for (int i = 0; i < availableHotkeys; i++)
            {
                if (Input.GetKeyDown(allHotkeys[i]))
                {
                    if (abilitiesPanel.showForUnit != null)
                    {
                        var abilities = abilitiesPanel.showForUnit.Type.defaultAbilities;

                        if(abilities.Count > 0 && abilities[i].isActive)

                        {
                            abilitiesPanel.showForUnit.Type.defaultAbilities[i].Cast();
                        }
                    }
                }
            }
        }
    }
}
