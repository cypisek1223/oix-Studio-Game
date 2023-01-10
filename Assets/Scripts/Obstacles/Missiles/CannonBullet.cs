using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBullet : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    void Update()
    {
        rb.AddForce(-transform.up * speed);
    }
}
