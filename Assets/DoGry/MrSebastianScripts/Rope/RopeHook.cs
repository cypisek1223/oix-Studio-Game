using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeHook : MonoBehaviour
{
    public LayerMask pickup_layer;

    public GameObject hook;
    public Rigidbody2D pickup;
    public Rigidbody2D rb;
    
    public bool drop = false;   
    public bool grasp = false;
    public float timer = 0;
    public float realyTime;
    public float couldow;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
     
        realyTime = Time.time;
        if (drop)
        {
            timer = Time.time + couldow;
            Debug.Log("DROP");
            Destroy(hook.GetComponent<FixedJoint2D>());
            grasp = false;
            pickup = null;
            drop = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.LogError("Dotyka OBJ: "+other.tag);
        if (other.tag == "Load" && timer < realyTime)// && !pickup
        {
            Debug.LogError("Chack Load");
            grasp = true;
            pickup = other.gameObject.GetComponent<Rigidbody2D>();
            //(other.gameObject.AddComponent(typeof(FixedJoint)) as FixedJoint).connectedBody = rb;
            hook.AddComponent<FixedJoint2D>().connectedBody = pickup;         
            //pickup.transform.localScale = Vector3.one;
        }
    }
}
