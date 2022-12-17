using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterType
{
    None = 0,
    Dragon,
    Ghost,
    Phamtom
}

public class GameAtributes : MonoBehaviour
{
    // Atributes
    [Header("Game stats")]
    [SerializeField]
    private int index = 0;
    [ContextMenuItem("Load Level 1", "SettingDefault")]
    [ContextMenuItem("Load Level 2", "SettingDefault")]
    [Multiline]
    public string levelName;
    [ContextMenu("Load Level - Context Menu")]
    void SettingDefault()
    {
        index = 1;
        Debug.Log("Index :" + index);
    }

    [Space(10)]
    [Header("Game reference")]
    [SerializeField]
    private GameObject target;
    [SerializeField][Range(0,100)]
    private int number;

    [SerializeField]
    private Color color;

    [SerializeField]
    private MonsterType monsterType;
    [SerializeField][TextArea]
    private string textArea;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
