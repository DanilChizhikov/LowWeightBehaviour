namespace MBSCore.LowWeightBehaviour.Example
{
    internal sealed class RandomCountMoreOrEqualDecisionFactory : ExampleDecisionFactory<RandomCountMoreOrEqualDecisionConfig, RandomCountMoreOrEqualDecision>
    {
        protected override RandomCountMoreOrEqualDecision Create(RandomCountMoreOrEqualDecisionConfig config, ExampleEntity entity)
        {
            return new RandomCountMoreOrEqualDecision(config, entity);
        }
    }
}