namespace MBSCore.LowWeightBehaviour
{
    public interface IBehaviourTransition
    {
        bool TryTransition(IBehaviourEntity entity, out IBehaviourState nextState);
    }
}