using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Unit))]
public class UnitEditor : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Unit unit = (Unit)target;

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("what's your name?"))
        {
            Debug.Log(unit.name);
        }

        if (GUILayout.Button("who's your player?"))
        {
            //
        }

        GUILayout.EndHorizontal();
    }
}
