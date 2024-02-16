using System.Collections.Generic;

namespace MBSCore.LowWeightBehaviour.Example
{
    internal sealed class ExampleLogicState : LogicBehaviourState<ExampleEntity>
    {
        public ExampleLogicState(string name, ExampleEntity entity, IEnumerable<IBehaviourAction> actions,
            IEnumerable<LogicBehaviourTransition> transitions) : base(name, entity, actions, transitions) { }
    }
}