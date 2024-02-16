namespace MBSCore.LowWeightBehaviour.EditorTests
{
    internal sealed class TestWeightStateFactory : WeightBehaviourStateFactory<TestEntity, TestWeightState>
    {
        protected override TestWeightState Create(string name, TestEntity entity, WeightBehaviourTransition transition)
        {
            return new TestWeightState(name, entity, transition);
        }
    }
}