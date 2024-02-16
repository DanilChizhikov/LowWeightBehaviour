namespace MBSCore.LowWeightBehaviour.EditorTests
{
    internal sealed class WeightCountMoreOrEqualDecisionFactory : TestDecisionFactory<WeightCountMoreOrEqualDecisionConfig, WeightCountMoreOrEqualDecision>
    {
        protected override WeightCountMoreOrEqualDecision Create(WeightCountMoreOrEqualDecisionConfig config, TestEntity entity)
        {
            return new WeightCountMoreOrEqualDecision(config, entity);
        }
    }
}