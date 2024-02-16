namespace MBSCore.LowWeightBehaviour
{
    public interface IBehaviourTransition
    {
        void Enter();
        bool TryTransition(out IBehaviourState nextState);
        void Exit();
    }
}