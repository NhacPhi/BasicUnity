using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Monster))]
public class MonstorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Monster monster = (Monster)target;
        // add before
        base.OnInspectorGUI();
        // add after

        EditorGUILayout.LabelField("---------------------------------------------------");
    }
}
