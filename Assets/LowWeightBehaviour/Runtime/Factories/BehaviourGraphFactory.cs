namespace MBSCore.LowWeightBehaviour
{
    public sealed class BehaviourGraphFactory : IBehaviourGraphFactory
    {
        private readonly IBehaviourStateFactoryService _stateFactoryService;

        public BehaviourGraphFactory(IBehaviourStateFactoryService stateFactoryService)
        {
            _stateFactoryService = stateFactoryService;
        }
        
        public IBehaviourGraph Create(IBehaviourGraphConfig config, IBehaviourEntity entity)
        {
            IBehaviourState state = _stateFactoryService.Create(config.EnterStateConfig, entity);
            for (int i = config.StateConfigs.Count - 1; i >= 0; i--)
            {
                _stateFactoryService.Create(config.StateConfigs[i], entity);
            }

            return new BehaviourGraph(state);
        }
    }
}