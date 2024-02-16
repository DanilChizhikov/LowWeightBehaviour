namespace MBSCore.LowWeightBehaviour.EditorTests
{
    internal sealed class TestLogicStateFactory : LogicBehaviourStateFactory<TestEntity, TestLogicState>
    {
        public TestLogicStateFactory(IBehaviourActionFactoryService actionFactoryService,
            IBehaviourDecisionFactoryService decisionFactoryService) : base(actionFactoryService, decisionFactoryService) { }

        protected override TestLogicState Create(string name, IBehaviourAction[] actions, LogicBehaviourTransition[] transitions,
            TestEntity entity)
        {
            return new TestLogicState(name, entity, actions, transitions);
        }
    }
}