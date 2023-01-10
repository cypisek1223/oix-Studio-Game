using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rocket : MonoBehaviour
{
    public GameObject explosion;
    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.LogError("Trafione");
        if(other.tag == "Obstacle")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            //Destroy(other.gameObject);
            //Destroy(other.transform.root.gameObject);
        }

    }
}
