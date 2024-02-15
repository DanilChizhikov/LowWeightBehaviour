using System;

namespace MBSCore.LowWeightBehaviour
{
    public abstract class BehaviourStateFactory<TConfig, TEntity, TState> : IBehaviourStateFactory
        where TConfig : IBehaviourStateConfig
        where TEntity : IBehaviourEntity
        where TState : BehaviourState<TEntity>
    {
        public Type ServicedConfigType => typeof(TConfig);
        
        protected IBehaviourStateFactoryService FactoryService { get; private set; }

        public void InstallFactoryService(IBehaviourStateFactoryService value)
        {
            FactoryService = value;
        }

        public IBehaviourState Create(IBehaviourStateConfig config, IBehaviourEntity entity)
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

        protected abstract TState Create(TConfig config, TEntity entity);
    }
}