using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Optimizers : MonoBehaviour {

    [MenuItem("Optimizers/Disable Navigation for all buttons")]
    static void DisableNavForAllButtons()
    {
        var allButtons = Resources.FindObjectsOfTypeAll<Button>();
        Navigation noNav = new Navigation();

        foreach (Button button in allButtons)
        {
            if (button.navigation.mode != Navigation.Mode.None)
            {
                noNav.mode = Navigation.Mode.None;
                button.navigation = noNav;
            }
        }
    }
}
