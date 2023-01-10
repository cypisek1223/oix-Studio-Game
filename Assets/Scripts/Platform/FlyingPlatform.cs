using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPlatform : MonoBehaviour
{
    public Transform StartPost, Post1, Post2;
    public float szybkosc;
    Vector3 NextPost;
    void Start()
    {
        NextPost = StartPost.position;
    }
    void Update()
    {
        if (transform.position == Post1.position)
        {
            NextPost = Post2.position;
        }
        if (transform.position == Post2.position)
        {
            NextPost = Post1.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, NextPost, szybkosc * Time.deltaTime);
    }
}

