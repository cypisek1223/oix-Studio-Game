using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast2D : MonoBehaviour
{
    public Camera camera;

    public Transform shotPoint;
    public Transform obstacleTransform;
    public Transform tagChildObs;
    public GameObject obstacle;
    public GameObject crossHair;
    public GameObject Rocket;
    public GameObject Gun;

    public float rocketSpeed;
    public float distancBeetewenTwoObstcle;
    public int how = 0;
    public bool inRange;
    public bool ifShoot;

    public float time = 0;
    public float Couldown;
    public void Update()
    {

        if (!inRange)
        {
            obstacle = null;
        }
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Debug.LogError(ray);
            Transform objectHit = hit.transform;
            Debug.Log(objectHit);
            if (objectHit == tagChildObs)
            {
                Vector3 Direction = obstacle.transform.position - transform.position;
                Gun.transform.up = Direction;
                if (inRange)
                {
                    if (time <= Time.time)
                    {
                        time += Time.time + Couldown;
                        GameObject RocketIns = Instantiate(Rocket, shotPoint.position, Quaternion.identity);
                        RocketIns.transform.rotation = shotPoint.rotation;
                        RocketIns.GetComponent<Rigidbody>().AddForce(Direction * rocketSpeed);
                        how--;
                    }
                }
            }
        }


    }
}