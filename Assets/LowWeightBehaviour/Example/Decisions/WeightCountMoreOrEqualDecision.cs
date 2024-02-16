namespace MBSCore.LowWeightBehaviour.Example
{
    internal sealed class WeightCountMoreOrEqualDecision : ExampleDecision<WeightCountMoreOrEqualDecisionConfig>
    {
        public WeightCountMoreOrEqualDecision(WeightCountMoreOrEqualDecisionConfig config, ExampleEntity entity) : base(config, entity)
        {
        }

        protected override bool GetResult()
        {
            return Entity.WeightCount >= Config.TargetCount;
        }
    }
}