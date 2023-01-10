using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravitation : MonoBehaviour
{
    public float PullRadius;
    public float GravitationalPull;
    public float MinRadius;
    public float DistanceMultiplier;
    //public float multiplier;

    public LayerMask LayersToPull;

    void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, PullRadius, LayersToPull);

        
        foreach (var collider in colliders)
        {
           
            Rigidbody rb = collider.GetComponent<Rigidbody>();

            if (rb == null) continue; // Can only pull objects with Rigidbody

            Vector3 direction = transform.position - collider.transform.position;

            if (direction.magnitude < MinRadius) continue;

            float distance = direction.sqrMagnitude * DistanceMultiplier + 1; // The distance formula

            // Object mass also affects the gravitational pull
            rb.AddForce(direction.normalized * (GravitationalPull / distance) * rb.mass * Time.fixedDeltaTime);
        }
    }
}
