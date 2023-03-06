using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeIndicator : MonoBehaviour
{
    public int number;
    public Indicator indicator;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player")
        {
            indicator.numberTag = number;
            Debug.LogError("CHANGE");
        }
    }
}
