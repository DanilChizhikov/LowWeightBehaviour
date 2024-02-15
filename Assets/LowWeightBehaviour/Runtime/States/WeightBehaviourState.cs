namespace MBSCore.LowWeightBehaviour
{
    public abstract class WeightBehaviourState<TEntity> : SingleTransitionBehaviourState<TEntity, WeightBehaviourTransition>
        where TEntity : IBehaviourEntity
    {
        public WeightBehaviourState(string name, TEntity entity, WeightBehaviourTransition transition) :
            base(name, entity, transition) { }
    }
}