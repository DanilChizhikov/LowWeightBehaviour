using System;
using System.Collections.Generic;

namespace MBSCore.LowWeightBehaviour
{
    public abstract class WeightBehaviourTransition<TEntity> : BehaviourTransition<TEntity>
        where TEntity : IBehaviourEntity
    {
        private const int InvalidWeightIndex = -1;
        
        private readonly List<RuntimeWeightInfo> _weightInfos;
        private readonly int _weightInfoCount;
        private readonly int _maxWeight;
        private readonly Random _infoRandom;

        private int _randomWeight;
        private int _weightIndex;
        
        public WeightBehaviourTransition(TEntity entity, IEnumerable<RuntimeWeightInfo> weightInfos) : base(entity)
        {
            _weightInfos = new List<RuntimeWeightInfo>(weightInfos);
            _weightInfoCount = _weightInfos.Count;
            for (int i = 0; i < _weightInfoCount; i++)
            {
                _maxWeight += _weightInfos[i].Weight;
            }
            
            _infoRandom = new Random();
            _weightIndex = InvalidWeightIndex;
        }

        public override void Enter()
        {
            _randomWeight = _infoRandom.Next(1, _maxWeight);
            for (int i = 0; i < _weightInfoCount; i++)
            {
                RuntimeWeightInfo info = _weightInfos[i];
                _randomWeight -= info.Weight;
                if (_randomWeight <= 0)
                {
                    _weightIndex = i;
                    break;
                }
            }
        }

        public override bool TryTransition(out IBehaviourState nextState)
        {
            if (_weightIndex <= InvalidWeightIndex)
            {
                throw new Exception("Invalid weight index");
            }
            
            nextState = _weightInfos[_weightIndex].State;
            return !ReferenceEquals(nextState, null);
        }

        public override void Exit()
        {
            _randomWeight = int.MinValue;
            _weightIndex = InvalidWeightIndex;
        }
    }
}