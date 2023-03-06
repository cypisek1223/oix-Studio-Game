using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rocket : MonoBehaviour
{
    public float rocketSpeed;
    public GameObject explosion;
    public void Update()
    {
        this.GetComponent<Rigidbody2D>().AddForce(transform.up * (rocketSpeed+GameManager.instance.touchController.playerVelocity));
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.LogError("Trafione");
        if(other.tag == "Obstacle")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            Destroy(other.transform.root.gameObject);
            //Destroy(other.gameObject);
            //Destroy(other.transform.root.gameObject);
        }

    }
}
