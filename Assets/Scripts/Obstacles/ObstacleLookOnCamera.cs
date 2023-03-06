using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleLookOnCamera : MonoBehaviour
{
    public GameObject camera;

    void Update()
    {
        Vector3 direction = camera.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(-direction);
    }
}
