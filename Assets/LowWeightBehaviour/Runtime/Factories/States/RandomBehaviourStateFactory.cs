using System.Collections.Generic;

namespace MBSCore.LowWeightBehaviour
{
    public abstract class RandomBehaviourStateFactory<TEntity, TState> : BehaviourStateFactory<RandomBehaviourStateConfig, TEntity, TState>
        where TEntity : IBehaviourEntity
        where TState : RandomBehaviourState<TEntity>
    {
        protected sealed override TState Create(RandomBehaviourStateConfig config, TEntity entity)
        {
            int configsCount = config.TransitionConfig.StateConfigs.Count;
            var states = new IBehaviourState[configsCount];
            for (int i = 0; i < configsCount; i++)
            {
                states[i] = GetState(config.TransitionConfig.StateConfigs[i], entity);
            }

            RandomBehaviourTransition transition = GetTransition(states);
            return Create(config.Name, entity, transition);
        }
        
        protected abstract TState Create(string name, TEntity entity, RandomBehaviourTransition transition);

        private RandomBehaviourTransition GetTransition(IReadOnlyList<IBehaviourState> states) =>
            new RandomBehaviourTransition(states);
    }
}