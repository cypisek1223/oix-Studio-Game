using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    
    public Rigidbody rb;
    public Vector3 DirectionShot;

    public float speed;
    public float LifeTime=5;
    public float addTime;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        addTime = Time.time + LifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.up = GameManager.instance.touchController.transform.position - transform.position;
        rb.AddForce(transform.up * speed);
        if (Time.time >= addTime)
        {          
            Destroy(this.gameObject);
        }
    }
}
