namespace MBSCore.LowWeightBehaviour
{
    public interface IBehaviourActionFactoryService
    {
        IBehaviourAction Create(IBehaviourActionConfig config, IBehaviourEntity entity);
    }
}