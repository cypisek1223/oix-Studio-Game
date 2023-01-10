using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEngine : MonoBehaviour
{
    Rigidbody rb;

    public float verticalPower = 10;
    public float sidePower = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector3.up * Input.GetAxis("Vertical") *  verticalPower);

        rb.AddForce(Vector3.right * Input.GetAxisRaw("Horizontal") * sidePower);
    }
}
