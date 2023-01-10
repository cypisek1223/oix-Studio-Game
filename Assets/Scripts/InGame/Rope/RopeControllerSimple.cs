using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeControllerSimple : MonoBehaviour
{

    //Objects that will interact with the rope
    public Transform whatTheRopeIsConnectedTo;
    public Transform whatIsHangingFromTheRope;

    //Line renderer used to display the rope
    private LineRenderer lineRenderer;

    //A list with all rope sections
    public List<Vector3> allRopeSections = new List<Vector3>();

    //Rope data
    private float ropeLength = 1f;
    private float minRopeLength = 0f;
    private float maxRopeLength = 20f;
    //Mass of what the rope is carrying
    private float loadMass = 100f;
    //How fast we can add more/less rope
    float winchSpeed = 2f;

    //The joint we use to approximate the rope
    public SpringJoint springeJointTwo;
    void Start()
    {
        
        //springeJointTwo = whatTheRopeIsConnectedTo.GetComponentInChildren<SpringJoint>();

        lineRenderer = GetComponent<LineRenderer>();

        UpdateSpring();

        whatIsHangingFromTheRope.GetComponent<Rigidbody>().mass = loadMass;
    }

    void Update()
    {
        UpdateWinch();
        DisplayRope();
        if(maxRopeLength >= 7.5)
        {
            maxRopeLength = 7.5f;
        }
    }
    private void UpdateSpring()
    {
        //Someone said you could set this to infinity to avoid bounce, but it doesnt work
        //kRope = float.inf

      
        float density = 7750f;
 
        float radius = 0.02f;

        float volume = Mathf.PI * radius * radius * ropeLength;

        float ropeMass = volume * density;

        ropeMass += loadMass;

        float ropeForce = ropeMass * 9.81f;

        float kRope = ropeForce / 0.01f;

        //print(ropeMass);

        springeJointTwo.spring = kRope * 1.0f;
        springeJointTwo.damper = kRope * 0.8f;

        springeJointTwo.maxDistance = ropeLength;
    }

    private void DisplayRope()
    {
        float ropeWidth = 0.2f;

        lineRenderer.startWidth = ropeWidth;
        lineRenderer.endWidth = ropeWidth;

        Vector3 A = whatTheRopeIsConnectedTo.position;
        Vector3 D = whatIsHangingFromTheRope.position;

        Vector3 B = A + whatTheRopeIsConnectedTo.up * (-(A - D).magnitude * 0.1f);
        //B = A;

        Vector3 C = D + whatIsHangingFromTheRope.up * ((A - D).magnitude * 0.5f);

        BezierCurve.GetBezierCurve(A, B, C, D, allRopeSections);

        Vector3[] positions = new Vector3[allRopeSections.Count];

        for (int i = 0; i < allRopeSections.Count; i++)
        {
            positions[i] = allRopeSections[i];
        }

        //Vector3[] positions = new Vector3[2];

        //positions[0] = whatTheRopeIsConnectedTo.position;
        //positions[1] = whatIsHangingFromTheRope.position;

        lineRenderer.positionCount = positions.Length;

        lineRenderer.SetPositions(positions);
    }

    private void UpdateWinch()
    {
        bool hasChangedRope = false;

        //More rope
        if (Input.GetKey(KeyCode.O) && ropeLength < maxRopeLength)
        {
            ropeLength += winchSpeed * Time.deltaTime;

            hasChangedRope = true;
        }
        else if (Input.GetKey(KeyCode.I)&& ropeLength > minRopeLength)
        {
            ropeLength -= winchSpeed * Time.deltaTime;

            hasChangedRope = true;
        }


        if (hasChangedRope)
        {
            ropeLength = Mathf.Clamp(ropeLength, minRopeLength, maxRopeLength);
        
            UpdateSpring();
        }
    }
}