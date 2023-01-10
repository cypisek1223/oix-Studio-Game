using UnityEngine;

namespace RopeMechanim
{
    internal class RolledDownState : RopeState
    {
        public RolledDownState(RopeMechanim ropeMechanim) : base(ropeMechanim) { }

        public override void Update()
        {
            //if (ropeMechanim.holdLastJoint)
            //{
            //    if (!ropeMechanim.lastJoint)
            //        return;
            //    ropeMechanim.lastJoint.rb.MovePosition(ropeMechanim.ropeHandlePlacement.position);
            //}

            if(Input.GetButtonDown("Jump"))
            {
                ropeMechanim.ChangeState(new RollingUpState(ropeMechanim));
            }
        }
    }
}