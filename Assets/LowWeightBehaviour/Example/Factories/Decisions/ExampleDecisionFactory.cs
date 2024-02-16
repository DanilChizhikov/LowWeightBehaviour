namespace MBSCore.LowWeightBehaviour.Example
{
    internal abstract class ExampleDecisionFactory<TConfig, TDecision> : BehaviourDecisionFactory<TConfig, ExampleEntity, TDecision>
        where TConfig : ExampleDecisionConfig
        where TDecision : ExampleDecision<TConfig>
    { }
}