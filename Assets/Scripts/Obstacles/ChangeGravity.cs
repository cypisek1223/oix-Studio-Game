using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGravity : MonoBehaviour
{
    public GameObject Player;
    public Rigidbody rb;
    public float gravityForceUp;
    public float masa;
    private void Start()
    {
        rb = Player.GetComponent<Rigidbody>();
    }
    public void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.LogError("In Area");
            rb.useGravity = false;
            rb.AddForce(transform.up * gravityForceUp * rb.mass);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.LogError("Outside the area");
            rb.useGravity = true;
        }
    }
}
