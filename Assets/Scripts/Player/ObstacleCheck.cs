using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCheck : MonoBehaviour
{
    public Transform player;
    //public Collider trigger;
    public GameObject[] obstaclesArray;
    public GameObject[] crossHairArray;
    [SerializeField] private GameObject crossHairPref;
    public float distnace;

    public bool crossActive = false;
    public bool connect = false;
    public bool shoot = false;
    public void Start()
    {
        int numberOfTaggedObjects = GameObject.FindGameObjectsWithTag("Obstacle").Length;
        obstaclesArray = new GameObject[numberOfTaggedObjects/2];
        crossHairArray = new GameObject[numberOfTaggedObjects/2];
    }
    public void OnTriggerEnter(Collider  other)
    {

        if (other.gameObject.tag == "Obstacle")//&& !shoot)
        {
            Debug.LogError("IN RANGE");
            for(int i=0;i< obstaclesArray.Length; i++)
            {
                if (obstaclesArray[i]==null)
                {
                    obstaclesArray[i] = other.gameObject;
                    return;
                }
            }                               
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Obstacle") //&& !shoot)
        {
            Debug.LogError("STAY");
            for (int i = 0; i < obstaclesArray.Length; i++)
            {
                if (obstaclesArray[i] == other.gameObject && crossHairArray[i] == null)
                {

                        Vector3 crossHairVector = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z - 5f);//other.transform.localScale.y
                    crossHairArray[i] = Instantiate(crossHairPref, crossHairVector,other.transform.rotation); // Quaternion.identity);
                        //crossHairArray[i].transform.localScale = obstaclesArray[i].transform.localScale;
                        crossHairArray[i].transform.parent = other.transform;                 
                }
            }                        
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            Debug.LogError("EXIT");
            for (int i=0; i < obstaclesArray.Length; i++)
            {
                if (obstaclesArray[i] == other.gameObject)
                {
                    if(GameManager.instance.rayCats.tagChildObs == obstaclesArray[i])
                    {
                        Debug.LogError("USUWANIE");
                        GameManager.instance.rayCats.tagChildObs = null;
                    }
                    Destroy(crossHairArray[i]);
                    obstaclesArray[i] = null;
                    crossHairArray[i] = null;
                    
                    
                }
            }
        }
    }
   
}
