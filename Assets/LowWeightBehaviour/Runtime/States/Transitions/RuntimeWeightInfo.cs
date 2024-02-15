namespace MBSCore.LowWeightBehaviour
{
    public struct RuntimeWeightInfo
    {
        public int Weight { get; }
        public IBehaviourState State { get; }

        public RuntimeWeightInfo(int weight, IBehaviourState state)
        {
            Weight = weight;
            State = state;
        }
    }
}