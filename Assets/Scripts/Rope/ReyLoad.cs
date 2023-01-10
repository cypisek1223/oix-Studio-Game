using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReyLoad : MonoBehaviour
{
    public Transform load;
    void Update()
    {
        transform.position = load.transform.position;
    }
}
