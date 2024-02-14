namespace MBSCore.LowWeightBehaviour
{
    public sealed class BehaviourGraph : IBehaviourGraph
    {
        private readonly IBehaviourState _enterState;
        
        private IBehaviourState _currentState;
        
        public bool IsEntered { get; private set; }
        
        public BehaviourGraph(IBehaviourState enterState)
        {
            _enterState = enterState;
            IsEntered = false;
        }

        public void Enter(bool force = false)
        {
            if (IsEntered && !force)
            {
                return;
            }

            if (force)
            {
                Reset();
            }
            
            EnterTo(_enterState);
            IsEntered = true;
        }

        public void Processing()
        {
            if (!IsEntered)
            {
                return;
            }
            
            _currentState.Processing();
            if (_currentState.TryGetNextState(out IBehaviourState nextState))
            {
                EnterTo(nextState);
            }
        }

        public void Exit()
        {
            if (!IsEntered)
            {
                return;
            }
            
            Reset();
            IsEntered = false;
        }

        private void EnterTo(IBehaviourState state)
        {
            _currentState?.Exit();
            state.Enter();
            _currentState = state;
        }

        private void Reset()
        {
            _currentState?.Exit();
        }
    }
}