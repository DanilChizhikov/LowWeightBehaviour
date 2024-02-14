namespace MBSCore.LowWeightBehaviour
{
    public interface IBehaviourDecision
    {
        string Name { get; }
        
        void Enter();
        bool GetDecision();
        void Exit();
    }
}