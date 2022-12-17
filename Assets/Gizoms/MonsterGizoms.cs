using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGizoms : MonoBehaviour
{
    [SerializeField]
    private float rangeOfAreaAwakeless;
    // Start is called before the first frame update
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangeOfAreaAwakeless);
    }

    private void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        //Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, rangeOfAreaAwakeless);   
    }
}
