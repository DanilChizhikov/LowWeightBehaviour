using System;

namespace MBSCore.LowWeightBehaviour
{
    public interface IBehaviourDecisionFactory
    {
        Type ServicedConfigType { get; }
        
        IBehaviourDecision Create(IBehaviourDecisionConfig config, IBehaviourEntity entity);
    }
}