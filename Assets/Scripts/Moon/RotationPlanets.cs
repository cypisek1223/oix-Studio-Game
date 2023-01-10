using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPlanets : MonoBehaviour
{
    public GameObject Player;
    public Vector3 positionPlayer;
    public float shift;


    void Start()
    {
         positionPlayer = Player.transform.position;
    }
    void Update()
    {
        if(positionPlayer.x < Player.transform.position.x + shift)
        {
           transform.rotation = new Quaternion(0,transform.rotation.x + shift, transform.rotation.y, transform.rotation.z);
           positionPlayer = Player.transform.position;
            Debug.LogError("Rotation in Riht");
        }
        if (positionPlayer.x > Player.transform.position.x - shift)
        {
            transform.rotation = new Quaternion(0, transform.rotation.x + shift, transform.rotation.y, transform.rotation.z);
            positionPlayer = Player.transform.position;
            Debug.LogError("Rotation in Riht");
        }
        else return;
    }
}
