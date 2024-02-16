namespace MBSCore.LowWeightBehaviour.Example
{
    internal sealed class ExampleWeightStateFactory : WeightBehaviourStateFactory<ExampleEntity, ExampleWeightState>
    {
        protected override ExampleWeightState Create(string name, ExampleEntity entity, WeightBehaviourTransition transition)
        {
            return new ExampleWeightState(name, entity, transition);
        }
    }
}