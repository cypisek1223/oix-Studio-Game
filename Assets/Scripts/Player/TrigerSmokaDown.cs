using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerSmokaDown : MonoBehaviour
{
    public float fallPower;
    [SerializeField] ParticleSystem fallDown;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            if (GameManager.instance.touchController.playerVelocity >= fallPower)
            {
                fallDown.Play();
            }
        }      
    }
}
