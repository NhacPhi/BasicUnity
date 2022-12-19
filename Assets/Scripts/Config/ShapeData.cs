using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/ShapeData")]
[System.Serializable]
public class ShapeData : ScriptableObject
{

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


    public int columns = 0;

    public int rows = 0;

    public RowData[] board;

    public void CreateBoard()
    {
        for(int i = 0; i < columns; i++)
        {
            board = new RowData[i];
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
