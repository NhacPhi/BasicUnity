using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBetweenPoints : MonoBehaviour
{
    [SerializeField]
    private Color color;
    [SerializeField]
    private Transform[] patrolPoints;
    // Start is called before the first frame update


    private void OnDrawGizmos()
    {
        DrawPoints();
        DrawPaths();
    }

    void DrawPoints()
    {
        Gizmos.color = color;

        foreach (Transform point in patrolPoints)
        {
            Gizmos.DrawSphere(point.position, 0.3f);

        }
    }

    void DrawPaths()
    {
        Gizmos.color = color;

        for(int i = 0; i < patrolPoints.Length - 1; i++)
        {
            Vector3 pos1 = patrolPoints[i].position;
            Vector3 pos2 = patrolPoints[i + 1].position;
            Gizmos.DrawLine(pos1,pos2);
        }
    }
}
