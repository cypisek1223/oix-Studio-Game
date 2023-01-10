﻿using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Assertions;

namespace RopeMechanim
{
    [CreateAssetMenu]
    public class RopeBuilder : ScriptableObject, IRopeBuilder
    {
        private RopeMechanim ropeMechanim;
        private List<RopeJoint2> joints => ropeMechanim.joints; 
        private JointFactory factory;

        [SerializeField] JointConfig hookSetup;
        [SerializeField] JointConfig jointsSetup;

        RopeJoint2 hook => joints.Find(j => j.IsHook);
        RopeJoint2 lastJoint => joints.Last();

        #region Builder Initialization
        public virtual void ResetBuilder(RopeMechanim rope)
        {
            ropeMechanim = rope;
            factory = rope.jointFactory;

            if (joints != null)
            {
                foreach (RopeJoint2 joint in joints)
                {
                    Destroy(joint.gameObject);
                }
            }

            Assert.AreEqual(0, joints.Count);
        }
        #endregion

        #region Starting
        public virtual void BuildHook()
        {
            RopeJoint2 hook = factory.SpawnHook();

            ConfigureConnection(hook, hookSetup);
            ConfigureNeighbours(hook);
            ConfigureParent(hook);
           //ConfigurePreviousJoint(hook);

            hook.IsHook = true;
            joints.Add(hook);
        }
        public virtual void StartRollingDown()
        {
            if(hook == null)
            {
                BuildHook();
            }

            hook.SetDynamic();
        }
        public virtual void StartRollingUp()
        {
            //lastJoint.SetKinematic();
        }
        #endregion

        #region Updating
        public void BuildJoint()
        {
            RopeJoint2 newJoint = factory.SpawnJoint();

            ConfigureConnection(newJoint, jointsSetup);
            ConfigureNeighbours(newJoint);
            ConfigureParent(newJoint);
            ConfigurePreviousJoint(newJoint);
            newJoint.SetDynamic();

            joints.Add(newJoint);
        }
        public bool UpdateLastJoint(float deltaPosition)
        {
            //Debug.Log($"Current anchor y: {lastJoint.Anchor.y}; DeltaPos: {deltaPosition}");
            Vector3 lastJointAnchor = lastJoint.Anchor; 
            if (lastJointAnchor.y + deltaPosition < 0)
            {
                lastJointAnchor.y = 0;
                return true;
            }
            lastJointAnchor.y += deltaPosition;
            lastJoint.SetAnchor( lastJointAnchor );
            return false;
        }
        public void DestroyLastJoint()
        {
            RopeJoint2 tmp = lastJoint;
            joints.Remove(lastJoint);
            Destroy(tmp.gameObject);

            if (lastJoint.IsHook)
            {
                lastJoint.ConnectTo(ropeMechanim.rb, hookSetup,
                    new Vector3(0, ropeMechanim.distanceBetweenJoints, 0)); 
            }
            else
            {
                lastJoint.ConnectTo(ropeMechanim.rb, jointsSetup,
                    new Vector3(0, ropeMechanim.distanceBetweenJoints, 0));
            }
            //lastJoint.Disconnect();
            //lastJoint.SetKinematic(); // to refactor (RollingUp using UpdateLastJoint())
        }
        #endregion

        #region Finishing
        public virtual void FinishRollingDown()
        {
            //Vector3 handleFromPlacement = ropeMechanim.transform.position - lastJoint.transform.position;
            //int leftToSpawn = (int)(handleFromPlacement.magnitude / ropeMechanim.distanceBetweenJoints);
            //for (int i = 1; i <= leftToSpawn; i++)
            //{
            //    RopeJoint2 newJoint = factory.SpawnJoint();

            //    ConfigureConnection(newJoint, jointsSetup, ropeMechanim.distanceBetweenJoints * i);
            //    ConfigureRigidbody(newJoint, jointsSetup);
            //    ConfigureNeighbours(newJoint);
            //    ConfigureParent(newJoint);
            //    ConfigurePreviousJoint(newJoint);
            //    ActivateJoint(newJoint);

            //}
        }
        public virtual void FinishRollingUp()
        {
            //throw new NotImplementedException();
        }
        #endregion

        #region Joints Configuration
        protected virtual void ConfigureConnection(RopeJoint2 joint, JointConfig config)
        {
            joint.transform.position = ropeMechanim.transform.position;
            joint.ConnectTo(ropeMechanim.rb, config, Vector3.zero);
            //joint.SetKinematic();
        }

        protected virtual void ConfigureNeighbours(RopeJoint2 joint)
        {
        }

        protected virtual void ConfigureParent(RopeJoint2 joint)
        {
            joint.transform.parent = null;
        }

        protected virtual void ConfigurePreviousJoint(RopeJoint2 newJoint)
        {
            if (joints.Count == 0)
                return;
            if(lastJoint.IsHook)
            {
                lastJoint.ConnectTo(newJoint, hookSetup,
    new Vector3(0, ropeMechanim.distanceBetweenJoints, 0));
            }
            else
            {
            lastJoint.ConnectTo(newJoint, jointsSetup, 
                new Vector3(0, ropeMechanim.distanceBetweenJoints, 0));

            }
            lastJoint.SetDynamic();
        }
        #endregion
    }
}