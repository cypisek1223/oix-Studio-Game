using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public float addTime=0;
    public float couldown;
    public float speedBullet;
    public float speed;

    public GameObject bullet;
    public GameObject Gun;

    public Transform shotPoint;
    public Transform StartPosition;

    public Animator anim;
    public bool trigerAnimation;
    private void Start()
    {
        StartPosition.position = transform.position;
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Vector3 Direction = other.transform.position - transform.position;
            //Gun.transform.up = -Direction;
            Gun.transform.up = Vector3.MoveTowards(Gun.transform.up, Direction, speed * Time.deltaTime);
            //Quaternion.RotateTowards
            anim.SetBool("cannonTriger", true);
            if (Time.time >= addTime)
            {
                

                Debug.LogError("addTime:"+addTime+"Time:"+ Time.time);
                addTime = Time.time + couldown;
               
               Instantiate(bullet, shotPoint.position, shotPoint.rotation);
               
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        anim.SetBool("cannonTriger", false);
        Gun.transform.up = StartPosition.position;
    }
}