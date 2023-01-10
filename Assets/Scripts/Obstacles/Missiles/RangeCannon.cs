using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeCannon : MonoBehaviour
{


    public float meshResolution;
    public float viewAngle;
    public float viewRadius;

    void DrowFieldOfViev()
    {
        int stepCount = Mathf.RoundToInt(viewAngle * meshResolution);
        float stepAngleSize = viewAngle / stepCount;
    
        for(int i=0; i <= stepCount; i++)
        {
            float angle = transform.eulerAngles.y - viewAngle / 2 + stepAngleSize * i;
            //Debug.DrawLine(transform.position, transform.position + DirFromAngle(angle, true) * viewRadius, Color.red);
        }
    }
    //public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    //{
    //    if (!angleIsGlobal)
    //    {
    //        angleInDegrees += transform.eulerAngles.y;
    //    }
    //}
}
