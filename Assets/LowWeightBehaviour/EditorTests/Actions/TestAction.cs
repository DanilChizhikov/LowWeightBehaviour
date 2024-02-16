namespace MBSCore.LowWeightBehaviour.EditorTests
{
    internal abstract class TestAction<TConfig> : BehaviourAction<TConfig, TestEntity> where TConfig :TestActionConfig
    {
        public TestAction(TConfig config, TestEntity entity) : base(config, entity) { }
    }
}