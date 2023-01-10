using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public Rigidbody rb;
    public Camera camera;

    
    public bool Right;
    public bool Left;
    public bool RandL;

    public float rotationSpeed;
    public float valueSpeed;
    public float speed;
    public void Start()
    {
        Right = false;
        Left = false;
        RandL = false;
        rb = GetComponent<Rigidbody>();
    }
    public void Update()
    {
        if (Input.touchCount > 0)
        {
            
            Touch touch = Input.GetTouch(0);
            if (touch.position.x > 570)
            {
                Right = true;
            }
            if (touch.position.x < 570)
            {
                Left = true;
            }
            if(Input.touchCount > 1)
            {
                Touch touchTwo = Input.GetTouch(1);
                if (touch.position.x > 570 && touchTwo.position.x < 570 || touchTwo.position.x > 570 && touch.position.x < 570)
                {
                    RandL = true;
                }
            }
            
        }
            if (Right)
            {
                transform.Rotate(0f, 0f, -rotationSpeed * Time.fixedDeltaTime - valueSpeed);
            }
            if (Left)
            {
                transform.Rotate(0f, 0f, +rotationSpeed * Time.fixedDeltaTime + valueSpeed);
            }
            if (RandL)
            {
                rb.velocity = rb.transform.up * speed * Time.fixedDeltaTime * 2;
            }


        Right = false;
        Left = false;
        RandL = false;
    }
}

