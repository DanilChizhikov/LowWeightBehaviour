using System.Collections.Generic;

namespace MBSCore.LowWeightBehaviour
{
    public interface IBehaviourGraphConfig
    {
        IBehaviourStateConfig EnterStateConfig { get; }
        IReadOnlyList<IBehaviourStateConfig> StateConfigs { get; }
    }
}