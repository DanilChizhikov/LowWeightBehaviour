using System.Collections.Generic;

namespace MBSCore.LowWeightBehaviour
{
    public abstract class WeightBehaviourStateFactory<TEntity, TState> : BehaviourStateFactory<WeightBehaviourStateConfig, TEntity, TState>
        where TEntity : IBehaviourEntity
        where TState : WeightBehaviourState<TEntity>
    {
        protected sealed override TState Create(WeightBehaviourStateConfig config, TEntity entity)
        {
            int configsCount = config.TransitionConfig.StateInfos.Count;
            var states = new Dictionary<IBehaviourState, int>();
            for (int i = 0; i < configsCount; i++)
            {
                WeightStateInfo info = config.TransitionConfig.StateInfos[i];
                IBehaviourState state = GetState(info.State, entity);
                states.Add(state, info.Weight);
            }

            WeightBehaviourTransition transition = GetTransition(states);
            return Create(config.Name, entity, transition);
        }
        
        protected abstract TState Create(string name, TEntity entity, WeightBehaviourTransition transition);

        private WeightBehaviourTransition GetTransition(Dictionary<IBehaviourState, int> states)
        {
            var weightInfos = new List<RuntimeWeightInfo>(states.Count);
            foreach (var state in states)
            {
                weightInfos.Add(new RuntimeWeightInfo(state.Value, state.Key));
            }
            
            return new WeightBehaviourTransition(weightInfos);
        }
    }
}