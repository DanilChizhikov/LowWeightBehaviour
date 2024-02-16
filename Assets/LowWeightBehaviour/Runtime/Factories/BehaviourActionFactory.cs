using System;

namespace MBSCore.LowWeightBehaviour
{
    public abstract class BehaviourActionFactory<TConfig, TEntity, TAction> : IBehaviourActionFactory
        where TConfig : IBehaviourActionConfig
        where TEntity : IBehaviourEntity
        where TAction : BehaviourAction<TConfig, TEntity>
    {
        public Type ServicedConfigType => typeof(TConfig);
        
        public IBehaviourAction Create(IBehaviourActionConfig config, IBehaviourEntity entity)
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

        protected abstract TAction Create(TConfig config, TEntity entity);
    }
}