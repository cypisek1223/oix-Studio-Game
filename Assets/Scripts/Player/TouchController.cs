using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class TouchController : MonoBehaviour
{
    
    

    public Rigidbody2D rb;
    public ParticleSystem SmokeR;
    public ParticleSystem SmokeL;
    public ParticleSystem Damage;

    [SerializeField] private GameObject DestroyExplosion;
    [SerializeField] private GameObject Indicator;
    public Canvas buttonCanvas;
    //[SerializeField] VisualEffect smokeRight;
    //[SerializeField] VisualEffect smokeLeft;


    public bool butons;

    public bool activeMove;


    public bool Right;
    public bool Left;
    public bool RandL;

    public bool moveUp;
    public bool moveRight;
    public bool moveLeft;



    public float rotationSpeed;
    public float valueSpeed;

    public float powerToIncremate;
    public float reallyPower;
    public float maxPower;
    public float gravityForce;
    //public float Size;

    public int life=2;

    public float playerVelocity;
    public float rotationZ;

    public float screenWidth = Screen.width;
    public void Start()
    {
        Application.targetFrameRate = 60;
        activeMove = true;
        //float Size = Screen.width;
        Right = false;
        Left = false;
        RandL = false;

        rb = GetComponent<Rigidbody2D>();
        Time.timeScale = 1f;
        //SmokeR.Play();
        //SmokeL.Play();

        SmokeR.enableEmission = false;
        SmokeL.enableEmission = false;
        Damage.enableEmission = false;

        Indicator.active = false;
    }
    public void Update()
    {
       
        //rb.AddForce(Vector3.down * gravityForce * rb.mass);
        playerVelocity = rb.velocity.magnitude;
        rotationZ = transform.rotation.z;
        SmokeR.enableEmission = false;
        SmokeL.enableEmission = false;
        //reallyPower = 0;
        if (GameManager.instance.point >= GameManager.instance.allPoint)
        {
            Indicator.active = transform;
        }
        if (life == 0)
        {
            Instantiate(DestroyExplosion, transform.position, Quaternion.identity);
            activeMove = false;
            life = -1;
        }
        if (life == 1)
        {
            Damage.enableEmission = true;
            GameManager.instance.ropeHook.drop = true;
        }
        if (butons)
        {
            buttonCanvas.enabled = true;
        }
        if (!butons)
        {
            buttonCanvas.enabled = false;
        }
        
        if (activeMove)
        {
            if (!butons)
            {
                //reallyPower = 0;
                buttonCanvas.enabled = false;
                if (Input.touchCount == 0)
                {
                    //SmokeR.Stop();
                    //SmokeL.Stop();
                    reallyPower = 0;
                }
                if (Input.touchCount > 0)
                {

                    Touch touch = Input.GetTouch(0);
                    if (touch.position.x > screenWidth / 2)
                    {
                        //Right = true;                  
                        //SmokeR.enableEmission = true;
                        //SmokeL.enableEmission = false;
                        Left = true;
                        SmokeR.enableEmission = false;
                        SmokeL.enableEmission = true;
                    }
                    if (touch.position.x < screenWidth / 2)
                    {
                        //Left = true;
                        //SmokeR.enableEmission = false;
                        //SmokeL.enableEmission = true;

                        Right = true;
                        SmokeR.enableEmission = true;
                        SmokeL.enableEmission = false;
                    }
                    if (Input.touchCount > 1)
                    {
                        Touch touchTwo = Input.GetTouch(1);
                        if (touch.position.x > screenWidth / 2 && touchTwo.position.x < screenWidth / 2 || touchTwo.position.x > screenWidth / 2 && touch.position.x < screenWidth / 2)
                        {

                            RandL = true;
                            SmokeR.enableEmission = true;
                            SmokeL.enableEmission = true;
                        }
                    }
                    if (!RandL)
                    {
                        if (Right)
                        {
                            reallyPower = 0;
                            transform.Rotate(0f, 0f, -rotationSpeed * Time.fixedDeltaTime - valueSpeed, 0f);
                            //Debug.LogError("Prawo");
                           
                        }
                        if (Left)
                        {
                            //reallyPower = 0;
                            transform.Rotate(0f, 0f, +rotationSpeed * Time.fixedDeltaTime + valueSpeed, 0f);
                            //Debug.LogError("Lewo");
                            
                        }
                    }
                    if (RandL)
                    {
                        if (reallyPower < maxPower)
                            reallyPower += powerToIncremate * Time.deltaTime;
                        else
                            reallyPower = maxPower;

                        rb.AddForce(transform.up * reallyPower);
                        //vrb.AddForce(Vector3.down * gravityForce);
                        //Debug.Log("GO UP");
                        
                    }
                    Right = false;
                    Left = false;
                    RandL = false;
                }
            }
            if (butons && activeMove)
            {
                buttonCanvas.enabled = true;
                if (moveUp)
                {
                    if (reallyPower < maxPower)
                        reallyPower += powerToIncremate * Time.deltaTime;
                    else
                        reallyPower = maxPower;

                    rb.AddForce(transform.up * reallyPower);
                    Debug.LogError("UP");
                    
                }
                if (moveRight)
                {
                    transform.Rotate(0f, 0f, -rotationSpeed * Time.fixedDeltaTime - valueSpeed, 0f);
                    Debug.LogError("Prawo");
                    
                }
                if (moveLeft)
                {
                    transform.Rotate(0f, 0f, +rotationSpeed * Time.fixedDeltaTime + valueSpeed, 0f);
                    Debug.LogError("Lewo");
                    
                }
                if (!moveUp)
                    reallyPower = 0;
            }
        }
        if (!activeMove)
        {

        }
    }
    public void BtnUp(bool Up)
    {      
        moveUp = Up;       
    }
    public void BtnRight(bool Right)
    {
        moveRight = Right;
    }
    public void BtnLeft(bool Left)
    {
        moveLeft = Left;
    }
}