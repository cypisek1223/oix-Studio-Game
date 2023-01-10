using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.VFX;

public class InvokingEffects : MonoBehaviour
{
    //public bool pause;
    //public uint startSeed;
    [SerializeField] VisualEffect smokeRight;
    [SerializeField] VisualEffect smokeLeft;
    // Start is called before the first frame update
    void Start()
    {
        smokeRight.Stop();
        smokeLeft.Stop();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //INPUT LEFT
        if (Input.GetKeyDown(KeyCode.A))
        {
            smokeLeft.Stop();
            smokeRight.Play();
            if (Input.GetKeyDown(KeyCode.W))
                return;

        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            smokeRight.Stop();
        }
        // INPUT RIGHT
        if (Input.GetKeyDown(KeyCode.D))
        {

            smokeLeft.Play();
            smokeRight.Stop();
            if (Input.GetKeyDown(KeyCode.W))
                return;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            smokeLeft.Stop();
        }
       
       
        //INPUT UP
        if (Input.GetKeyDown(KeyCode.W))
        {
            smokeLeft.Play();
            smokeRight.Play();
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            smokeLeft.Stop();
            smokeRight.Stop();
        }
        
     
}
}
