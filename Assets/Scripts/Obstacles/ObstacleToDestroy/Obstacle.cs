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
    public bool shoot = false;
  // public void OnTriggerStay2D(Collider2D other)
  // {
  //     if (other.tag == "Player"&& shoot)
  //     {
  //         Debug.LogError("Obstacle in range");
  //
  //         GameManager.instance.rayCats2D.obstacle = this.gameObject;
  //         GameManager.instance.rayCats2D.inRange = true;
  //         GameManager.instance.rayCats2D.crossHair = crossHair;
  //         //ob.tagParentObs = this.transform.parent;
  //         GameManager.instance.rayCats2D.tagChildObs = tT;
  //         shoot = GameManager.instance.rayCats2D.ifShoot;
  //
  //         if (!CrossActive)
  //         {
  //             Vector3 crossHairVector = new Vector3(transform.position.x, transform.position.y, -(transform.position.z + 3f));
  //             crossHair = Instantiate(CrossHairPref, crossHairVector, transform.rotation);
  //             crossHair.transform.parent = this.transform;
  //
  //             CrossActive = true;
  //         }
  //     }
  // }
  // public void OnTriggerExit2D(Collider2D other)
  // {
  //     if (other.tag == "Player")
  //     {
  //         Debug.LogError("Player Out Of Range");
  //         Destroy(crossHair.gameObject);
  //         GameManager.instance.rayCats2D.obstacle = null;
  //         GameManager.instance.rayCats2D.inRange = false;
  //         GameManager.instance.rayCats2D.tagChildObs = null;
  //
  //         CrossActive = false;
  //         
  //     }
  // }
}

