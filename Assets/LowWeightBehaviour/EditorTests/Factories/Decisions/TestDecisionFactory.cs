namespace MBSCore.LowWeightBehaviour.EditorTests
{
    internal abstract class TestDecisionFactory<TConfig, TDecision> : BehaviourDecisionFactory<TConfig, TestEntity, TDecision>
        where TConfig : TestDecisionConfig
        where TDecision : TestDecision<TConfig>
    { }
}