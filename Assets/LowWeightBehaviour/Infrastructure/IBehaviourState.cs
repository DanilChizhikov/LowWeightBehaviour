namespace MBSCore.LowWeightBehaviour
{
    public interface IBehaviourState
    {
        string Name { get; }
        
        void Enter(IBehaviourEntity entity);
        void Processing(IBehaviourEntity entity);
        void Exit(IBehaviourEntity entity);
        bool TryGetNextState(IBehaviourEntity entity, out IBehaviourState nextState);
    }
}
