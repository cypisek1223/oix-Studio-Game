using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    public GameObject[] target;

    public int numberTag=0;
    public float speed;
    void Update()
    {
        Vector2 Direction = target[numberTag].transform.position - transform.position;
        transform.up = Direction;
    }
}
