using System.Collections.Generic;

namespace MBSCore.LowWeightBehaviour
{
    public abstract class BehaviourGraph : IBehaviourGraph
    {
        private readonly IBehaviourState _enterState;
        private readonly List<IBehaviourState> _states;

        public BehaviourGraph(IBehaviourState enterState, List<IBehaviourState> states)
        {
            _enterState = enterState;
            _states = states;
        }
        
        public void Enter(bool force = false)
        {
            
        }

        public void Processing()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}