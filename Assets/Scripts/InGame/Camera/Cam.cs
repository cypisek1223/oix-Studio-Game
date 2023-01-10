using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class Cam : MonoBehaviour
{
    public TouchController playerController;
    public Transform target;

    public float smoothSpeed = 10000f;
    public float speed;
    public float couldown;
    public float T;

    //public Vector3 positionCamera;
    public Vector3 positionClose;
    public Vector3 positionAway;
    public Vector3 vCamUR;
    public Vector3 vCamUC;
    public Vector3 vCamUL;
    public Vector3 vCamD;

    public bool lookAt ;
    public bool onPlayer;
    

    public bool uR;
    public bool uC;
    public bool uL;
    public bool dD;


    public Text redy;
    public Text number;
    public Text go;

    public Camera Central;
    public GameObject outOfRange;
    public GameObject cloneShip;
   //public Camera litleCamera;
   // public CinemachineVirtualCamera camRU;
   // public CinemachineVirtualCamera camRD;
   // public CinemachineVirtualCamera camLU;
   // public CinemachineVirtualCamera camLD;

    public GameObject mainCamera;

    public float velocity;
    public float velocityY;
    public float rotationPlayer;
    public float maxHeightCamera;
    public float outOfRangeCameraHeight;
    private Vector3 Z;
    public void Awake()
    {
        mainCamera = Central.gameObject;
        transform.position = target.position;
        outOfRange.active = false;
        
    }
    private void FixedUpdate()
    {
     uR=false;
     uC= false;
     uL=false;
     dD =false;
        
        velocity = playerController.playerVelocity;
        velocityY = playerController.rb.velocity.y;
        rotationPlayer = playerController.rotationZ;
        T = Time.time;
        if (onPlayer)
        {
            if (transform.position.y >= maxHeightCamera)
                transform.position = new Vector3(transform.position.x, maxHeightCamera, transform.position.z);

            //Vector3 desiredPosition = target.position + offset;
            //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            //transform.position = mainCamera.transform.position;
            if (playerController.playerVelocity > 0.5f)
            {
                couldown = 0;
                Vector3 positionCamera = target.position + positionAway;
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, positionCamera, speed);
                mainCamera.transform.position = smoothedPosition;
                Z.z = positionCamera.z;
                //Debug.LogError("Go Away");
            }
            if (playerController.playerVelocity <= 0.5f)
            {
                Vector3 positionCamera = target.position + positionClose;
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, positionCamera, speed);
                mainCamera.transform.position = smoothedPosition;
                Z.z = positionCamera.z;
                //Debug.LogError("Go Close");
            }
            //Camera Up&Righr
            if (playerController.rb.velocity.y > 0 && playerController.rotationZ < -0.3 && playerController.rotationZ > -0.6) 
            {
                uR = true;
                Vector3 positionCamera = target.position + vCamUR;
                Vector3 UR =  new Vector3(positionCamera.x, positionCamera.y, Z.z);
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, UR, speed);
                mainCamera.transform.position = smoothedPosition;
                //Debug.LogError("UP RIGHT");
            }
            //Camera Up&Center
            if (playerController.rb.velocity.y > 5 && playerController.playerVelocity > 0.5f && playerController.rotationZ < 0.3 && playerController.rotationZ > -0.3|| playerController.playerVelocity <= 0.5f && target.transform.position.y<=-16) 
            {
                uC = true;
                Vector3 positionCamera = target.position + vCamUC;
                Vector3 UC = new Vector3(positionCamera.x, positionCamera.y, Z.z);
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, UC, speed);
                mainCamera.transform.position = smoothedPosition;
                //Debug.LogError("UP CENTER");
            }           
            //Camera Up&left
            if (playerController.rb.velocity.y > 0  && playerController.rotationZ > 0.3 && playerController.rotationZ < 0.6)
            {
                uL = true;
                Vector3 positionCamera = target.position + vCamUL;
                Vector3 UL = new Vector3(positionCamera.x, positionCamera.y, Z.z);
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, UL, speed);
                mainCamera.transform.position = smoothedPosition;
                //Debug.LogError("UP LEFT");
            }
            //Camera Down
            if (playerController.rb.velocity.y < -2 && playerController.playerVelocity > 0.5f && playerController.gameObject.transform.position.y !>=2) 
            {
                dD = true;
                Vector3 positionCamera = target.position + vCamD;
                Vector3 D = new Vector3(positionCamera.x, positionCamera.y, Z.z);
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, D, speed);
                mainCamera.transform.position = smoothedPosition;
                //Debug.LogError("DOWN");
            }
            
            
            //if (velocityY <= 0 && velocityY > -8 && playerController.playerVelocity < 0.5f)
            //{
            //    Vector3 positionCamera = target.position + positionAway;
            //    Vector3 smoothedPosition = Vector3.Lerp(transform.position, positionCamera, speed);
            //    mainCamera.transform.position = smoothedPosition;
            //    Debug.LogError("DOWN DOWN DOWN");
            //}
        }
        if (transform.position.y >= maxHeightCamera)
        {
            transform.position = new Vector3(transform.position.x, maxHeightCamera, transform.position.z);
        }    
        if (target.transform.position.y >= maxHeightCamera+50)
        {
            //if (transform.position.y >= maxHeightCamera)
            //    transform.position = new Vector3(transform.position.x, maxHeightCamera, transform.position.z);

            outOfRange.active = true;
            outOfRange.transform.position = new Vector3(target.transform.position.x, outOfRangeCameraHeight, 0);
            cloneShip.transform.rotation = target.transform.rotation;
        }      
        else if(target.transform.position.y < maxHeightCamera + 50)
        {
            outOfRange.active = false;
        }
            
        //if (lookAt)
        // {
        //     transform.LookAt(target);
        // }
    }

}