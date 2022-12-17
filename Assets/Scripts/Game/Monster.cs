using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    GameConfig config;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Velocity : " + config.velocity);
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(horizontal, 0, vertical);

        transform.position = transform.position + direction * config.velocity * Time.deltaTime;
    }
}
