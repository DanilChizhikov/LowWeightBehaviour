namespace MBSCore.LowWeightBehaviour
{
    public interface IBehaviourGraphFactory
    {
        IBehaviourGraph Create(IBehaviourGraphConfig config, IBehaviourEntity entity);
    }
}