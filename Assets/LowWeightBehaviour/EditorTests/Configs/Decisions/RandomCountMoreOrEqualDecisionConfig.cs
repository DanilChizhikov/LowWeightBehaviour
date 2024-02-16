using UnityEngine;

namespace MBSCore.LowWeightBehaviour.EditorTests
{
    internal sealed class RandomCountMoreOrEqualDecisionConfig : TestDecisionConfig
    {
        [SerializeField] private int _targetCount = 0;

        public int TargetCount => _targetCount;
    }
}