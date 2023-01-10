using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public RayCast ob;
    public RayCast2D ob2D;
    public Transform tT;
    public GameObject CrossHairPref;
    public GameObject crossHair;
    public bool CrossActive = false;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.LogError("Obstacle in range");
            ob2D.obstacle = this.gameObject;
            ob2D.inRange = true;
            //ob.tagParentObs = this.transform.parent;
            ob2D.tagChildObs = tT;

            if (!CrossActive)
            {
                Vector3 crossHairVector = new Vector3(transform.position.x, transform.position.y, -(transform.position.z + 3f));
                crossHair = Instantiate(CrossHairPref, crossHairVector, transform.rotation);
                crossHair.transform.parent = this.transform;

                CrossActive = true;
            }
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.LogError("Player Out Of Range");
            Destroy(crossHair.gameObject);
            ob2D.obstacle = null;
            ob2D.inRange = false;
            ob2D.tagChildObs = null;

            CrossActive = false;
            
        }
    }
}

