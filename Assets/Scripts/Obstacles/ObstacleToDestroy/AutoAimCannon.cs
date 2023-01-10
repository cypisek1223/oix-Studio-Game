using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAimCannon : MonoBehaviour
{
    public GameObject enamy;
    public GameObject autoAimRockets;
    public Transform shotPoint;

    public float TIME = 0;
    public float couldown;
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            enamy = other.gameObject;
            if (TIME >= Time.time)
            {
                TIME = Time.time + couldown;
                Instantiate(autoAimRockets, shotPoint.position, shotPoint.rotation);
            }            
        }
    }
}
