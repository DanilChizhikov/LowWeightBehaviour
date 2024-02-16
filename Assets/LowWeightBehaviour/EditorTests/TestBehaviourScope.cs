using System.Collections.Generic;

namespace MBSCore.LowWeightBehaviour.EditorTests
{
    internal sealed class TestBehaviourScope
    {
        public IBehaviourGraphFactory GraphFactory { get; }

        public TestBehaviourScope()
        {
            var actionFactories = new HashSet<IBehaviourActionFactory>
            {
                new LogActionFactory(),
            };
            
            var actionFactoryService = new BehaviourActionFactoryService(actionFactories);
            var decisionFactories = new HashSet<IBehaviourDecisionFactory>
            {
                new RandomCountMoreOrEqualDecisionFactory(),
                new WeightCountMoreOrEqualDecisionFactory(),
            };
            
            var decisionFactoryService = new BehaviourDecisionFactoryService(decisionFactories);
            var stateFactories = new HashSet<IBehaviourStateFactory>
            {
                new TestLogicStateFactory(actionFactoryService, decisionFactoryService),
                new TestRandomStateFactory(),
                new TestWeightStateFactory()
            };
            
            var stateFactoryService = new BehaviourStateFactoryService(stateFactories);
            GraphFactory = new BehaviourGraphFactory(stateFactoryService);
        }
    }
}