
using UnityEngine;

namespace RopeMechanim
{
    public class RolledUpState : RopeState
    {
        Transform hook => ropeMechanim.hook;

        public RolledUpState(RopeMechanim ropeMechanim) : base(ropeMechanim) { }

        public override void OnEnter()
        {
        }

        public override void Update()
        {
            if(Input.GetButtonDown("Jump"))
            {
                ropeMechanim.ChangeState(new RollingDownState(ropeMechanim));
            }
        }

    }
}