namespace MBSCore.LowWeightBehaviour.Example
{
    internal abstract class ExampleActionFactory<TConfig, TAction> : BehaviourActionFactory<TConfig, ExampleEntity, TAction>
        where TConfig : ExampleActionConfig
        where TAction : ExampleAction<TConfig>
    { }
}