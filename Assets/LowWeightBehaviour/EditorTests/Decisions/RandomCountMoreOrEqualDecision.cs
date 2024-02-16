namespace MBSCore.LowWeightBehaviour.EditorTests
{
    internal sealed class RandomCountMoreOrEqualDecision : TestDecision<RandomCountMoreOrEqualDecisionConfig>
    {
        public RandomCountMoreOrEqualDecision(RandomCountMoreOrEqualDecisionConfig config, TestEntity entity) : base(config, entity)
        {
        }

        protected override bool GetResult()
        {
            return Entity.RandomCount >= Config.TargetCount;
        }
    }
}