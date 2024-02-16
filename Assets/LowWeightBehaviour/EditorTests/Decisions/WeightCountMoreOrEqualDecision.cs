namespace MBSCore.LowWeightBehaviour.EditorTests
{
    internal sealed class WeightCountMoreOrEqualDecision : TestDecision<WeightCountMoreOrEqualDecisionConfig>
    {
        public WeightCountMoreOrEqualDecision(WeightCountMoreOrEqualDecisionConfig config, TestEntity entity) : base(config, entity)
        {
        }

        protected override bool GetResult()
        {
            return Entity.WeightCount >= Config.TargetCount;
        }
    }
}