using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeHive : MonoBehaviour
{
    public static BeeHive inst;
    public GameObject player;
    public GameObject worm;
    public GameObject startPoint;
    public bool vision = false;
    public float couldown;
    public float time=0;
    public int quantityBee;
    private void Awake()
    {
        if (inst == null)
        {
            inst = this;
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            
            vision = true;
            if (Time.time >= time)
            {
                if (quantityBee != 0)
                {
                    Debug.LogError("In Area Hive");
                    quantityBee--;
                    time = Time.time + couldown;
                    GameObject insect = Instantiate(worm, startPoint.transform.position, Quaternion.identity);
                    insect.transform.parent = this.transform;                   
                    insect.transform.rotation = transform.rotation;
                    //insect.GetComponent<Rigidbody>().AddForce(Direction * rocketSpeed);

                }                                  
            }
            
            
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.LogError("Out Area Hive");
            vision = false;

        }
    }
}
