using System;
using System.Collections.Generic;

namespace MBSCore.LowWeightBehaviour
{
    public sealed class BehaviourActionFactoryService : IBehaviourActionFactoryService
    {
        private readonly Dictionary<Type, IBehaviourActionFactory> _factoriesMap;

        public BehaviourActionFactoryService(IEnumerable<IBehaviourActionFactory> factories)
        {
            _factoriesMap = new Dictionary<Type, IBehaviourActionFactory>();
            foreach (var factory in factories)
            {
                _factoriesMap.Add(factory.ServicedConfigType, factory);
            }
        }
        
        public IBehaviourAction Create(IBehaviourActionConfig config, IBehaviourEntity entity)
        {
            if (!_factoriesMap.TryGetValue(config.GetType(), out IBehaviourActionFactory factory))
            {
                throw new AggregateException($"[{GetType().Name}] Unsupported config type [{config.GetType().Name}]");
            }

            return factory.Create(config, entity);
        }
    }
}