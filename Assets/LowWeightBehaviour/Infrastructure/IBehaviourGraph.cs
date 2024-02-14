namespace MBSCore.LowWeightBehaviour
{
    public interface IBehaviourGraph
    {
        void Enter(bool force = false);
        void Processing();
        void Exit();
    }
}