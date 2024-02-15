namespace MBSCore.LowWeightBehaviour
{
    public interface IBehaviourStateFactoryService
    {
        IBehaviourState Create(IBehaviourStateConfig config, IBehaviourEntity entity);
    }
}