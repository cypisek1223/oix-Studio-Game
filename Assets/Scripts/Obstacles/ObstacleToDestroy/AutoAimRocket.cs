using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAimRocket : MonoBehaviour
{
    public AutoAimCannon aAC;
    public float speed;
    public float lifeTime;

    void Update()
    {
        Vector3 Direction = aAC.enamy.transform.position - transform.position;
        this.transform.up = Direction;
        transform.position = Vector3.up * Time.deltaTime * speed;

        if (lifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
