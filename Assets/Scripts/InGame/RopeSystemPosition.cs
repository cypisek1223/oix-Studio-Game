using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSystemPosition : MonoBehaviour
{
    public GameObject ropeSystem;
    public Transform positionRopeSystem;
    void Update()
    {
        ropeSystem.transform.position = new Vector3(positionRopeSystem.position.x, positionRopeSystem.position.y, positionRopeSystem.position.z);
    }
}