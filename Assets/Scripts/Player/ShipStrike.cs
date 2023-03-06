using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipStrike : MonoBehaviour
{

    Rigidbody2D rb;
    public float shipVelocity;
    public float time=0;
    public float damegVelocity;
    public TouchController player;

    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }
    private void Update()
    {
        shipVelocity = rb.velocity.magnitude;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground"  || other.tag == "Obstacle")
        {
            ShipHit();
        }
    }
    public void ShipHit()
    {
        var Hitspeed = rb.velocity.magnitude;
        //Debug.LogError("Ship Speed" + "    " + "IF" + " " + Hitspeed);
        if (Hitspeed >= damegVelocity && time < Time.time)
        {
            float time = Time.time + 5;
            Debug.LogError("UDERZENIE Z OBRAZENIAMI");
            player.life-=1;
        }
    }
}
