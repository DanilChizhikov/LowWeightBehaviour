namespace MBSCore.LowWeightBehaviour
{
    public abstract class RandomBehaviourState<TEntity> : SingleTransitionBehaviourState<TEntity, RandomBehaviourTransition>
        where TEntity : IBehaviourEntity
    {
        
        public RandomBehaviourState(string name, TEntity entity, RandomBehaviourTransition transition) :
            base(name, entity, transition) { }
    }
}