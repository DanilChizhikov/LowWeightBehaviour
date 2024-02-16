namespace MBSCore.LowWeightBehaviour.Example
{
    internal sealed class RandomCountMoreOrEqualDecision : ExampleDecision<RandomCountMoreOrEqualDecisionConfig>
    {
        public RandomCountMoreOrEqualDecision(RandomCountMoreOrEqualDecisionConfig config, ExampleEntity entity) : base(config, entity)
        {
        }

        protected override bool GetResult()
        {
            return Entity.RandomCount >= Config.TargetCount;
        }
    }
}