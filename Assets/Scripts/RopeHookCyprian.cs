using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeHookCyprian : MonoBehaviour
{
    public string TagName;
    
    
    Rigidbody pickup;
    Rigidbody rb;
    private GameObject Load;
    
   public bool ifCaught;
   private float Couldown;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        ifCaught = false;
        Couldown = 0;
    }
    public void Update()
    {
        
        if (ifCaught = true && Input.GetKeyDown(KeyCode.E))
        {
            var Container = gameObject.GetComponent<FixedJoint>();
         
            Debug.LogError("wyrzucanie!!!");
            //gameObject.GetComponent<FixedJoint>().connectedBody = null;
            //Load.GetComponent<Rigidbody2D>().velocity = Vector3.down;
            Load = null;
            Couldown = Time.time + 2;
            Destroy(Container);
            //pickup = null;            
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Load"));//&& Couldown <= Time.deltaTime)//if(other.CompareTag(TagName) && Time.time > Couldown) 
        {
            ifCaught = true;
            Load = other.gameObject;
     
           
                 Debug.Log("Zlapany!!!!! ");
                 pickup = other.gameObject.GetComponent<Rigidbody>();
                gameObject.AddComponent<FixedJoint>().connectedBody = pickup;
                //pickup.transform.parent = transform;
        }
    }
}
