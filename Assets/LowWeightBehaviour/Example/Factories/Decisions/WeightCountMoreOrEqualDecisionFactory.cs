namespace MBSCore.LowWeightBehaviour.Example
{
    internal sealed class WeightCountMoreOrEqualDecisionFactory : ExampleDecisionFactory<WeightCountMoreOrEqualDecisionConfig, WeightCountMoreOrEqualDecision>
    {
        protected override WeightCountMoreOrEqualDecision Create(WeightCountMoreOrEqualDecisionConfig config, ExampleEntity entity)
        {
            return new WeightCountMoreOrEqualDecision(config, entity);
        }
    }
}