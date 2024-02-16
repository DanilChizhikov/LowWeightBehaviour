using System;
using System.Collections.Generic;

namespace MBSCore.LowWeightBehaviour
{
    public sealed class BehaviourDecisionFactoryService : IBehaviourDecisionFactoryService
    {
        private readonly Dictionary<Type, IBehaviourDecisionFactory> _factoriesMap;

        public BehaviourDecisionFactoryService(IEnumerable<IBehaviourDecisionFactory> factories)
        {
            _factoriesMap = new Dictionary<Type, IBehaviourDecisionFactory>();
            foreach (IBehaviourDecisionFactory factory in factories)
            {
                _factoriesMap.Add(factory.ServicedConfigType, factory);
            }
        }
        
        public IBehaviourDecision Create(IBehaviourDecisionConfig config, IBehaviourEntity entity)
        {
            if (!_factoriesMap.TryGetValue(config.GetType(), out IBehaviourDecisionFactory factory))
            {
                throw new AggregateException($"[{GetType().Name}] Unsupported config type [{config.GetType().Name}]");
            }

            return factory.Create(config, entity);
        }
    }
}