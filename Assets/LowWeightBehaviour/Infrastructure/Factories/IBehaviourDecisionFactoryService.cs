namespace MBSCore.LowWeightBehaviour
{
    public interface IBehaviourDecisionFactoryService
    {
        IBehaviourDecision Create(IBehaviourDecisionConfig config, IBehaviourEntity entity);
    }
}