using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeObstacle : MonoBehaviour
{
    public int life;
    private void Update()
    {
        if (life <= 0)
        {
            Destroy(this.gameObject);
            Destroy(this.transform.root.gameObject);
            Debug.LogError("Zero Zycia");
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Rocket")
        {
            life--;
        }
    }
}
