using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MM : MonoBehaviour
{
    public delegate void GetDelegate(string name);
    public delegate int Square(int x);
    public delegate int DelegateCa(int x, int y);
    public static Action Do;
    private string _name;
    public string Name => _name;

    [SerializeField]
    private ShapeData shapeData;

    int Add(int x, int y)
    {
        return x + y;
    }

    int Sub(int x, int y)
    {
        return x - y;
    }
    // Start is called before the first frame update
    void Start()
    {
        Monster monster = new Monster();
        monster.Name = "Abc";
        DelegateCa delegateCa = (int x, int y) => { return x + y; };
        //delegateCa = Sub;
        //Action<string> Doit = (string x)=> { Debug.Log("String :" + x); };

        //int amout = delegateCa.Invoke(1, 2);

        Debug.Log("Columns shapeData : " + shapeData.Columns);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowLog()
    {
        Debug.Log("Show log");
    }

}
