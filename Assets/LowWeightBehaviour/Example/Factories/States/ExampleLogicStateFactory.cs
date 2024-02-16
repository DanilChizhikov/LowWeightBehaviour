namespace MBSCore.LowWeightBehaviour.Example
{
    internal sealed class ExampleLogicStateFactory : LogicBehaviourStateFactory<ExampleEntity, ExampleLogicState>
    {
        public ExampleLogicStateFactory(IBehaviourActionFactoryService actionFactoryService,
            IBehaviourDecisionFactoryService decisionFactoryService) : base(actionFactoryService, decisionFactoryService) { }

        protected override ExampleLogicState Create(string name, IBehaviourAction[] actions, LogicBehaviourTransition[] transitions,
            ExampleEntity entity)
        {
            return new ExampleLogicState(name, entity, actions, transitions);
        }
    }
}