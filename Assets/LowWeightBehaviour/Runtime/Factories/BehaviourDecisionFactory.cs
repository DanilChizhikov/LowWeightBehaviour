using System;

namespace MBSCore.LowWeightBehaviour
{
    public abstract class BehaviourDecisionFactory<TConfig, TEntity, TDecision> : IBehaviourDecisionFactory
        where TConfig : IBehaviourDecisionConfig
        where TEntity : IBehaviourEntity
        where TDecision : BehaviourDecision<TConfig, TEntity>
    {
        public Type ServicedConfigType => typeof(TConfig);
        
        public IBehaviourDecision Create(IBehaviourDecisionConfig config, IBehaviourEntity entity)
        {
            if (config is not TConfig genericConfig)
            {
                throw new ArgumentException($"[{GetType().Name}] Unsupported config type [{config.GetType().Name}]");
            }

            if (entity is not TEntity genericEntity)
            {
                throw new ArgumentException($"[{GetType().Name}] Unsupported entity type [{entity.GetType().Name}]");
            }

            return Create(genericConfig, genericEntity);
        }

        protected abstract TDecision Create(TConfig config, TEntity entity);
    }
}