using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RocketTwo : MonoBehaviour
{
    public Transform target;
    public float speed;
    void Update()
    {
        var direction = target.position - transform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

    }
}
