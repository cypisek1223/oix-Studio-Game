using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    public Vector3 startPosition;
    public Rigidbody rb;
    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }
    public void Update()
    {
        if (BeeHive.inst.vision)
        {
            transform.up = GameManager.instance.touchController.transform.position - transform.position;
            rb.AddForce(transform.up * speed * 2);
        }
        else
        {
            transform.up = startPosition - transform.position;
            rb.AddForce(transform.up * speed);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        
    }
}
