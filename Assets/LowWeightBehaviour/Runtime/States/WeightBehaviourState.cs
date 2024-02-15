namespace MBSCore.LowWeightBehaviour
{
    public abstract class WeightBehaviourState<TEntity, TTransition> : SingleTransitionBehaviourState<TEntity, TTransition>
        where TEntity : IBehaviourEntity
        where TTransition : WeightBehaviourTransition<TEntity>
    {
        public WeightBehaviourState(string name, TEntity entity, TTransition transition) : base(name, entity, transition)
        {
        }
    }
}