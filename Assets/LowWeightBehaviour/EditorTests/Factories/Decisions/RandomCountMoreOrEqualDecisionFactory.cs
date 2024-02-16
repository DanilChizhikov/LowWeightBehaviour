namespace MBSCore.LowWeightBehaviour.EditorTests
{
    internal sealed class RandomCountMoreOrEqualDecisionFactory : TestDecisionFactory<RandomCountMoreOrEqualDecisionConfig, RandomCountMoreOrEqualDecision>
    {
        protected override RandomCountMoreOrEqualDecision Create(RandomCountMoreOrEqualDecisionConfig config, TestEntity entity)
        {
            return new RandomCountMoreOrEqualDecision(config, entity);
        }
    }
}