namespace MBSCore.LowWeightBehaviour
{
    public abstract class BehaviourDecision<TConfig, TEntity> : IBehaviourDecision
        where TConfig : IBehaviourDecisionConfig
        where TEntity : IBehaviourEntity
    {
        public string Name => Config.Name;
        
        protected TConfig Config { get; }
        protected TEntity Entity { get; }

        public BehaviourDecision(TConfig config, TEntity entity)
        {
            Config = config;
            Entity = entity;
        }
        
        public virtual void Enter() { }
        public abstract bool GetDecision();
        public virtual void Exit() { }
    }
}