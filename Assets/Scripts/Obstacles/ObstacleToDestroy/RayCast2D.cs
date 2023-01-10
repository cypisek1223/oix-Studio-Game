using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast2D : MonoBehaviour
{
    public Camera camera;

    public Transform shotPoint;
    public Transform tagChildObs;

    public GameObject obstacle;
    public GameObject Rocket;
    public GameObject Gun;

    public float rocketSpeed;
    public int how = 0;
    public bool inRange;

    public float time = 0;
    public float Couldown;
    public void Update()
    {

        if (!inRange)
        {
            obstacle = null;
        }
        RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
        //Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        //if (Physics.Raycast(ray, out hit))
        //{
        //Debug.LogError("Ray Touch:"+rayHit);
        Transform objectHit = rayHit.transform;
        if (objectHit == tagChildObs)
        {
            //Debug.LogError("Dotyka!!!!!!!!! ");
            Vector2 Direction = obstacle.transform.position - transform.position;
            Gun.transform.up = Direction;
            if (inRange)
            {
                if (time <= Time.time)
                {
                    time += Time.time + Couldown;
                    GameObject RocketIns = Instantiate(Rocket, shotPoint.position, Quaternion.identity);
                    RocketIns.transform.rotation = shotPoint.rotation;
                    RocketIns.GetComponent<Rigidbody2D>().AddForce(Direction * rocketSpeed);
                    how--;
                }
            }
        }
        //}


    }
}