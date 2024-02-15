using System;

namespace MBSCore.LowWeightBehaviour
{
    public interface IBehaviourStateFactory
    {
        Type ServicedConfigType { get; }

        void InstallFactoryService(IBehaviourStateFactoryService value);
        IBehaviourState Create(IBehaviourStateConfig config, IBehaviourEntity entity);
    }
}