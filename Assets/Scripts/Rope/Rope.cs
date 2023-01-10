using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LineRenderer))]
public class Rope : MonoBehaviour
{
    //TRANSFORM
    public Transform player;
    public Transform post1;
    public Transform post2;
    public Transform nextPost;


    public SpringJoint2D sj;
    public LineRenderer lr;
    public MeshRenderer Mr;
    public Rigidbody2D rb;
    public Rigidbody2D rbPlayer;

    public bool creativeSj;
    public bool postTwo;
   
    public bool onPosition;
    public bool onePosition;

    //HINGE JOINT PARAMETERS
    public float damper;
    public float spring;
    public float Distance;
    public float speed;
    public float velocity;

    //COLLIDERS
    public GameObject HookCollider;
    public Collider2D boxColliderNormal;
    public Collider2D boxColliderTriger;

    //ANIMATION
    public Animator anim;
    public Slider slider;
    public float valueSlider;
   
    //RAYCAST
  
    RaycastHit hit;
    //public Transform targetLoad;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rbPlayer = GameManager.instance.touchController.GetComponent<Rigidbody2D>();
        lr = GetComponent<LineRenderer>();

        transform.position = post1.position;
        nextPost.position = post1.position;

        boxColliderNormal.enabled = false;
        boxColliderTriger.enabled = false;

        creativeSj = true;
        postTwo = false;
        onPosition = false;
        onePosition = true;

        //targetLoad = null;

    }
    void FixedUpdate()
    {
        valueSlider = slider.GetComponent<Slider>().value;

        //LINE RENDERER
        lr.SetPosition(0, GameManager.instance.touchController.transform.position);
        lr.SetPosition(1, transform.position);

        //ADD PLAYER VELOCITY
        velocity = rbPlayer.velocity.x + rbPlayer.velocity.y;
        if(velocity < 0)
        {
            velocity = -velocity;
        }
        if (onePosition)
        {
            transform.position = GameManager.instance.touchController.transform.position;
        }
        //MOVE UP
        if (valueSlider < 100 && !GameManager.instance.ropeHook.grasp)
        {
            Mr.enabled = false;
            lr.enabled = false;
            if (this.transform.position == GameManager.instance.touchController.transform.position)
            {
                onePosition = true;                
                //Debug.LogError("Na Miejscu");
            }
            if (GameManager.instance.ropeHook.grasp)
            {
                GameManager.instance.ropeHook.drop = true;
            }
            Destroy(sj);
            rb.velocity = Vector3.zero;
            //rb.angularVelocity = Vector3.zero;

            transform.position = Vector3.MoveTowards(transform.position, GameManager.instance.touchController.transform.position,speed + (velocity/2));      
            
            creativeSj = true;
           //rb.useGravity = false;

            boxColliderNormal.enabled = false;
            boxColliderTriger.enabled = false;
        }

        //MOVE DOWN       
        if ( valueSlider >= 100 || GameManager.instance.ropeHook.grasp)
        {
            Mr.enabled = true;
            lr.enabled = true;
            onePosition = false;
                if (!onPosition)
                    transform.position = Vector3.MoveTowards(transform.position, post2.position, speed * Time.deltaTime);

                // creativeSj is in Load Script
                // It create springejoint
                if (creativeSj)
                {
                    creativeSj = false;
                    //rb.useGravity = true;
                    onPosition = true;
                    boxColliderNormal.enabled = true;
                    boxColliderTriger.enabled = true;
                    sj = gameObject.AddComponent<SpringJoint2D>();
                    Debug.Log("SJ");
                }
                SpringeJoint();
        }       
    }
    public void SpringeJoint()
    {
        //SpringeJoint Parameters add
        sj.connectedBody = GameManager.instance.touchController.GetComponent<Rigidbody2D>();
        sj.autoConfigureConnectedAnchor = false;
        sj.anchor = GameManager.instance.touchController.transform.position - GameManager.instance.touchController.transform.position;
        sj.connectedAnchor = GameManager.instance.touchController.transform.position - GameManager.instance.touchController.transform.position;
       
        sj.distance = Distance;
        sj.dampingRatio = 1;
        sj.enableCollision = true;
        sj.autoConfigureDistance = false;
        
        //sj.damper = damper;
        //sj.spring = spring;
        //sj.maxDistance = Distance;
    }
}
