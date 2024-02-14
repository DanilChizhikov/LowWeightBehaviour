using System;

namespace MBSCore.LowWeightBehaviour
{
    public interface IBehaviourStateFactory
    {
        Type ServicedConfigType { get; }
        
        IBehaviourState Create(IBehaviourStateConfig config, IBehaviourEntity entity);
    }
}