using System;
using System.Collections.Generic;

namespace MBSCore.LowWeightBehaviour
{
    public sealed class BehaviourStateFactoryService : IBehaviourStateFactoryService
    {
        private readonly Dictionary<Type, IBehaviourStateFactory> _factoriesMap;

        public BehaviourStateFactoryService(IEnumerable<IBehaviourStateFactory> factories)
        {
            _factoriesMap = new Dictionary<Type, IBehaviourStateFactory>();
            foreach (var factory in factories)
            {
                factory.InstallFactoryService(this);
                _factoriesMap.Add(factory.ServicedConfigType, factory);
            }
        }
        
        public IBehaviourState Create(IBehaviourStateConfig config, IBehaviourEntity entity)
        {
            if (!_factoriesMap.TryGetValue(config.GetType(), out IBehaviourStateFactory factory))
            {
                throw new AggregateException($"[{GetType().Name}] Unsupported config type [{config.GetType().Name}]");
            }

            return factory.Create(config, entity);
        }
    }
}