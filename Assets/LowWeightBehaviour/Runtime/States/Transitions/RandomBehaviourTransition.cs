using System;
using System.Collections.Generic;

namespace MBSCore.LowWeightBehaviour
{
    public abstract class RandomBehaviourTransition<TEntity> : BehaviourTransition<TEntity>
        where TEntity : IBehaviourEntity
    {
        private const int InvalidStateIndex = -1;
        
        private readonly List<IBehaviourState> _states;
        private readonly int _stateCount;
        private readonly Random _stateRandom;

        private int _randomStateIndex;
        
        public RandomBehaviourTransition(TEntity entity, IEnumerable<IBehaviourState> states) : base(entity)
        {
            _states = new List<IBehaviourState>(states);
            _stateCount = _states.Count;
            _stateRandom = new Random();
            _randomStateIndex = InvalidStateIndex;
        }

        public override void Enter()
        {
            _randomStateIndex = _stateRandom.Next(0, _stateCount);
        }

        public override bool TryTransition(out IBehaviourState nextState)
        {
            if (_randomStateIndex <= InvalidStateIndex)
            {
                throw new Exception("Invalid state index");
            }
            
            nextState = _states[_randomStateIndex];
            return true;
        }

        public override void Exit()
        {
            _randomStateIndex = InvalidStateIndex;
        }
    }
}