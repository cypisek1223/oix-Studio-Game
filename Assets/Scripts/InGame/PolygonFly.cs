using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonFly : MonoBehaviour
{
    public Transform StartPost, Post1, Post2, Post3, Post4;
    public float szybkosc;
    public bool one, two, three, four;
    public Vector3 NextPost;
    void Start()
    {
        NextPost = StartPost.position;
        transform.position = StartPost.position;
    }
    void Update()
    {
        if (transform.position == Post1.position)
        {
            one = true;
            two = false;
            three=false;
            four =false;
        }

        if (transform.position == Post2.position)
        {
            one = false;
            two = true;
            three = false;
            four = false;
        }

        if (transform.position == Post3.position)
        {
            one = false;
            two = false;
            three = true;
            four = false;
        }

        if (transform.position == Post4.position)
        {
            one = false;
            two = false;
            three = false;
            four = true;
        }

        if (one)
            NextPost = Post2.transform.position;
        
        if (two)
            NextPost = Post3.transform.position;
        
        if (three)
            NextPost = Post4.transform.position;

        if (four)
            NextPost = Post1.transform.position;

        transform.position = Vector3.MoveTowards(transform.position, NextPost, szybkosc * Time.deltaTime);
    }
}

