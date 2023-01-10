using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Statek : MonoBehaviour
{
    //INSTANT
    //public static Statek instance;

    //BUTTONS 
    public Button btnLeft;
    public Button btnRight;

    //PARAMETRY STATKU
    private Rigidbody rb;
    public float maxVelocity = 3;
    public float rotationSpeed = 3;
    public float speed = 3;
    public float sibilizerForce = 10;
    public float stoppingForce = 1;
    public float gravityForce = 0;

    //PALIWO
    public float Fuel;

    //UDERZENIE
    public bool Hit = false;
  

    //private void Awake()
    //{
    //    instance = this;
    //
    //}
    private void Start()
    {

        rb = GetComponent<Rigidbody>();
        
    }

    private void Update()
    {

        LossFuel(0, 0, 0);
        Time.timeScale = 0.85f;

        float moveHorizontal = Input.GetAxis("Horizontal");//x
        float moveVertical = Input.GetAxis("Vertical");//y

        ThrustForward(moveVertical);
        Rotate(transform, -moveHorizontal * rotationSpeed);
    }

    #region Steer
    private void ClapVelocity()
    {
        float x = Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity);
        float y = Mathf.Clamp(rb.velocity.y, -maxVelocity, maxVelocity);

        rb.velocity = new Vector2(x, y);
    }
 private void ThrustForward(float amunt)
    {
        rb.AddForce(-rb.velocity / stoppingForce);
       // rb.AddForce(Vector3.up * sibilizerForce);
       // rb.AddForce(Vector3.down * gravityForce);
        Vector2 force = transform.up * amunt;
        rb.AddForce(force * speed * Time.deltaTime);
    }
    private void Rotate(Transform t, float amunt)
    {
        t.Rotate(0, 0, amunt);
    }
    #endregion

    //public void ShipHit()
    //{
    //    var Hitspeed = rb.velocity.magnitude;
    //    if (Hit)
    //    {
    //        Hit = false;
    //        if (Hitspeed >= 10)
    //        {
    //            Debug.LogError("UDERZENIE");
    //        }
    //    }
    //}
    public static void LossFuel(float time,float howloss, float Fuel)
    {
        if (Fuel==0)
        {
            
        }

    }
    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Ground")
    //    {
    //        Debug.LogError("Dotyka Ziemi");
    //        Hit = true;
    //    }
    //}
}
