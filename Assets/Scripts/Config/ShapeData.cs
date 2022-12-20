using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ShapeType
{
    Cube,
    Sphere,
    Cylinder,
    Polygon
}
[CreateAssetMenu(menuName = "Data/ShapeData")]
[System.Serializable]
public class ShapeData : ScriptableObject
{
    // Testing
    [SerializeField]
    private float velocity;

    [SerializeField]
    private bool canEditProperties = true;

    [SerializeField]
    private ShapeType shapeTypeObject;

    public float Velocity
    {
        get => velocity;
        private set => velocity = value;
    }
    public bool CanEditProperties
    {
        get => canEditProperties;
        private set => canEditProperties = value;
    }

    public ShapeType ShapeTypeObject
    {
        get => shapeTypeObject;
        set => shapeTypeObject = value;
    }
    // Editor script

    [System.Serializable]
    public class RowData
    {
        public bool[] rows;
        private int size;



        RowData() { }

        public RowData(int size)
        {
            CreateRowData(size);
        }

        public void CreateRowData(int size)
        {
            // setting size matrix
            this.size = size;
            rows = new bool[size];
            ClearRowData();
        }

        public void ClearRowData()
        {
            for(int i = 1; i < size; i++)
            {
                rows[i] = false;
            }
        }
    }

    [SerializeField]
    private int columns = 0;

    [SerializeField]
    private int rows = 0;

    [SerializeField]
    public RowData[] board;

    public int Columns
    {
        get => columns;
        private set => columns = value;
    }

    public int Rows
    {
        get => rows;
        set => rows = value;
    }


    public void CreateBoard()
    {
        board = new RowData[columns];
        for(int i = 0; i < columns; i++)
        {
            board[i] = new RowData(rows);
        }
    }

    public void ClearBoard()
    {
        for(int i = 0; i < columns; i++)
        {
            board[i].ClearRowData(); 
        }
    }
}
