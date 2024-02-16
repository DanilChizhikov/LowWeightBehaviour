namespace MBSCore.LowWeightBehaviour.EditorTests
{
    internal sealed class TestRandomState : RandomBehaviourState<TestEntity>
    {
        public TestRandomState(string name, TestEntity entity, RandomBehaviourTransition transition) :
            base(name, entity, transition) { }
    }
}