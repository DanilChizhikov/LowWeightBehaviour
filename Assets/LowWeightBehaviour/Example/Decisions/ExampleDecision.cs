namespace MBSCore.LowWeightBehaviour.Example
{
    internal abstract class ExampleDecision<TConfig> : BehaviourDecision<TConfig, ExampleEntity>
        where TConfig : ExampleDecisionConfig
    {
        public ExampleDecision(TConfig config, ExampleEntity entity) : base(config, entity) { }
    }
}