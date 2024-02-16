namespace MBSCore.LowWeightBehaviour.Example
{
    internal sealed class ExampleWeightState : WeightBehaviourState<ExampleEntity>
    {
        public ExampleWeightState(string name, ExampleEntity entity, WeightBehaviourTransition transition) :
            base(name, entity, transition) { }
    }
}