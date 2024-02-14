using System;
using System.Collections.Generic;

namespace MBSCore.LowWeightBehaviour
{
    public sealed class BehaviourGraphFactory : IBehaviourGraphFactory
    {
        private readonly Dictionary<Type, IBehaviourStateFactory> _factoriesMap;

        public BehaviourGraphFactory(IEnumerable<IBehaviourStateFactory> factories)
        {
            _factoriesMap = new Dictionary<Type, IBehaviourStateFactory>();
            foreach (var factory in factories)
            {
                _factoriesMap.Add(factory.ServicedConfigType, factory);
            }
        }
        
        public IBehaviourGraph Create(IBehaviourGraphConfig config, IBehaviourEntity entity)
        {
            IBehaviourState state = GetState(config.EnterStateConfig, entity);
            for (int i = config.StateConfigs.Count - 1; i >= 0; i--)
            {
                GetState(config.StateConfigs[i], entity);
            }

            return new BehaviourGraph(state);
        }

        private IBehaviourState GetState(IBehaviourStateConfig config, IBehaviourEntity entity)
        {
            if (!_factoriesMap.TryGetValue(config.GetType(), out IBehaviourStateFactory factory))
            {
                throw new AggregateException($"[{GetType().Name}] Unsupported config type [{config.GetType().Name}]");
            }

            return factory.Create(config, entity);
        }
    }
}