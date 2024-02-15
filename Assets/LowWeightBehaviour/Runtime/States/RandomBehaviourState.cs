namespace MBSCore.LowWeightBehaviour
{
    public abstract class RandomBehaviourState<TEntity, TTransition> : SingleTransitionBehaviourState<TEntity, TTransition>
        where TEntity : IBehaviourEntity
        where TTransition : RandomBehaviourTransition<TEntity>
    {
        
        public RandomBehaviourState(string name, TEntity entity, TTransition transition) : base(name, entity, transition)
        {
        }
    }
}