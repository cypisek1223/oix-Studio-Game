using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace RopeMechanim
{
    [RequireComponent(typeof(Rigidbody))]
    public class RopeJoint2 : MonoBehaviour
    {
        private bool configured;

        public Rigidbody Rb { get; private set; }
        private Joint Joint { get; set; }

        public bool IsHook { get; set; }
        public RopeJoint2 UpperOne { get; set; }
        public RopeJoint2 LowerOne { get; set; }

        public Vector3 Anchor
        {
            //get => transform.TransformPoint(Joint.anchor);
            get => Vector3.Scale(Joint.anchor, transform.localScale);
            //private set => Joint.anchor = transform.InverseTransformPoint(value);
            private set => Joint.anchor = Vector3.Scale(value, new Vector3(1 / transform.localScale.x, 1 / transform.localScale.y, 1 / transform.localScale.z));
        }
        public static implicit operator bool(RopeJoint2 j) => j != null;
        //public static implicit operator Transform(RopeJoint2 j) => j.rb.transform;
        public static bool operator true(RopeJoint2 j) => j != null;
        public static bool operator false(RopeJoint2 j) => j == null;

        private void Awake()
        {
            Rb = GetComponent<Rigidbody>();
        }

        public void ConnectTo(RopeJoint2 upperJoint, JointConfig config, Vector3 anchor)
        {
            ConnectTo(upperJoint.Rb, config, anchor);
            UpperOne = upperJoint;
            upperJoint.LowerOne = this;
        }
        public void SetAnchor(Vector3 anchor)
        {
            Assert.IsTrue(configured);
            Anchor = anchor;
        }
        public void SetDynamic()
        {
            Rb.isKinematic = false;
        }
        public void SetKinematic()
        {
            Rb.isKinematic = true;
        }
        public void Disconnect()
        {
            if (Joint != null)
            {
                Destroy(Joint);
            }
        }
        public void ConnectTo(Rigidbody rigidbody, JointConfig config, Vector3 anchor)//=new Vector3()) //Vector3.zero workaround
        {
            if (Joint != null)
            {
                Destroy(Joint);
            }

            if (config == null)
            {
                Joint = this.gameObject.AddComponent<Joint>();
            }
            else
            {
                Joint = this.gameObject.AddComponent(config.GetType()) as Joint;
                config.ConfigureJoint(Joint);
                config.ConfigureRigidbody(Rb);
            }

            Joint.connectedBody = rigidbody;
            configured = true;

            SetAnchor(anchor);

            //Debug.Log(anchor);
            //Debug.Break();
        }
    }
}