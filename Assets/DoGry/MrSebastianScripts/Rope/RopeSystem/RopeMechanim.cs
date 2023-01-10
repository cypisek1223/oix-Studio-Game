using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RopeMechanim
{
    public class RopeMechanim : RopeStateMachine
    {
        // Dependecies
        [SerializeField]public JointFactory jointFactory;
        [SerializeField]public RopeBuilder ropeBuilder;

       //Mechanics
        public Rigidbody rb { get; private set; }
        //public Transform ropeHandlePlacement { get; private set; }
        public Transform hook => joints.Find(j => j.IsHook)?.transform;
        public List<RopeJoint2> joints { get; set; }
        public Transform lastJoint => joints.Last().transform;

        //Settings
        public float distanceBetweenJoints = 1;
        public float ropeLength = 2;
        public float dropSpeed = 1;
 
        public LineRenderer lr;

        void Awake()
        {
            ChangeState(new RolledUpState(this));
            joints = new List<RopeJoint2>();
            rb = GetComponent<Rigidbody>();
        }
        void Start()
        {
            ropeBuilder.ResetBuilder(this);
        }

        void Update()
        {
            //ropeStateMachine.Update();
            state.Update();
            Debug.Log($"State is: {state.GetType()}");
           
            //if (Input.GetKey(KeyCode.E))
            
                RenderLine();
            
            
        }

        private void RenderLine()
        {
            lr.positionCount = joints.Count + 1;
            lr.SetPosition(joints.Count, transform.position);
            int i = 0;
            foreach (RopeJoint2 j in joints)
            {
                lr.SetPosition(i, j.transform.position);
                i++;
            }
        }
    }
}