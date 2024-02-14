namespace MBSCore.LowWeightBehaviour
{
    public interface IBehaviourDecision
    {
        string Name { get; }
        
        void Enter(IBehaviourEntity entity);
        bool GetDecision(IBehaviourEntity entity);
        void Exit(IBehaviourEntity entity);
    }
}