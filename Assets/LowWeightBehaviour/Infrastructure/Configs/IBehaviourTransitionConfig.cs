using System.Collections.Generic;

namespace MBSCore.LowWeightBehaviour
{
    public interface IBehaviourTransitionConfig
    {
        IBehaviourStateConfig TrueState { get; }
        IBehaviourStateConfig FalseState { get; }
        IReadOnlyList<IBehaviourDecisionConfig> DecisionConfigs { get; }
    }
}