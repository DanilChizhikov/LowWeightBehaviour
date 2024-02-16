namespace MBSCore.LowWeightBehaviour
{
    public interface IBehaviourAction
    {
        string Name { get; }
        
        void Enter();
        void Processing();
        void Exit();
    }
}