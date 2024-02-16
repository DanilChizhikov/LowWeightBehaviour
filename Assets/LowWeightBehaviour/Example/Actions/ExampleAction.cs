namespace MBSCore.LowWeightBehaviour.Example
{
    internal abstract class ExampleAction<TConfig> : BehaviourAction<TConfig, ExampleEntity> where TConfig :ExampleActionConfig
    {
        public ExampleAction(TConfig config, ExampleEntity entity) : base(config, entity) { }
    }
}