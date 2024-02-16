using UnityEngine;

namespace MBSCore.LowWeightBehaviour.EditorTests
{
    internal sealed class WeightCountMoreOrEqualDecisionConfig : TestDecisionConfig
    {
        [SerializeField] private int _targetCount = 0;

        public int TargetCount => _targetCount;
    }
}