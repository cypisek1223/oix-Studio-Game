using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator anim;
    public bool onButton;
    public GameObject button;
    private void Start()
    {
        anim.SetBool("Open", false);
        anim.SetBool("Close", false);
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            anim.SetBool("Open",true);
            anim.SetBool("Close", false);
            Debug.LogError("OPEN");
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            anim.SetBool("Open", false);
            anim.SetBool("Close", true);
            Debug.LogError("CLOSE");
        }
    }
}
