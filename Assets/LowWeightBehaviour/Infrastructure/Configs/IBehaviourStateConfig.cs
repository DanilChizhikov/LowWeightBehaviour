using System.Collections.Generic;

namespace MBSCore.LowWeightBehaviour
{
    public interface IBehaviourStateConfig
    {
        string Name { get; }
        IReadOnlyList<IBehaviourActionConfig> ActionConfigs { get; }
        IReadOnlyList<IBehaviourTransitionConfig> TransitionConfigs { get; }
    }
}