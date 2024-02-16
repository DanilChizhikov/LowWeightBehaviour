namespace MBSCore.LowWeightBehaviour.EditorTests
{
    internal abstract class TestDecision<TConfig> : BehaviourDecision<TConfig, TestEntity>
        where TConfig : TestDecisionConfig
    {
        public TestDecision(TConfig config, TestEntity entity) : base(config, entity) { }
    }
}