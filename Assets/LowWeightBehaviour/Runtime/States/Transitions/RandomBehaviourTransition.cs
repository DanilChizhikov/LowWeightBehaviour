using System;
using System.Collections.Generic;

namespace MBSCore.LowWeightBehaviour
{
    public sealed class RandomBehaviourTransition : IBehaviourTransition
    {
        private const int InvalidStateIndex = -1;
        
        private readonly List<IBehaviourState> _states;
        private readonly int _stateCount;
        private readonly Random _stateRandom;

        private int _randomStateIndex;
        
        public RandomBehaviourTransition(IEnumerable<IBehaviourState> states)
        {
            _states = new List<IBehaviourState>(states);
            _stateCount = _states.Count;
            _stateRandom = new Random();
            _randomStateIndex = InvalidStateIndex;
        }

        public void Enter()
        {
            _randomStateIndex = _stateRandom.Next(0, _stateCount);
        }

        public bool TryTransition(out IBehaviourState nextState)
        {
            if (_randomStateIndex <= InvalidStateIndex)
            {
                throw new Exception("Invalid state index");
            }
            
            nextState = _states[_randomStateIndex];
            return true;
        }

        public void Exit()
        {
            _randomStateIndex = InvalidStateIndex;
        }
    }
}