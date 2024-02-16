namespace MBSCore.LowWeightBehaviour
{
    public interface IBehaviourGraph
    {
        bool IsEntered { get; }
        
        void Enter(bool force = false);
        void Processing();
        void Exit();
    }
}