using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMy : MonoBehaviour
{
   public  Transform target;
   public Vector3 offset;
   public bool Rotation;
    
    // Start is called before the first frame update
    void Start()
    {
        //offset = target.position - transform.position;
       
        if (!Rotation)
        {
            //transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, 0);
            transform.position = target.position - offset;
        }
    }

    // Update is called once per frame
    void Update()
    {
      
            transform.position = target.position - offset;
     
       
    }
}
