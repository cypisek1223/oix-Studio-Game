using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public Camera camera;

    public Transform shotPoint;
    public Transform tagChildObs=null;


    //public GameObject obstacle;
    public GameObject rocket;
    public GameObject gun;


    public int howRokets = 0;
    public bool inRange;

    public float time = 0;
    public float couldown;
    public void Start()
    {
        tagChildObs = null;
    }
    public void Update()
    {
            RaycastHit hit;     
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))// && time <= Time.time)
        {
            //Debug.LogError(ray);
            Transform objectHit = hit.transform;
            Debug.Log(objectHit);
            for (int i = 0; i < GameManager.instance.obstacleCheck.obstaclesArray.Length; i++)
            {
                Debug.Log("Dobrze");
                if(GameManager.instance.obstacleCheck.obstaclesArray[i] != null && GameManager.instance.obstacleCheck.crossHairArray[i] != null)
                {
                    tagChildObs = GameManager.instance.obstacleCheck.obstaclesArray[i].transform;
                    inRange = true;
                }
                if (objectHit == tagChildObs && howRokets > 0) //&& inRange)
                {

                    Vector3 Direction = tagChildObs.position - transform.position;
                    gun.transform.up = Direction;
                    //if (time <= Time.time)
                    //{
                        Debug.LogError("Shoot");
                        time += Time.time + couldown;                     
                        GameObject RocketIns = Instantiate(rocket, shotPoint.position, Quaternion.identity);
                        RocketIns.transform.rotation = shotPoint.rotation;
                        howRokets--;
                        tagChildObs = null;
                        inRange = 
                        GameManager.instance.obstacleCheck.obstaclesArray[i] = null;
                        GameManager.instance.obstacleCheck.crossHairArray[i] = null;
                    //}
                    //}
                }
            }


        }
        else
        {
            tagChildObs = null;
        }
           
    }
}

