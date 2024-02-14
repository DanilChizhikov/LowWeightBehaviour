namespace MBSCore.LowWeightBehaviour
{
    public interface IBehaviourAction
    {
        string Name { get; }
        
        void Enter(IBehaviourEntity entity);
        void Processing(IBehaviourEntity entity);
        void Exit(IBehaviourEntity entity);
    }
}