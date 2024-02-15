using System.Collections.Generic;

namespace MBSCore.LowWeightBehaviour
{
    public abstract class LogicBehaviourTransition<TDecisionConfig, TEntity, TDecision> : BehaviourTransition<TEntity>
        where TEntity : IBehaviourEntity
        where TDecisionConfig : BehaviourDecisionConfig
        where TDecision : BehaviourDecision<TDecisionConfig, TEntity>
    {
        private readonly IBehaviourState _trueState;
        private readonly IBehaviourState _falseState;
        private readonly List<IBehaviourDecision> _decisions;
        private readonly int _decisionCount;

        public LogicBehaviourTransition(TEntity entity, IBehaviourState trueState, IBehaviourState falseState,
            IEnumerable<TDecision> decisions) : base(entity)
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