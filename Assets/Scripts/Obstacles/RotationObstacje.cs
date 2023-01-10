using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObstacje : MonoBehaviour
{
    public float rotationX;
    public float rotationY;
    public float rotationZ;

    void Update()
    {
        transform.Rotate(new Vector3(rotationX, rotationY, rotationZ) * Time.deltaTime);
    }
}
