using System.Collections.Generic;

namespace MBSCore.LowWeightBehaviour
{
    public abstract class LogicBehaviourTransition<TEntity> : BehaviourTransition<TEntity>
        where TEntity : IBehaviourEntity
    {
        private readonly IBehaviourState _trueState;
        private readonly IBehaviourState _falseState;
        private readonly List<IBehaviourDecision> _decisions;
        private readonly int _decisionCount;

        public LogicBehaviourTransition(TEntity entity, IBehaviourState trueState, IBehaviourState falseState,
            IEnumerable<IBehaviourDecision> decisions) : base(entity)
        {
            _trueState = trueState;
            _falseState = falseState;
            _decisions = new List<IBehaviourDecision>(decisions);
            _decisionCount = _decisions.Count;
        }

        public override void Enter()
        {
            for (int i = 0; i < _decisionCount; i++)
            {
                _decisions[i].Enter();
            }
        }

        public override bool TryTransition(out IBehaviourState nextState)
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

        public override void Exit()
        {
            for (int i = 0; i < _decisionCount; i++)
            {
                _decisions[i].Exit();
            }
        }
    }
}