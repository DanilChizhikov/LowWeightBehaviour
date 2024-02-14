using System;

namespace MBSCore.LowWeightBehaviour
{
    public interface IBehaviourActionFactory
    {
        Type ServicedConfigType { get; }
        
        IBehaviourAction Create(IBehaviourActionConfig config, IBehaviourEntity entity);
    }
}