using System.Collections.Generic;

namespace MBSCore.LowWeightBehaviour.Example
{
    internal sealed class ExampleBehaviourScope
    {
        public IBehaviourGraphFactory GraphFactory { get; }

        public ExampleBehaviourScope()
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
                new ExampleLogicStateFactory(actionFactoryService, decisionFactoryService),
                new ExampleRandomStateFactory(),
                new ExampleWeightStateFactory()
            };
            
            var stateFactoryService = new BehaviourStateFactoryService(stateFactories);
            GraphFactory = new BehaviourGraphFactory(stateFactoryService);
        }
    }
}