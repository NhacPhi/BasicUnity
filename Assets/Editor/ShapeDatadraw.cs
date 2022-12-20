using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ShapeData))]
[System.Serializable]
[CanEditMultipleObjects]
public class ShapeDatadraw : Editor
{
    [Tooltip("Enable edit properties of ShapeData")]
    private SerializedProperty canEditProperties;
    private SerializedProperty velocity;
    private SerializedProperty shapeTypeObject;

    private SerializedProperty columns;
    private SerializedProperty rows;


    private void OnEnable()
    {
        canEditProperties = serializedObject.FindProperty("canEditProperties");
        velocity = serializedObject.FindProperty("velocity");
        shapeTypeObject = serializedObject.FindProperty("shapeTypeObject");

        columns = serializedObject.FindProperty("columns");
        rows = serializedObject.FindProperty("rows");
    }
    private ShapeData ShapeDataInstacnce => target as ShapeData;
    public override void OnInspectorGUI()
    {
        serializedObject.Update();


        // Custom all inspector view
        //base.OnInspectorGUI();

        ProgressBar(0.5f, "Difficulty");

        EditorGUILayout.PropertyField(canEditProperties, new GUIContent("Can Edit Properties"));
        if (canEditProperties.boolValue)
        {
            EditorGUI.indentLevel += 2;
            EditorGUILayout.LabelField(ShapeDataInstacnce.name, EditorStyles.boldLabel);
            EditorGUILayout.Space(5);
            EditorGUILayout.LabelField("Velocity");
            velocity.floatValue = EditorGUILayout.Slider(velocity.floatValue, 0, 100);
            EditorGUILayout.Space(5);
            EditorGUI.indentLevel -= 2;
        }

        EditorGUILayout.Space(20);
        EditorGUILayout.PrefixLabel("Stats", EditorStyles.boldLabel);


        //EditorGUILayout.IntField("Columns ",columns.intValue);

        DrawInputField();

        //Draw input table
        if(ShapeDataInstacnce.board != null && ShapeDataInstacnce.Rows > 0 && ShapeDataInstacnce.Columns > 0)
        {
            DrawBoardTable();
        }


        // Button reset
        if (GUILayout.Button("Reset Board"))
        {
            // Do somthing when press button.
            columns.intValue = 0;
            rows.intValue = 0;
        }

        // check condition to create board
        if (columns.intValue <= 0 && rows.intValue <= 0)
        {
            EditorGUILayout.HelpBox("Error data", MessageType.Warning);
        }


        // Save data and change UI
        serializedObject.ApplyModifiedProperties();
        if (GUI.changed)
        {
            Debug.Log("Save data");
            EditorUtility.SetDirty(ShapeDataInstacnce);
        }
    }

    //Draw ProgressBar(
    void ProgressBar(float value, string lable)
    {
        // Create rect component
        Rect rect = GUILayoutUtility.GetRect(18, 18, "TextField");
        EditorGUI.ProgressBar(rect, value, lable);
        EditorGUILayout.Space(2);
    }
    void DrawInputField()
    {
        EditorGUILayout.PropertyField(columns, new GUIContent("Columns"));

        EditorGUILayout.PropertyField(rows, new GUIContent("Rows"));

        int columnsTemp = ShapeDataInstacnce.Columns;
        int rowsTemp = ShapeDataInstacnce.Rows;

        if ((ShapeDataInstacnce.Columns != columnsTemp || ShapeDataInstacnce.Rows != rowsTemp) && ShapeDataInstacnce.Rows > 0 && ShapeDataInstacnce.Columns > 0)
        {
            ShapeDataInstacnce.CreateBoard();
            Debug.Log("Create board");
        }


    }
    void DrawBoardTable()
    {
        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField("Config shapeData ", EditorStyles.boldLabel);

        var tableStyle = new GUIStyle("box");
        tableStyle.padding = new RectOffset(10, 10, 10, 10);
        tableStyle.margin.left = 32;

        var headerColumnStyle = new GUIStyle();
        headerColumnStyle.fixedWidth = 65;
        headerColumnStyle.alignment = TextAnchor.MiddleCenter;

        var rowStyle = new GUIStyle();
        rowStyle.fixedHeight = 25;
        rowStyle.alignment = TextAnchor.MiddleCenter;

        var dataFieldStyle = new GUIStyle(EditorStyles.miniButtonMid);
        dataFieldStyle.normal.background = Texture2D.grayTexture;
        dataFieldStyle.onNormal.background = Texture2D.whiteTexture;

        for (int row = 0; row < ShapeDataInstacnce.Rows; row++)
        {
            EditorGUILayout.BeginHorizontal(headerColumnStyle);

            for (int column = 0; column < ShapeDataInstacnce.Columns; column++)
            {
                EditorGUILayout.BeginHorizontal(rowStyle);
                var data = EditorGUILayout.Toggle(ShapeDataInstacnce.board[column].rows[row], dataFieldStyle);
                ShapeDataInstacnce.board[column].rows[row] = data;
                //Debug.Log("Data  " + columns + "  " + rows + " = " + ShapeDataInstacnce.board[column].rows[row]);
                EditorGUILayout.EndHorizontal();
            }

            EditorGUILayout.EndHorizontal();
        }
    }
}
