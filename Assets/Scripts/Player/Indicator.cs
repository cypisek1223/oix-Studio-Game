using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    public GameObject[] target;
    public SpriteRenderer indicatorSprite;
    public int numberTag=0;
    public float speed;
    public float distance;
    void Update()
    {
        distance = Vector2.Distance(target[numberTag].transform.position, transform.position);
        Vector2 Direction = target[numberTag].transform.position - transform.position;
        transform.up = Vector2.MoveTowards(transform.up, Direction, speed);
        //if (distance < 20)
        //{
        //    indicatorSprite.enabled = false;
        //}
        //else
        //{
        //    indicatorSprite.enabled = true;
        //}
    }
}
