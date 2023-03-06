using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public ParticleSystem coinExplosion;
    public void Update()
    {
        //transform.Rotate(0, 5, 0, 0);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Instantiate(coinExplosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            GameManager.instance.point++;
        }
    }
}
