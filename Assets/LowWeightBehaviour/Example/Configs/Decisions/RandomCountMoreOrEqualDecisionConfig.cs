using UnityEngine;

namespace MBSCore.LowWeightBehaviour.Example
{
    internal sealed class RandomCountMoreOrEqualDecisionConfig : ExampleDecisionConfig
    {
        [SerializeField] private int _targetCount = 0;

        public int TargetCount => _targetCount;
    }
}