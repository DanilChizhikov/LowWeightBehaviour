namespace MBSCore.LowWeightBehaviour
{
    public abstract class BehaviourTransition<TEntity> : IBehaviourTransition
        where TEntity : IBehaviourEntity
    {
        protected TEntity Entity { get; }

        public BehaviourTransition(TEntity entity)
        {
            Entity = entity;
        }

        public abstract void Enter();
        public abstract bool TryTransition(out IBehaviourState nextState);
        public abstract void Exit();
    }
}