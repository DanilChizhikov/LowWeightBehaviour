namespace MBSCore.LowWeightBehaviour.Example
{
    internal sealed class ExampleRandomStateFactory : RandomBehaviourStateFactory<ExampleEntity, ExampleRandomState>
    {
        protected override ExampleRandomState Create(string name, ExampleEntity entity, RandomBehaviourTransition transition)
        {
            return new ExampleRandomState(name, entity, transition);
        }
    }
}