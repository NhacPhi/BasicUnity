using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ShapeData))]
[System.Serializable]
[CanEditMultipleObjects]
public class ShapeDatadraw : Editor
{
    private ShapeData ShapeDataInstacnce => target as ShapeData;
    public override void OnInspectorGUI()
    {

        EditorGUILayout.LabelField(ShapeDataInstacnce.name, EditorStyles.boldLabel);
        EditorGUILayout.Space(5);

        // Custom all inspector view
        base.OnInspectorGUI();

        ProgressBar(0.5f, "Difficulty");

        // Help box
        if(ShapeDataInstacnce.columns == 0 && ShapeDataInstacnce.rows == 0)
        {
            EditorGUILayout.HelpBox("No data", MessageType.Warning);
        }
    }

    //Draw ProgressBar(
    void ProgressBar(float value, string lable)
    {
        // Create rect component
        Rect rect = GUILayoutUtility.GetRect(18, 18, "TextField");
        EditorGUI.ProgressBar(rect, value, lable);
        EditorGUILayout.Space(2);
;    }
}
