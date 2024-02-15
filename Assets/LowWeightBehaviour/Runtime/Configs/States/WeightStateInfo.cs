using System;
using UnityEngine;

namespace MBSCore.LowWeightBehaviour
{
    [Serializable]
    public struct WeightStateInfo
    {
        [SerializeField, Min(0)] private int _weight;
        [SerializeField] private BehaviourStateConfig _state;
        
        public int Weight => _weight;
        public BehaviourStateConfig State => _state;
    }
}