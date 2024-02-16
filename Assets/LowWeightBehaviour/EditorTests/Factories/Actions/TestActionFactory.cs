namespace MBSCore.LowWeightBehaviour.EditorTests
{
    internal abstract class TestActionFactory<TConfig, TAction> : BehaviourActionFactory<TConfig, TestEntity, TAction>
        where TConfig : TestActionConfig
        where TAction : TestAction<TConfig>
    { }
}