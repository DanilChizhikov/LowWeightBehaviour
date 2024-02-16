namespace MBSCore.LowWeightBehaviour.EditorTests
{
    internal sealed class TestRandomStateFactory : RandomBehaviourStateFactory<TestEntity, TestRandomState>
    {
        protected override TestRandomState Create(string name, TestEntity entity, RandomBehaviourTransition transition)
        {
            return new TestRandomState(name, entity, transition);
        }
    }
}