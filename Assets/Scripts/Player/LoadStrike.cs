using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadStrike : MonoBehaviour
{
    GameManager instancja;
    public Rigidbody rb;
    public float loadVelocity;
    public float maxStrike=10;
    public RopeHook ropeHook;
    void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
    }
    private void Update()
    {
        loadVelocity = rb.velocity.magnitude;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            LoadHit();
            //GameManager.instancja.
        }
    }
    public void LoadHit()
    {
        var Hitspeed = rb.velocity.magnitude;
        Debug.LogError("Load Speed" + "    " + "IF" + " " + Hitspeed);
    }
}
