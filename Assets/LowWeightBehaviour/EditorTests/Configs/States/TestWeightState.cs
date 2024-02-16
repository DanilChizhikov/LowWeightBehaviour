namespace MBSCore.LowWeightBehaviour.EditorTests
{
    internal sealed class TestWeightState : WeightBehaviourState<TestEntity>
    {
        public TestWeightState(string name, TestEntity entity, WeightBehaviourTransition transition) :
            base(name, entity, transition) { }
    }
}