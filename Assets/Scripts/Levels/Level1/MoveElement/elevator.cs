using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour
{
    public TouchController touchController;
    public GameObject elevatorGamobject;
    public Transform Post1;
    public Transform Post2;

    public float TimeWithCouldown=0;
    public float Couldown=1;
    public float speed;

    public int wait;
    void Update()
    {
        //Debug.Log(wait);
        //Debug.Log("Czas:"+Time.time);
        
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("GRACZ W ");
            if (TimeWithCouldown <= Time.time && wait < 3)
            {
                TimeWithCouldown = Time.time + Couldown;
                wait++;
            }
            if (wait == 3)
            {
                Debug.LogError("Winda w dol");
                touchController.activeMove = false;
                other.transform.SetParent(transform);
                elevatorGamobject.transform.position = Vector3.MoveTowards(Post1.position, Post2.position, speed*Time.deltaTime);
            }
            if (elevatorGamobject.transform.position == Post2.transform.position)
            {
                Debug.LogError("Winda na miejscu");
                other.transform.SetParent(null);
                touchController.activeMove = true;
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") 
        {
            wait = 0;
        }
    }
}
