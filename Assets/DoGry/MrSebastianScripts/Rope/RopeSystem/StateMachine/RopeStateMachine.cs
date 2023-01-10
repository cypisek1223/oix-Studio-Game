using UnityEngine;

namespace RopeMechanim
{
    public class RopeStateMachine : MonoBehaviour
    {
        //private RopeMechanim ropeMechanim;
        //public RopeMechanim RopeMechanim { get { return ropeMechanim; } }
        protected RopeState state;

        //public RopeStateMachine(RopeMechanim ropeMechanim)
        //{
        //    this.ropeMechanim = ropeMechanim;
        //    ChangeState(new RolledUpState(this));
        //}

        public void ChangeState(RopeState newState)
        {
            if(state != null)
            {
                state.OnExit();
            }
            newState.OnEnter();

            state = newState;
        }

        //public void Update()
        //{
        //    state.Update();
        //}
    }
}