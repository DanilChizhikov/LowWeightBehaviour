namespace MBSCore.LowWeightBehaviour
{
    public abstract class BehaviourAction<TConfig, TEntity> : IBehaviourAction
        where TConfig : IBehaviourActionConfig
        where TEntity : IBehaviourEntity
    {
        public string Name => Config.Name;
        
        protected TConfig Config { get; }
        protected TEntity Entity { get; }

        public BehaviourAction(TConfig config, TEntity entity)
        {
            Config = config;
            Entity = entity;
        }

        public abstract void Enter();
        public abstract void Processing();
        public abstract void Exit();
    }
}