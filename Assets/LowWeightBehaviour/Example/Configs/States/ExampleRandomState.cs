namespace MBSCore.LowWeightBehaviour.Example
{
    internal sealed class ExampleRandomState : RandomBehaviourState<ExampleEntity>
    {
        public ExampleRandomState(string name, ExampleEntity entity, RandomBehaviourTransition transition) :
            base(name, entity, transition) { }
    }
}