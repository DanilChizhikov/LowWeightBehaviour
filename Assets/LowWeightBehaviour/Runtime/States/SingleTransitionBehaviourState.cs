namespace MBSCore.LowWeightBehaviour
{
    public abstract class SingleTransitionBehaviourState<TEntity, TTransition> : BehaviourState<TEntity>
        where TEntity : IBehaviourEntity where TTransition : BehaviourTransition<TEntity>
    {
        private readonly TTransition _transition;
        
        public SingleTransitionBehaviourState(string name, TEntity entity, TTransition transition) : base(name, entity)
        {
            _transition = transition;
        }
        
        public override void Enter()
        {
            _transition.Enter();
        }

        public override bool TryGetNextState(out IBehaviourState nextState)
        {
            return _transition.TryTransition(out nextState);
        }
        
        public override void Exit()
        {
            _transition.Exit();
        }
    }
}