using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamOnStart : MonoBehaviour
{
    public float speed;
    public Vector3 offset;

    public GameObject[] important;
    public GameObject Player;
    public Cam cam;
    public int ok;
    public void Start()
    {
        ok = 0;
        transform.position = important[ok].transform.position + offset;
        //offset = new Vector3(cam.offset.x, cam.offset.y, cam.offset.z -20f);
    }
    void Update()
    {
        if (!cam.onPlayer)
        {
            //Time.timeScale = 0;
            if (ok < important.Length)
            {
                Vector3 desiredPosition = important[ok].transform.position + offset;
                //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, speed);//Vector3.MoveTowards(transform.position, important[ok].transform.position + offset, speed);
                Vector3 smoothedPosition = Vector3.MoveTowards(transform.position, important[ok].transform.position + offset, speed);
                transform.position = smoothedPosition;

                Debug.Log("Fly to:" + ok);
                if (transform.position == important[ok].transform.position + offset)
                {
                    ok++;
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, important[ok].transform.position + offset, speed);
                }
            }
        }
            if (ok >= important.Length)
            {
                Debug.LogError("END");
            
            cam.onPlayer = true;
            //transform.position = Vector3.Lerp(transform.position, Player.transform.position + offset, speed);//Vector3.MoveTowards(transform.position, Player.transform.position + offset, speed);
            //if (transform.position == Player.transform.position + offset)
            //{

            //}
        }
        
    }
}
