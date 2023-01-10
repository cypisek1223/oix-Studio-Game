using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RopeMechanim
{
    // Rope Joint Factory initializes Rope Joints with initial settings
    public class JointFactory : MonoBehaviour
    {
        [SerializeField]
        private RopeJoint2 jointPrefab;
        [SerializeField]
        private RopeJoint2 hookPrefab;

        public RopeJoint2 SpawnJoint()
        {
            RopeJoint2 newJoint = Instantiate(jointPrefab);
            return newJoint;
        }
        public RopeJoint2 SpawnHook()
        {
            RopeJoint2 newHook = Instantiate(hookPrefab);
            return newHook;
        }
    }
}