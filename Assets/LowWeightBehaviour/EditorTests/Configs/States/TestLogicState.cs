using System.Collections.Generic;

namespace MBSCore.LowWeightBehaviour.EditorTests
{
    internal sealed class TestLogicState : LogicBehaviourState<TestEntity>
    {
        public TestLogicState(string name, TestEntity entity, IEnumerable<IBehaviourAction> actions,
            IEnumerable<LogicBehaviourTransition> transitions) : base(name, entity, actions, transitions) { }
    }
}