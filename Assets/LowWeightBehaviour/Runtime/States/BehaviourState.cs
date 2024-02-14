namespace MBSCore.LowWeightBehaviour
{
    public abstract class BehaviourState : IBehaviourState
    {
        public string Name { get; }

        public BehaviourState(string name)
        {
            Name = name;
        }

        public abstract void Enter();
        public abstract void Processing();
        public abstract void Exit();
        public abstract bool TryGetNextState(out IBehaviourState nextState);
    }
}