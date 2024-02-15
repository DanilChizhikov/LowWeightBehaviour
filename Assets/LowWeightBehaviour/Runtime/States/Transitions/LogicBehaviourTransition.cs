using System.Collections.Generic;

namespace MBSCore.LowWeightBehaviour
{
    public sealed class LogicBehaviourTransition : IBehaviourTransition
    {
        private readonly IBehaviourState _trueState;
        private readonly IBehaviourState _falseState;
        private readonly List<IBehaviourDecision> _decisions;
        private readonly int _decisionCount;

        public LogicBehaviourTransition(IBehaviourState trueState, IBehaviourState falseState,
            IEnumerable<IBehaviourDecision> decisions)
        {
            _trueState = trueState;
            _falseState = falseState;
            _decisions = new List<IBehaviourDecision>(decisions);
            _decisionCount = _decisions.Count;
        }

        public void Enter()
        {
            for (int i = 0; i < _decisionCount; i++)
            {
                _decisions[i].Enter();
            }
        }

        public bool TryTransition(out IBehaviourState nextState)
        {
            nextState = null;
            bool result = true;
            for (int i = 0; i < _decisionCount; i++)
            {
                if (!_decisions[i].GetDecision())
                {
                    result = false;
                    break;
                }
            }
            
            nextState = result ? _trueState : _falseState;
            return !ReferenceEquals(nextState, null);
        }

        public void Exit()
        {
            for (int i = 0; i < _decisionCount; i++)
            {
                _decisions[i].Exit();
            }
        }
    }
}