using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class TouchController : MonoBehaviour
{

    //[Range(0,10)]<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

    public Rigidbody2D rb;

    [Header("Particle System")]
    [SerializeField] ParticleSystem fireR;
    [SerializeField] ParticleSystem fireL;
    [SerializeField] ParticleSystem damage;
   
    [SerializeField] ParticleSystem startSmoke;
    [SerializeField] private GameObject destroyExplosion;

    [Header("")]
    [SerializeField] ParticleSystem smokeLeft;
    [SerializeField] ParticleSystem smokeRight;
    [SerializeField] ParticleSystem smokeDown;

    [Header("GameObjects")]
    [SerializeField] private GameObject indicator;
    public GameObject player;
    public GameObject playerDummy;
    public Transform chackPoint;
    public Canvas buttonCanvas;
    //[SerializeField] VisualEffect smokeRight;
    //[SerializeField] VisualEffect smokeLeft;

    [Header("Bool")]
    public bool startSomke;

    public bool butons;

    public bool activeMove;
    public bool ifIndicator;

    public bool right;
    public bool left;
    public bool RandL;

    public bool moveUp;
    public bool moveRight;
    public bool moveLeft;


    [Header("Player Parameters")]
    public float playerVelocity;
    public float reallyPower;
    public float rotationZ;

    public float rotationSpeed;
    public float valueSpeed;

    public float startforce;

    public float maxPower;
    public float powerToIncremate;
    public float gravityForce;
    public int life = 2;
    //public float Size;

    [Header("")]
    public float screenWidth = Screen.width;
    public void Start()
    {
        Application.targetFrameRate = 60;
        activeMove = true;
        //float Size = Screen.width;
        right = false;
        left = false;
        RandL = false;

        rb = GetComponent<Rigidbody2D>();
        Time.timeScale = 1f;
        //SmokeR.Play();
        //SmokeL.Play();

        fireR.enableEmission = false;
        fireL.enableEmission = false;

        damage.enableEmission = false;
        startSmoke.enableEmission = false;

        indicator.active = ifIndicator;
    }
    public void Update()
    {  
        //rb.AddForce(Vector3.down * gravityForce * rb.mass);
        playerVelocity = rb.velocity.magnitude;
        rotationZ = transform.rotation.z;
        fireR.enableEmission = false;
        fireL.enableEmission = false;
        //reallyPower = 0;
        if(playerVelocity > 1f)
        {
            startSomke = false;
            startSmoke.enableEmission = false;
        }
        if (playerVelocity < 1f)
        {
            startSomke = true;            
        }
        if (GameManager.instance.point >= GameManager.instance.allPoint)
        {
            indicator.active = transform;
        }        
        if (butons)
        {
            buttonCanvas.enabled = true;
        }
        if (!butons)
        {
            buttonCanvas.enabled = false;
        }
        if (life < 0)
        {
            ShipDestroy();
        }
        if (life == 0)
        {
            Instantiate(destroyExplosion, transform.position, Quaternion.identity);
            activeMove = false;
            life = -1;           
            
        }
        if (life == 1)
        {
            damage.enableEmission = true;
            //GameManager.instance.ropeHook.drop = true;
        }
        if(life >= 2)
        {
            damage.enableEmission = false;
        }
        if (activeMove)
        {            
            if (!butons)
            {
                MoveScreen();
            }
            if (butons && activeMove)
            {
                MoveButton();
            }
        }
        if (!activeMove)
        {

        }
    }
    public void MoveButton()
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
            if (startSomke)
            {
                startSmoke.Play();
                //rb.AddForce(transform.up * startforce * Time.deltaTime);
            }
            else if (!startSomke && startSmoke.enableEmission != true)
            {
                fireR.enableEmission = true;
                fireL.enableEmission = true;
            }
        }
        if (moveRight)
        {
            transform.Rotate(0f, 0f, -rotationSpeed * Time.fixedDeltaTime - valueSpeed, 0f);
            Debug.LogError("Prawo");
            fireR.enableEmission = true;
            fireL.enableEmission = false;
        }
        if (moveLeft)
        {
            transform.Rotate(0f, 0f, +rotationSpeed * Time.fixedDeltaTime + valueSpeed, 0f);
            Debug.LogError("Lewo");
            fireR.enableEmission = false;
            fireL.enableEmission = true;
        }
        if (!moveUp)
            reallyPower = 0;
    
    }
    public void MoveScreen()
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
                left = true;
                fireR.enableEmission = false;
                fireL.enableEmission = true;
            }
            if (touch.position.x < screenWidth / 2)
            {
                //Left = true;
                //SmokeR.enableEmission = false;
                //SmokeL.enableEmission = true;

                right = true;
                fireR.enableEmission = true;
                fireL.enableEmission = false;
            }
            if (Input.touchCount > 1)
            {
                Touch touchTwo = Input.GetTouch(1);
                if (touch.position.x > screenWidth / 2 && touchTwo.position.x < screenWidth / 2 || touchTwo.position.x > screenWidth / 2 && touch.position.x < screenWidth / 2)
                {

                    RandL = true;
                    fireR.enableEmission = true;
                    fireL.enableEmission = true;
                }
            }
            if (!RandL)
            {
                if (right)
                {
                    reallyPower = 0;
                    transform.Rotate(0f, 0f, -rotationSpeed * Time.fixedDeltaTime - valueSpeed, 0f);
                    //Debug.LogError("Prawo");

                }
                if (left)
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
            }
            right = false;
            left = false;
            RandL = false;
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
    public void ShipDestroy()
    {
        StartCoroutine(Respawn(5f));       
        life = 2;

    }
    IEnumerator Respawn(float duration)
    {
        player.transform.localScale = new Vector3(0, 0, 0);
        player.GetComponent<Rigidbody2D>().simulated = false;
        damage.enableEmission = false;
        GameObject Dummy = Instantiate(playerDummy, transform.position, transform.rotation);
        playerDummy.transform.position = transform.position;     
        
        yield return new WaitForSeconds(duration);

        player.transform.position = chackPoint.position;
        player.transform.localScale = new Vector3(4, 4, 0.02f);
        player.transform.rotation = new Quaternion(0, 0, 0, 0);
        player.GetComponent<Rigidbody2D>().simulated = true;
        activeMove = true;
    }
}