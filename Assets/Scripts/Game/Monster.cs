using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    [SerializeField]
    GameConfig config;

    [SerializeField]
    private string _name;

    [SerializeField]
    Button btnSave;
    public string Name
    {
        get => _name;
        set => _name = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Velocity : " + config.velocity);
        Monster monster = new Monster();
        monster.Name = "Acd";
        Debug.Log("Name's monster :" + monster.Name);

        MM.Do += ShowMonster;
        MM.Do?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(horizontal, 0, vertical);

        transform.position = transform.position + direction * config.velocity * Time.deltaTime;
    }
    void ShowMonster()
    {
        Debug.Log("Show monster");
    }
}
