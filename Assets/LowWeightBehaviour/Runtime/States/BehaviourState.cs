namespace MBSCore.LowWeightBehaviour
{
    public abstract class BehaviourState<TEntity> : IBehaviourState
        where TEntity : IBehaviourEntity
    {
        public string Name { get; }
        
        protected TEntity Entity { get; }

        public BehaviourState(string name, TEntity entity)
        {
            Name = name;
            Entity = entity;
        }

        public abstract void Enter();
        public abstract void Processing();
        public abstract void Exit();
        public abstract bool TryGetNextState(out IBehaviourState nextState);
    }
}