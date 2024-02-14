namespace MBSCore.LowWeightBehaviour
{
    public interface IBehaviourState
    {
        string Name { get; }
        
        void Enter();
        void Processing();
        void Exit();
        bool TryGetNextState(out IBehaviourState nextState);
    }
}
