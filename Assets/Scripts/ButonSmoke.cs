using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButonSmoke : MonoBehaviour
{

    public ParticleSystem ps;

    public void Update()
    {
    }
    public void ButtonSmoke()
    {
        ps.Play();
        Debug.LogError("Smoke");
    }
}
